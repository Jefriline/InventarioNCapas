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
using System.Xml.Linq;
using Modelo.Entities;

namespace Principal
{
    public partial class addProduct : Form
    {
        public addProduct()
        {
            InitializeComponent();
            proveedorController = new ProveedorController();
            CargarProveedores();
        }

        private Dictionary<int, int> proveedorIndices = new Dictionary<int, int>();

        private void CargarProveedores()
        {
            List<CProveedor> proveedores = proveedorController.ObtenerProveedores();

            // Limpiar datos anteriores
            comboBox1.Items.Clear();
            proveedorIndices.Clear();

            // Agregar elemento inicial
            comboBox1.Items.Add("Seleccione el proveedor del producto");

            // Agregar proveedores y guardar relación entre índice y ID
            int indice = 1; // Comienza en 1 porque el índice 0 es "Seleccione..."
            foreach (var proveedor in proveedores)
            {
                comboBox1.Items.Add(proveedor.Nombre);
                proveedorIndices[indice] = proveedor.Id;
                indice++;
            }

            comboBox1.SelectedIndex = 0;
            comboBox1.ForeColor = Color.Gray;
        }




        private TableLayoutPanel tableLayoutPanel1;

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            rjButton2 = new RJButton();
            comboBox1 = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonPlus = new Button();
            buttoMinus = new Button();
            textBoxStock = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            rjButton1 = new RJButton();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel2.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(rjButton1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(454, 496);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 0);
            label1.Name = "label1";
            label1.Size = new Size(357, 49);
            label1.TabIndex = 0;
            label1.Text = "Agregar Producto";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(48, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 390);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(rjButton2, 0, 6);
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 5);
            tableLayoutPanel2.Controls.Add(textBox2, 0, 3);
            tableLayoutPanel2.Controls.Add(textBox3, 0, 2);
            tableLayoutPanel2.Controls.Add(textBox4, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.8349533F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6213589F));
            tableLayoutPanel2.Size = new Size(355, 388);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // rjButton2
            // 
            rjButton2.BackColor = Color.Black;
            rjButton2.BackgroundColor = Color.Black;
            rjButton2.BorderColor = Color.Black;
            rjButton2.BorderRadius = 10;
            rjButton2.BorderSize = 1;
            rjButton2.Dock = DockStyle.Fill;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatStyle = FlatStyle.Flat;
            rjButton2.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rjButton2.ForeColor = Color.White;
            rjButton2.Location = new Point(100, 338);
            rjButton2.Margin = new Padding(100, 3, 100, 10);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(155, 40);
            rjButton2.TabIndex = 1;
            rjButton2.Text = "Agregar";
            rjButton2.TextColor = Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(40, 264);
            comboBox1.Margin = new Padding(40, 3, 40, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(275, 30);
            comboBox1.TabIndex = 1;
            comboBox1.DrawItem += ComboBox1_DrawItem;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.Controls.Add(buttonPlus, 3, 0);
            tableLayoutPanel3.Controls.Add(buttoMinus, 1, 0);
            tableLayoutPanel3.Controls.Add(textBoxStock, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 301);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(349, 31);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonPlus
            // 
            buttonPlus.Dock = DockStyle.Fill;
            buttonPlus.Location = new Point(193, 3);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(28, 25);
            buttonPlus.TabIndex = 0;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += buttonPlus_Click;
            // 
            // buttoMinus
            // 
            buttoMinus.Dock = DockStyle.Fill;
            buttoMinus.Location = new Point(125, 3);
            buttoMinus.Name = "buttoMinus";
            buttoMinus.Size = new Size(28, 25);
            buttoMinus.TabIndex = 1;
            buttoMinus.Text = "-";
            buttoMinus.UseVisualStyleBackColor = true;
            buttoMinus.Click += buttoMinus_Click;
            // 
            // textBoxStock
            // 
            textBoxStock.Dock = DockStyle.Fill;
            textBoxStock.Location = new Point(159, 3);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(28, 29);
            textBoxStock.TabIndex = 2;
            textBoxStock.Text = "0";
            textBoxStock.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.ForeColor = Color.Gray;
            textBox2.Location = new Point(40, 227);
            textBox2.Margin = new Padding(40, 3, 40, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Ingrese el precio del Producto...";
            textBox2.Size = new Size(275, 29);
            textBox2.TabIndex = 4;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.ForeColor = Color.Gray;
            textBox3.Location = new Point(40, 190);
            textBox3.Margin = new Padding(40, 3, 40, 3);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Ingrese Cod/referencia del Producto...";
            textBox3.Size = new Size(275, 29);
            textBox3.TabIndex = 5;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.Enter += textBox3_Enter;
            textBox3.Leave += textBox3_Leave;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.ForeColor = Color.Gray;
            textBox4.Location = new Point(40, 153);
            textBox4.Margin = new Padding(40, 3, 40, 3);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Ingrese el Nombre del Producto...";
            textBox4.Size = new Size(275, 29);
            textBox4.TabIndex = 6;
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.Enter += textBox4_Enter;
            textBox4.Leave += textBox4_Leave;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.784111F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.431778F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.7841129F));
            tableLayoutPanel4.Controls.Add(panel2, 1, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.Size = new Size(349, 144);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(82, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(183, 109);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.ErrorImage = null;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Transparent;
            rjButton1.BackgroundColor = Color.Transparent;
            rjButton1.BorderColor = Color.Transparent;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 1;
            rjButton1.Dock = DockStyle.Fill;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rjButton1.ForeColor = Color.Black;
            rjButton1.ImageAlign = ContentAlignment.TopCenter;
            rjButton1.Location = new Point(5, 0);
            rjButton1.Margin = new Padding(5, 0, 0, 0);
            rjButton1.Name = "rjButton1";
            rjButton1.Padding = new Padding(0, 0, 0, 5);
            rjButton1.Size = new Size(40, 49);
            rjButton1.TabIndex = 2;
            rjButton1.Text = "⍇";
            rjButton1.TextAlign = ContentAlignment.TopCenter;
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = true;
            rjButton1.Click += rjButton1_Click;
            // 
            // addProduct
            // 
            ClientSize = new Size(454, 496);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "addProduct";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }


        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private RJButton rjButton2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonPlus;
        private Button buttoMinus;

        private int ObtenerIdProveedorSeleccionado()
        {
            int indiceSeleccionado = comboBox1.SelectedIndex;

            // Si el índice es 0 (opción "Seleccione...") o no hay selección
            if (indiceSeleccionado <= 0)
            {
                return -1; // O cualquier valor que indique que no se seleccionó un proveedor válido
            }

            // Obtener el ID del proveedor según el índice seleccionado
            return proveedorIndices[indiceSeleccionado];
        }
        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            // Obtener el texto del elemento
            string text = comboBox1.Items[e.Index].ToString();

            // Definir el color del texto (gris si es el primer elemento, negro en otros casos)
            Color textColor = (e.Index == 0) ? Color.Gray : Color.Black;

            using (SolidBrush brush = new SolidBrush(textColor))
            {
                // Configurar el texto centrado
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Dibujar el texto centrado
                e.Graphics.DrawString(text, comboBox1.Font, brush, e.Bounds, sf);
            }

            e.DrawFocusRectangle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asegurar que el texto seleccionado sea negro
            comboBox1.ForeColor = Color.Black;

            // Forzar el redibujado para mantener el centrado
            comboBox1.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            int valueStockInt = Convert.ToInt32(textBoxStock.Text);

            valueStockInt = valueStockInt + 1;

            string valueStockString = Convert.ToString(valueStockInt);

            textBoxStock.Text = valueStockString;
        }

        private void buttoMinus_Click(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBoxStock;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private PictureBox pictureBox1;

        private void changedColorTexbox(TextBox idTexbox, string mode, string colorEnter = "Black", string colorLeave = "DarkGray")
        {

            Color enterColor = Color.FromName(colorEnter);
            Color leaveColor = Color.FromName(colorLeave);

            if (mode == "enter")
            {
                idTexbox.ForeColor = enterColor;
            }
            else if (mode == "leave")
            {
                if (idTexbox.Text == "")
                {
                    idTexbox.ForeColor = leaveColor;
                }
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            changedColorTexbox(textBox4, "enter");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            changedColorTexbox(textBox4, "leave");

        }


        private void textBox3_Leave(object sender, EventArgs e)
        {
            changedColorTexbox(textBox3, "leave");

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            changedColorTexbox(textBox3, "enter");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            changedColorTexbox(textBox2, "leave");
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            changedColorTexbox(textBox2, "enter");
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Seleccionar una imagen"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    imagenSeleccionada = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }



        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBoxStock.Text))
            {
                MessageBox.Show("Por favor digite cantidades válidas.");
                return;
            }

            try
            {
                var result = MessageBox.Show(
        "¿Estás seguro que deseas agregar este producto al inventario?",
        "Confirmar",
        MessageBoxButtons.OKCancel,
        MessageBoxIcon.Question
    );

                if (result != DialogResult.OK)
                {
                    return;
                }

                decimal priceFlo = decimal.Parse(textBox2.Text);
                int stockInt = int.Parse(textBoxStock.Text);

                if (imagenSeleccionada == null || imagenSeleccionada.Length == 0)
                {
                    MessageBox.Show("Por favor seleccione una imagen.");
                    return;
                }

                int idProveedor = ObtenerIdProveedorSeleccionado();
                if (idProveedor == -1)
                {
                    MessageBox.Show("Por favor seleccione un proveedor válido.");
                    return;
                }

                var controller = new ProductController();
                var (success, message) = controller.InsertProduct(
                    textBox3.Text,
                    textBox4.Text,
                    priceFlo,
                    stockInt,
                    idProveedor,
                    imagenSeleccionada
                );

                if (!success)
                {
                    textBox3.Focus();
                    textBox3.SelectAll();
                }

                MessageBox.Show(message);

                
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese valores válidos.");
            }
        }






        private void rjButton1_Click(object sender, EventArgs e)
        {

            HomeAdmin formularioProducto = new HomeAdmin();


            formularioProducto.StartPosition = FormStartPosition.CenterScreen;


            formularioProducto.Show();


            this.Hide();
        }


        private RJButton rjButton1;
        private byte[] imagenSeleccionada;

        private ComboBox comboBox1;
        private ProveedorController proveedorController;
    }
}
