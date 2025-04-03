using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class HomeAdmin : Form
    {
        private ProductController productController;
        private List<CProducto> todosLosProductos; // Lista para mantener todos los productos
        private const int CARD_WIDTH = 200;
        private const int CARD_HEIGHT = 320;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 30;

        public HomeAdmin()
        {
            InitializeComponent();
            ConfigurarComponentes();
            productController = new ProductController();
            CargarProductos();
        }

        private void ConfigurarComponentes()
        {
            // Configurar FlowLayoutPanel
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            // Configurar ComboBox de filtros
            comboBoxFiltros.Items.AddRange(new object[] {
                "Todos los productos",
                "Stock bajo (< 10)",
                "Sin stock",
                "Más vendidos",
                "Menos vendidos",
                "Precio mayor a menor",
                "Precio menor a mayor",
                "Por proveedor"
            });
            comboBoxFiltros.SelectedIndex = 0;

            // Configurar eventos
            textBoxBuscar.TextChanged += TextBoxBuscar_TextChanged;
            comboBoxFiltros.SelectedIndexChanged += ComboBoxFiltros_SelectedIndexChanged;
        }

        private void CargarProductos()
        {
            try
            {
                todosLosProductos = productController.ObtenerTodosProductos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void ComboBoxFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (todosLosProductos == null) return;

            // Aplicar filtro de búsqueda por texto
            var productosFiltrados = todosLosProductos
                .Where(p => string.IsNullOrEmpty(textBoxBuscar.Text) ||
                           p.name.ToLower().Contains(textBoxBuscar.Text.ToLower()) ||
                           p.codReferent.ToLower().Contains(textBoxBuscar.Text.ToLower()))
                .ToList();

            // Aplicar filtro seleccionado
            switch (comboBoxFiltros.SelectedIndex)
            {
                case 1: // Stock bajo
                    productosFiltrados = productosFiltrados.Where(p => p.stock < 10).ToList();
                    break;
                case 2: // Sin stock
                    productosFiltrados = productosFiltrados.Where(p => p.stock == 0).ToList();
                    break;
                case 3: // Más vendidos (por implementar lógica de ventas)
                    break;
                case 4: // Menos vendidos (por implementar lógica de ventas)
                    break;
                case 5: // Precio mayor a menor
                    productosFiltrados = productosFiltrados.OrderByDescending(p => p.price).ToList();
                    break;
                case 6: // Precio menor a mayor
                    productosFiltrados = productosFiltrados.OrderBy(p => p.price).ToList();
                    break;
                case 7: // Por proveedor
                    var proveedores = productosFiltrados
                        .Select(p => p.ProveedorNombre)
                        .Distinct()
                        .OrderBy(p => p)
                        .ToList();
                    
                    if (proveedores.Any())
                    {
                        var formProveedores = new Form();
                        formProveedores.Text = "Seleccionar Proveedor";
                        formProveedores.Size = new Size(300, 400);
                        formProveedores.StartPosition = FormStartPosition.CenterScreen;

                        var listBox = new ListBox();
                        listBox.Dock = DockStyle.Fill;
                        listBox.Font = new Font("Bahnschrift", 12);
                        listBox.Items.AddRange(proveedores.ToArray());

                        var btnSeleccionar = new Button();
                        btnSeleccionar.Text = "Seleccionar";
                        btnSeleccionar.Dock = DockStyle.Bottom;
                        btnSeleccionar.Height = 40;
                        btnSeleccionar.Font = new Font("Bahnschrift", 12);
                        btnSeleccionar.BackColor = Color.FromArgb(0, 122, 204);
                        btnSeleccionar.ForeColor = Color.White;
                        btnSeleccionar.FlatStyle = FlatStyle.Flat;

                        string proveedorSeleccionado = null;
                        btnSeleccionar.Click += (s, e) =>
                        {
                            if (listBox.SelectedItem != null)
                            {
                                proveedorSeleccionado = listBox.SelectedItem.ToString();
                                formProveedores.Close();
                            }
                        };

                        formProveedores.Controls.Add(listBox);
                        formProveedores.Controls.Add(btnSeleccionar);
                        formProveedores.ShowDialog();

                        if (!string.IsNullOrEmpty(proveedorSeleccionado))
                        {
                            productosFiltrados = productosFiltrados
                                .Where(p => p.ProveedorNombre == proveedorSeleccionado)
                                .ToList();
                        }
                    }
                    break;
            }

            MostrarProductos(productosFiltrados);
        }

        private void MostrarProductos(List<CProducto> productos)
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            foreach (var producto in productos)
            {
                var card = CrearTarjetaProducto(producto);
                flowLayoutPanel1.Controls.Add(card);
            }

            if (productos.Count == 0)
            {
                var lblNoProductos = new Label
                {
                    Text = "No se encontraron productos",
                    AutoSize = true,
                    Font = new Font("Bahnschrift", 12),
                    Padding = new Padding(10),
                    Dock = DockStyle.Top
                };
                flowLayoutPanel1.Controls.Add(lblNoProductos);
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private Panel CrearTarjetaProducto(CProducto producto)
        {
            // Panel principal
            var card = new Panel
            {
                Width = CARD_WIDTH,
                Height = CARD_HEIGHT,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Panel para la imagen
            var imagePanel = new Panel
            {
                Width = CARD_WIDTH - 20,
                Height = 150,
                Location = new Point(10, 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // PictureBox para la imagen del producto
            var pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (producto.imagen != null && producto.imagen.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(producto.imagen))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    // Si hay error al cargar la imagen, no hacemos nada
                }
            }

            imagePanel.Controls.Add(pictureBox);
            card.Controls.Add(imagePanel);

            // Etiquetas para la información del producto
            var lblNombre = new Label
            {
                Text = producto.name,
                Font = new Font("Bahnschrift", 10, FontStyle.Bold),
                Location = new Point(10, 170),
                Width = CARD_WIDTH - 20,
                Height = 20
            };

            var lblCodigo = new Label
            {
                Text = $"Código: {producto.codReferent}",
                Font = new Font("Bahnschrift", 9),
                Location = new Point(10, 190),
                Width = CARD_WIDTH - 20
            };

            var lblPrecio = new Label
            {
                Text = $"Precio: ${producto.price:N2}",
                Font = new Font("Bahnschrift", 9),
                Location = new Point(10, 210),
                Width = CARD_WIDTH - 20
            };

            var lblStock = new Label
            {
                Text = $"Stock: {producto.stock}",
                Font = new Font("Bahnschrift", 9),
                ForeColor = producto.stock < 10 ? Color.Red : Color.Black,
                Location = new Point(10, 230),
                Width = CARD_WIDTH - 20
            };

            var lblProveedor = new Label
            {
                Text = $"Proveedor: {producto.ProveedorNombre ?? "Sin proveedor"}",
                Font = new Font("Bahnschrift", 9),
                Location = new Point(10, 250),
                Width = CARD_WIDTH - 20
            };

            // Botones
            var btnEditar = new Button
            {
                Text = "Editar",
                Size = new Size(90, 35),
                Location = new Point(10, CARD_HEIGHT - 40),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Bahnschrift", 9, FontStyle.Regular)
            };
            btnEditar.FlatAppearance.BorderSize = 0;

            var btnEliminar = new Button
            {
                Text = "Eliminar",
                Size = new Size(90, 35),
                Location = new Point(CARD_WIDTH - 100, CARD_HEIGHT - 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Bahnschrift", 9, FontStyle.Regular)
            };
            btnEliminar.FlatAppearance.BorderSize = 0;

            // Eventos de los botones
            btnEditar.Click += (s, e) =>
            {
                var updateForm = new updateProduct(producto.codReferent)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                updateForm.FormClosed += (s, args) => { CargarProductos(); };
                updateForm.Show();
                this.Hide();
            };

            btnEliminar.Click += (s, e) =>
            {
                if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var (success, message) = productController.EliminarProductoPorCodigo(producto.codReferent);
                    if (success)
                    {
                        CargarProductos();
                    }
                    MessageBox.Show(message, success ? "Éxito" : "Error", 
                        MessageBoxButtons.OK, 
                        success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            };

            // Agregar controles a la tarjeta
            card.Controls.AddRange(new Control[] { 
                imagePanel, lblNombre, lblCodigo, lblPrecio, 
                lblStock, lblProveedor, btnEditar, btnEliminar 
            });

            return card;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            addProduct formProduct = new addProduct();
            formProduct.StartPosition = FormStartPosition.CenterScreen;
            formProduct.FormClosed += (s, args) => { CargarProductos(); };
            formProduct.Show();
            this.Hide();
        }

        private void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            Proveedores formProveedores = new Proveedores();
            formProveedores.StartPosition = FormStartPosition.CenterScreen;
            formProveedores.FormClosed += (s, args) => { this.Show(); };
            formProveedores.Show();
            this.Hide();
        }

        private void btnGestionarUser_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.StartPosition = FormStartPosition.CenterScreen;
            formUsuarios.FormClosed += (s, args) => { this.Show(); };
            formUsuarios.Show();
            this.Hide();
        }

        public static implicit operator HomeAdmin(Login v)
        {
            throw new NotImplementedException();
        }
    }
}