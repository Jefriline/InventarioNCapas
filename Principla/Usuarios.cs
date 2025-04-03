using System;
using System.Drawing;
using System.Windows.Forms;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class Usuarios : Form
    {
        UsuarioController usuarioController = new UsuarioController();
        private const int CARD_HEIGHT = 100;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 30;

        public Usuarios()
        {
            InitializeComponent();
            ConfigurarFlowLayoutPanel();
            CargarUsuarios();
        }

        private void ConfigurarFlowLayoutPanel()
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Padding = new Padding(20);
        }

        private void CargarUsuarios()
        {
            flowLayoutPanel1.Controls.Clear();
            var usuarios = usuarioController.GetAll();
            
            if (usuarios != null)
            {
                foreach (var usuario in usuarios)
                {
                    flowLayoutPanel1.Controls.Add(CrearTarjetaUsuario(usuario));
                }
            }
        }

        private Panel CrearTarjetaUsuario(CUsuario usuario)
        {
            Panel card = new Panel
            {
                Width = flowLayoutPanel1.Width - 25,
                Height = CARD_HEIGHT,
                Margin = new Padding(0, 0, 0, 10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Nombre completo
            Label lblNombre = new Label
            {
                Text = usuario.nombre_completo,
                Font = new Font("Bahnschrift", 12, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            card.Controls.Add(lblNombre);

            // Rol
            Label lblRol = new Label
            {
                Text = $"Rol: {usuario.rol}",
                Font = new Font("Bahnschrift", 10),
                Location = new Point(15, 45),
                AutoSize = true
            };
            card.Controls.Add(lblRol);

            // Botón Editar
            RJButton btnEditar = new RJButton
            {
                Text = "Editar",
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(card.Width - (BUTTON_WIDTH * 2) - 20, (CARD_HEIGHT - BUTTON_HEIGHT) / 2),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEditar.Click += (s, e) =>
            {
                using (var form = new updateUsuario(FormStartPosition.CenterScreen))
                {
                    form.SetUsuario(usuario);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
                    }
                }
            };
            card.Controls.Add(btnEditar);

            // Botón Eliminar
            RJButton btnEliminar = new RJButton
            {
                Text = "Eliminar",
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                Location = new Point(card.Width - BUTTON_WIDTH - 10, (CARD_HEIGHT - BUTTON_HEIGHT) / 2),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            btnEliminar.Click += (s, e) =>
            {
                if (MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (usuarioController.Delete(usuario.id_usuario))
                    {
                        CargarUsuarios();
                    }
                }
            };
            card.Controls.Add(btnEliminar);

            return card;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (var form = new addUsuario())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }
    }
}
