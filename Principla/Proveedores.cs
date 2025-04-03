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
    public partial class Proveedores : Form
    {
        private const int CARD_WIDTH = 300;
        private const int CARD_HEIGHT = 200;
        private const int BUTTON_HEIGHT = 30;
        private const int BUTTON_WIDTH = 85;
        private const int TEXT_MARGIN = 10;
        private ProveedorController proveedorController;

        public Proveedores()
        {
            InitializeComponent();
            proveedorController = new ProveedorController();
            ConfigurarFlowLayout();
            Load += (s, e) => CargarProveedores();

            // Configurar el botón de agregar
            btnAgregarProveedor.Click += (s, e) =>
            {
                var addForm = new addProveedor { StartPosition = FormStartPosition.CenterScreen };
                addForm.FormClosed += (s, args) => { this.Show(); CargarProveedores(); };
                addForm.Show();
                this.Hide();
            };

            // Configurar el botón de regresar
            rjButton1.Click += (s, e) =>
            {
                var homeForm = new HomeAdmin { StartPosition = FormStartPosition.CenterScreen };
                homeForm.Show();
                this.Hide();
            };
        }

        private void ConfigurarFlowLayout()
        {
            flowlayoutContent.AutoScroll = true;
            flowlayoutContent.WrapContents = true;
            flowlayoutContent.FlowDirection = FlowDirection.LeftToRight;
        }

        private void CargarProveedores()
        {
            try
            {
                flowlayoutContent.SuspendLayout();
                flowlayoutContent.Controls.Clear();

                var proveedores = proveedorController.ObtenerProveedores();
                foreach (var proveedor in proveedores)
                {
                    flowlayoutContent.Controls.Add(CrearTarjetaProveedor(proveedor));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}");
            }
            finally
            {
                flowlayoutContent.ResumeLayout(true);
            }
        }

        private Panel CrearTarjetaProveedor(CProveedor proveedor)
        {
            var panel = new Panel
            {
                Width = CARD_WIDTH,
                Height = CARD_HEIGHT,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Efecto hover
            panel.MouseEnter += (s, e) => panel.BackColor = Color.FromArgb(245, 245, 245);
            panel.MouseLeave += (s, e) => panel.BackColor = Color.White;

            // Nombre del proveedor
            var lblNombre = new Label
            {
                Text = proveedor.Nombre,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(TEXT_MARGIN, TEXT_MARGIN),
                Size = new Size(CARD_WIDTH - (TEXT_MARGIN * 2), 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Teléfono
            var lblTelefono = new Label
            {
                Text = $"Tel: {proveedor.Telefono}",
                Font = new Font("Arial", 10),
                ForeColor = Color.Gray,
                Location = new Point(TEXT_MARGIN, lblNombre.Bottom + 5),
                Size = new Size(CARD_WIDTH - (TEXT_MARGIN * 2), 20)
            };

            // Email
            var lblEmail = new Label
            {
                Text = proveedor.Email,
                Font = new Font("Arial", 10),
                ForeColor = Color.Gray,
                Location = new Point(TEXT_MARGIN, lblTelefono.Bottom + 5),
                Size = new Size(CARD_WIDTH - (TEXT_MARGIN * 2), 20)
            };

            // Fecha de registro
            var lblFecha = new Label
            {
                Text = $"Registro: {proveedor.FechaRegistro:dd/MM/yyyy}",
                Font = new Font("Arial", 10),
                ForeColor = Color.Gray,
                Location = new Point(TEXT_MARGIN, lblEmail.Bottom + 5),
                Size = new Size(CARD_WIDTH - (TEXT_MARGIN * 2), 20)
            };

            // Panel para botones
            var buttonPanel = new Panel
            {
                Width = CARD_WIDTH - (TEXT_MARGIN * 2),
                Height = BUTTON_HEIGHT,
                Location = new Point(TEXT_MARGIN, CARD_HEIGHT - BUTTON_HEIGHT - TEXT_MARGIN)
            };

            // Botón Eliminar
            var btnEliminar = new Button
            {
                Text = "ELIMINAR",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(0, 0),
                Tag = proveedor.Id
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += (s, e) =>
            {
                if (MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var (success, message) = proveedorController.EliminarProveedor(proveedor.Id);
                    MessageBox.Show(message);
                    if (success) CargarProveedores();
                }
            };

            // Botón Editar
            var btnEditar = new Button
            {
                Text = "EDITAR",
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(BUTTON_WIDTH + 10, 0),
                Tag = proveedor.Id
            };
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.Click += (s, e) =>
            {
                var updateForm = new updateProveedor(proveedor.Id) { StartPosition = FormStartPosition.CenterScreen };
                updateForm.FormClosed += (s, args) => { this.Show(); CargarProveedores(); };
                updateForm.Show();
                this.Hide();
            };

            buttonPanel.Controls.Add(btnEliminar);
            buttonPanel.Controls.Add(btnEditar);

            panel.Controls.AddRange(new Control[] { lblNombre, lblTelefono, lblEmail, lblFecha, buttonPanel });
            return panel;
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}
