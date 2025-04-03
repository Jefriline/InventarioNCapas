using System;
using System.Windows.Forms;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class Login : Form
    {
        private UsuarioController usuarioController;

        public Login()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = txtUsuario.Text.Trim();
                string contrasena = txtContrasena.Text;

                if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuario = usuarioController.ValidarUsuario(nombreUsuario, contrasena);
                if (usuario != null)
                {
                    this.Hide();
                    if (usuario.rol == "Administrador")
                    {
                        HomeAdmin homeAdmin = new HomeAdmin();
                        homeAdmin.FormClosed += (s, args) => this.Close();
                        homeAdmin.Show();
                    }
                    else if (usuario.rol == "Vendedor")
                    {
                        HomeVendedor homeVendedor = new HomeVendedor();
                        homeVendedor.FormClosed += (s, args) => this.Close();
                        homeVendedor.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
