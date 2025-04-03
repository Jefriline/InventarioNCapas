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
    public partial class Home : Form
    {
        private const int ROW_HEIGHT = 230;
        private const int COLUMNS = 3;
        private const int IMAGE_HEIGHT = 90;
        private const int TEXT_MARGIN = 8;
        private const int SCROLLBAR_WIDTH = 15;

        public Home()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetupScroll();
            Load += (s, e) => LoadProducts();
        }

        private void SetupScroll()
        {
            tableLayoutPanel2.AutoScroll = true;
            vScrollBar2.Width = SCROLLBAR_WIDTH;
            vScrollBar2.Scroll += (s, e) => tableLayoutPanel2.VerticalScroll.Value = vScrollBar2.Value;
        }

        private void LoadProducts()
        {
            try
            {
                tableLayoutPanel2.SuspendLayout();
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel2.RowStyles.Clear();

                var productos = new ProductController().ObtenerTodosProductos();
                if (!productos.Any()) return;

                tableLayoutPanel2.ColumnCount = COLUMNS;
                for (int i = 0; i < COLUMNS; i++)
                    tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / COLUMNS));

                int rowCount = (int)Math.Ceiling(productos.Count / (double)COLUMNS);
                tableLayoutPanel2.RowCount = rowCount;

                for (int i = 0; i < rowCount; i++)
                    tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, ROW_HEIGHT));

                for (int i = 0; i < productos.Count; i++)
                {
                    int row = i / COLUMNS;
                    int col = i % COLUMNS;
                    tableLayoutPanel2.Controls.Add(CreateProductCard(productos[i]), col, row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando productos: {ex.Message}");
            }
            finally
            {
                tableLayoutPanel2.ResumeLayout(true);
                UpdateScroll();
            }
        }

        private Panel CreateProductCard(CProducto producto)
{
    var panel = new Panel
    {
        BackColor = Color.White,
        Dock = DockStyle.Fill,
        Margin = new Padding(10),
        Padding = new Padding(10),
        BorderStyle = BorderStyle.FixedSingle
    };

    var mainLayout = new TableLayoutPanel
    {
        Dock = DockStyle.Fill,
        ColumnCount = 2,
        RowCount = 4,
        BackColor = Color.Transparent,
        Margin = new Padding(0),
        AutoSize = true
    };

    // Definir distribución de columnas
    mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
    mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));

    // Definir distribución de filas
    mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, IMAGE_HEIGHT));  // Imagen
    mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));             // Nombre y precio
    mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));            // Stock y proveedor
    mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));            // Botones

    // Imagen del producto
    var picBox = new PictureBox
    {
        Dock = DockStyle.Fill,
        SizeMode = PictureBoxSizeMode.Zoom,
        Image = ByteArrayToImage(producto.imagen),
        Margin = new Padding(0, 0, 0, TEXT_MARGIN)
    };
    mainLayout.Controls.Add(picBox, 0, 0);
    mainLayout.SetColumnSpan(picBox, 2);

    // Contenedor para nombre y código
    var namePanel = new TableLayoutPanel
    {
        Dock = DockStyle.Fill,
        ColumnCount = 1,
        RowCount = 2
    };
    namePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    namePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

    var lblName = new Label
    {
        Text = producto.name,
        Dock = DockStyle.Top,
        Font = new Font("Bahnschrift", 12, FontStyle.Bold),
        ForeColor = Color.FromArgb(64, 64, 64),
        AutoSize = true
    };

    var lblCode = new Label
    {
        Text = $"# {producto.codReferent}",
        Dock = DockStyle.Top,
        Font = new Font("Bahnschrift", 10),
        ForeColor = Color.Gray,
        AutoSize = true
    };

    namePanel.Controls.Add(lblName);
    namePanel.Controls.Add(lblCode);
    mainLayout.Controls.Add(namePanel, 0, 1);

    // Precio
    var lblPrice = new Label
    {
        Text = $"${producto.price:N2}",
        Dock = DockStyle.Fill,
        Font = new Font("Bahnschrift", 15, FontStyle.Bold),
        ForeColor = Color.FromArgb(0, 122, 204),
        TextAlign = ContentAlignment.MiddleRight,
        Padding = new Padding(5, 0, 0, 0)
    };
    mainLayout.Controls.Add(lblPrice, 1, 1);

    // Stock
    var lblStock = new Label
    {
        Text = $"Stock: {producto.stock}",
        Dock = DockStyle.Fill,
        Font = new Font("Bahnschrift", 11, FontStyle.Bold),
        ForeColor = Color.FromArgb(100, 100, 100),
        TextAlign = ContentAlignment.MiddleLeft,
        AutoSize = true
    };
    mainLayout.Controls.Add(lblStock, 0, 2);

    // Proveedor
    var lblProvider = new Label
    {
        Text = !string.IsNullOrEmpty(producto.ProveedorNombre) ? producto.ProveedorNombre : "Sin proveedor",
        Dock = DockStyle.Fill,
        Font = new Font("Bahnschrift", 10),
        ForeColor = Color.Gray,
        TextAlign = ContentAlignment.MiddleRight,
        AutoSize = true
    };
    mainLayout.Controls.Add(lblProvider, 1, 2);

    // Panel de botones alineados correctamente
    var buttonLayout = new FlowLayoutPanel
    {
        Dock = DockStyle.Fill,
        FlowDirection = FlowDirection.RightToLeft,
        WrapContents = false,
        AutoSize = true
    };

    Button editButton = new Button
    {
        Text = "Editar",
        BackColor = Color.Blue,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Bahnschrift", 10, FontStyle.Bold),
        Height = 30,
        Width = 80,
        Anchor = AnchorStyles.Right
    };
    editButton.FlatAppearance.BorderSize = 0;

    Button deleteButton = new Button
    {
        Text = "Eliminar",
        BackColor = Color.Red,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Bahnschrift", 10, FontStyle.Bold),
        Height = 30,
        Width = 80,
        Margin = new Padding(10, 0, 0, 0),
        Anchor = AnchorStyles.Right,
        Tag = producto.codReferent
    };
    deleteButton.FlatAppearance.BorderSize = 0;
    deleteButton.Click += BtnEliminar_Click;

    buttonLayout.Controls.Add(editButton);
    buttonLayout.Controls.Add(deleteButton);

    mainLayout.Controls.Add(buttonLayout, 0, 3);
    mainLayout.SetColumnSpan(buttonLayout, 2);

    panel.Controls.Add(mainLayout);
    return panel;
}

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string codReferent)
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este producto?",
                                                  "Confirmar Eliminación",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var controller = new ProductController();
                    var (success, message) = controller.EliminarProductoPorCodigo(codReferent);

                    MessageBox.Show(message, success ? "Éxito" : "Error",
                                  MessageBoxButtons.OK,
                                  success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success) LoadProducts();
                }
            }
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                if (byteArray == null || byteArray.Length == 0)
                    return Properties.Resources.default_image;
                using (var ms = new MemoryStream(byteArray))
                    return Image.FromStream(ms);
            }
            catch
            {
                return Properties.Resources.default_image;
            }
        }

        private void UpdateScroll()
        {
            int contentHeight = tableLayoutPanel2.RowCount * ROW_HEIGHT;
            int visibleHeight = tableLayoutPanel2.ClientSize.Height;
            vScrollBar2.Minimum = 0;
            vScrollBar2.Maximum = Math.Max(0, contentHeight - visibleHeight);
            vScrollBar2.LargeChange = visibleHeight;
            vScrollBar2.SmallChange = ROW_HEIGHT / 2;
            vScrollBar2.Enabled = contentHeight > visibleHeight;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            var addForm = new addProduct { StartPosition = FormStartPosition.CenterScreen };
            addForm.FormClosed += (s, args) => { this.Show(); LoadProducts(); };
            addForm.Show();
            this.Hide();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateScroll();
        }
    }
}