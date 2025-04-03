using System;
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
        // Constantes ajustadas para matching visual exacto
        private const int CARD_WIDTH = 320;
        private const int CARD_HEIGHT = 350;
        private const int COLUMNS = 3;
        private const int IMAGE_HEIGHT = 130;
        private const int TEXT_MARGIN = 10;
        private const int SCROLLBAR_WIDTH = 15;
        private const int BUTTON_HEIGHT = 30;  // Altura reducida para botones
        private const int BUTTON_WIDTH = 85;   // Ancho reducido para botones
        private const int PRICE_WIDTH = 100;   // Ancho ajustado para precio

        public HomeAdmin()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetupScroll();
            Load += (s, e) => LoadProducts();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
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
                {
                    tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / COLUMNS));
                }

                int rowCount = (int)Math.Ceiling(productos.Count / (double)COLUMNS);
                tableLayoutPanel2.RowCount = rowCount;

                for (int i = 0; i < rowCount; i++)
                {
                    tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, CARD_HEIGHT));
                }

                for (int i = 0; i < productos.Count; i++)
                {
                    int row = i / COLUMNS;
                    int col = i % COLUMNS;
                    var card = CreateProductCard(productos[i]);
                    card.Width = CARD_WIDTH - 20; // Ajuste para márgenes
                    tableLayoutPanel2.Controls.Add(card, col, row);
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
                Size = new Size(CARD_WIDTH - 20, CARD_HEIGHT - 20),
                Margin = new Padding(10),
                Padding = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.None
            };

            // Efecto hover
            panel.MouseEnter += (s, e) => panel.BackColor = Color.FromArgb(245, 245, 245);
            panel.MouseLeave += (s, e) => panel.BackColor = Color.White;

            // Layout principal con medidas exactas
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0),
                RowStyles = {
                    new RowStyle(SizeType.Absolute, IMAGE_HEIGHT),    // Imagen
                    new RowStyle(SizeType.Absolute, 60),              // Nombre y código (ajustado)
                    new RowStyle(SizeType.Absolute, 35),              // Stock y proveedor (ajustado)
                    new RowStyle(SizeType.Absolute, 80)               // Botones y precio (ajustado)
                }
            };

            // 1. Imagen del producto
            var picBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = ByteArrayToImage(producto.imagen),
                Margin = new Padding(0, 0, 0, 10)
            };
            mainLayout.Controls.Add(picBox, 0, 0);

            // 2. Panel para nombre y código
            var nameCodePanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            var lblName = new Label
            {
                Text = producto.name,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            var lblCode = new Label
            {
                Text = $"Ref: {producto.codReferent}",
                Dock = DockStyle.Bottom,
                Font = new Font("Arial", 9),
                ForeColor = Color.Gray,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };

            nameCodePanel.Controls.Add(lblCode);
            nameCodePanel.Controls.Add(lblName);
            mainLayout.Controls.Add(nameCodePanel, 0, 1);

            // 3. Panel para stock y proveedor
            var stockProviderPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            stockProviderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            stockProviderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            var lblStock = new Label
            {
                Text = $"Stock: {producto.stock}",
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 9),
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblProvider = new Label
            {
                Text = !string.IsNullOrEmpty(producto.ProveedorNombre) ? producto.ProveedorNombre : "Sin proveedor",
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(153, 51, 0), // Color Redbull
                TextAlign = ContentAlignment.MiddleRight,
                AutoEllipsis = true
            };

            stockProviderPanel.Controls.Add(lblStock, 0, 0);
            stockProviderPanel.Controls.Add(lblProvider, 1, 0);
            mainLayout.Controls.Add(stockProviderPanel, 0, 2);

            // 4. Panel para precio y botones
            var bottomPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 5, 0, 0)
            };

            // Panel para los botones
            var buttonPanel = new Panel
            {
                Width = (BUTTON_WIDTH * 2) + 15, // Ajustado para dar espacio suficiente
                Height = BUTTON_HEIGHT,
                Location = new Point(bottomPanel.Width - ((BUTTON_WIDTH * 2) + 15), BUTTON_HEIGHT + 10)
            };

            // Botones (permanecen exactamente igual)
            var editButton = new Button
            {
                Text = "EDITAR",
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(0, 0),
                Tag = producto.codReferent
            };
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Click += (s, e) =>
            {
                var updateForm = new updateProduct(producto.codReferent) { StartPosition = FormStartPosition.CenterScreen };
                updateForm.FormClosed += (s, args) => { this.Show(); LoadProducts(); };
                updateForm.Show();

            };

            var deleteButton = new Button
            {
                Text = "ELIMINAR",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(BUTTON_WIDTH + 5, 0), // Reducido el espacio entre botones
                Tag = producto.codReferent
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += BtnEliminar_Click;

            buttonPanel.Controls.Add(editButton);
            buttonPanel.Controls.Add(deleteButton);

            // Panel para el precio con mejor manejo del espacio
            var pricePanel = new Panel
            {
                Width = (BUTTON_WIDTH * 2) + 10,
                Height = BUTTON_HEIGHT,
                Location = new Point(5, 5) // Ajustado el margen izquierdo
            };

            var lblPrice = new Label
            {
                Text = $"S/.{producto.price:N2}",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Dock = DockStyle.Fill
            };

            pricePanel.Controls.Add(lblPrice);
            bottomPanel.Controls.Add(pricePanel);
            bottomPanel.Controls.Add(buttonPanel);
            mainLayout.Controls.Add(bottomPanel, 0, 3);

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
            int contentHeight = tableLayoutPanel2.RowCount * CARD_HEIGHT;
            int visibleHeight = tableLayoutPanel2.ClientSize.Height;
            vScrollBar2.Minimum = 0;
            vScrollBar2.Maximum = Math.Max(0, contentHeight - visibleHeight);
            vScrollBar2.LargeChange = visibleHeight / 2;
            vScrollBar2.SmallChange = CARD_HEIGHT / 2;
            vScrollBar2.Enabled = contentHeight > visibleHeight;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            var addForm = new addProduct { StartPosition = FormStartPosition.CenterScreen };
            addForm.FormClosed += (s, args) => { this.Show(); LoadProducts(); };
            addForm.Show();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateScroll();
        }

        private void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            var addForm = new Proveedores { StartPosition = FormStartPosition.CenterScreen };
            addForm.FormClosed += (s, args) => { this.Show(); LoadProducts(); };
            addForm.Show();
            this.Hide();
        }

        private void btnGestionarUser_Click(object sender, EventArgs e)
        {
            var addForm = new Usuarios { StartPosition = FormStartPosition.CenterScreen };
            addForm.FormClosed += (s, args) => { this.Show(); LoadProducts(); };
            addForm.Show();
            this.Hide();
        }
    }
}