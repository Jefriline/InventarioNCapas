using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class updateProduct : Form
    {
        private string codigoProducto;
        private Dictionary<int, int> proveedorIndices = new Dictionary<int, int>();
        private ProveedorController proveedorController;
        private ProductController productController;
        private byte[] imagenActual;

        public updateProduct(string codigo)
        {
            InitializeComponent();
            codigoProducto = codigo;
            proveedorController = new ProveedorController();
            productController = new ProductController();

            // Configurar el ComboBox
            comboBoxProveedor.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxProveedor.DrawItem += ComboBoxProveedor_DrawItem;
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Hand;

            CargarProveedores();
            CargarDatosProducto();
        }

        private void ComboBoxProveedor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            
            Color textColor = (e.Index == 0) ? Color.Gray : Color.Black;
            using (var brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(comboBoxProveedor.Items[e.Index].ToString(),
                    e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void CargarProveedores()
        {
            try
            {
                List<CProveedor> proveedores = proveedorController.ObtenerProveedores();

                comboBoxProveedor.Items.Clear();
                proveedorIndices.Clear();

                comboBoxProveedor.Items.Add("Seleccione el proveedor del producto");

                int indice = 1;
                foreach (var proveedor in proveedores)
                {
                    comboBoxProveedor.Items.Add(proveedor.Nombre);
                    proveedorIndices[indice] = proveedor.Id;
                    indice++;
                }

                comboBoxProveedor.SelectedIndex = 0;
                comboBoxProveedor.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message);
            }
        }

        private void CargarDatosProducto()
        {
            try
            {
                CProducto producto = productController.ObtenerProductoPorCodigo(codigoProducto);
                if (producto != null)
                {
                    tetBoxCodRef.Text = producto.codReferent;
                    textboxNombre.Text = producto.name;
                    textBoxPrecio.Text = producto.price.ToString("0.00");
                    textBoxStock.Text = producto.stock.ToString();
                    imagenActual = producto.imagen;

                    if (imagenActual != null && imagenActual.Length > 0)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(imagenActual))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                        }
                    }

                    // Seleccionar el proveedor correcto
                    for (int i = 1; i < comboBoxProveedor.Items.Count; i++)
                    {
                        if (proveedorIndices[i] == producto.proveedorId)
                        {
                            comboBoxProveedor.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el producto con el código especificado.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del producto: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Seleccionar imagen del producto";
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        using (var image = Image.FromFile(filePath))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                imagenActual = ms.ToArray();
                            }
                            pictureBox1.Image = new Bitmap(image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProveedor.SelectedIndex > 0)
            {
                comboBoxProveedor.ForeColor = Color.Black;
            }
            else
            {
                comboBoxProveedor.ForeColor = Color.Gray;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tetBoxCodRef.Text) ||
                string.IsNullOrWhiteSpace(textboxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrecio.Text) ||
                string.IsNullOrWhiteSpace(textBoxStock.Text) ||
                comboBoxProveedor.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Formato de precio inválido. Ejemplo: 19.99", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxStock.Text, out int nuevoStock))
            {
                MessageBox.Show("Formato de stock inválido. Debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProveedor = ObtenerIdProveedorSeleccionado();
            if (idProveedor == -1)
            {
                MessageBox.Show("Por favor seleccione un proveedor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de actualizar este producto?",
                                              "Confirmar Actualización",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            var (success, message) = productController.ActualizarProducto(
                codigoProducto,
                tetBoxCodRef.Text,
                textboxNombre.Text,
                precio,
                nuevoStock,
                idProveedor,
                imagenActual
            );

            MessageBox.Show(message, success ? "Éxito" : "Error",
                          MessageBoxButtons.OK,
                          success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

         
        }

        private int ObtenerIdProveedorSeleccionado()
        {
            if (comboBoxProveedor.SelectedIndex > 0)
            {
                return proveedorIndices[comboBoxProveedor.SelectedIndex];
            }
            return -1;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            int stock = int.Parse(textBoxStock.Text);
            stock++;
            textBoxStock.Text = stock.ToString();
        }

        private void buttoMinus_Click(object sender, EventArgs e)
        {
            int stock = int.Parse(textBoxStock.Text);
            if (stock > 0)
            {
                stock--;
                textBoxStock.Text = stock.ToString();
            }
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            HomeAdmin formularioProducto = new HomeAdmin();

            formularioProducto.StartPosition = FormStartPosition.CenterScreen;

            formularioProducto.Show();

            this.Hide();
        }

        private void buttoMinus_Click_1(object sender, EventArgs e)
        {
            int valueStockInt = Convert.ToInt32(textBoxStock.Text);

            if (valueStockInt >= 1)
            {
                valueStockInt = valueStockInt - 1;
                string valueStockString = Convert.ToString(valueStockInt);
                textBoxStock.Text = valueStockString;
            }
            else
            {
                MessageBox.Show("el stock ya se encuentra vacio");
            }
        }

        private void buttonPlus_Click_1(object sender, EventArgs e)
        {
            int valueStockInt = Convert.ToInt32(textBoxStock.Text);

            valueStockInt = valueStockInt + 1;

            string valueStockString = Convert.ToString(valueStockInt);

            textBoxStock.Text = valueStockString;
        }
    }
}
