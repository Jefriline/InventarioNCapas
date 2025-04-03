using System;
using System.Drawing;
using System.Windows.Forms;
using Logica;
using Modelo.Entities;

namespace Principal
{
    public partial class updateUsuario : Form
    {
        private UsuarioController usuarioController;
        private CUsuario usuarioActual;

        public updateUsuario(FormStartPosition centerScreen)
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            InicializarComboBox();
        }

        private void InicializarComboBox()
        {
            comboBoxRol.Items.Clear();
            comboBoxRol.Items.Add("Administrador");
            comboBoxRol.Items.Add("Vendedor");
            comboBoxRol.SelectedIndex = 1;
        }

        public void SetUsuario(CUsuario usuario)
        {
            usuarioActual = usuario;
            textBoxNombreCompleto.Text = usuario.nombre_completo;
            comboBoxRol.Text = usuario.rol;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (usuarioController.Update(usuarioActual.id_usuario, 
                    textBoxNombreCompleto.Text.Trim(),
                    string.IsNullOrEmpty(textBoxContrasena.Text) ? null : textBoxContrasena.Text.Trim(),
                    comboBoxRol.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(textBoxNombreCompleto.Text))
            {
                MessageBox.Show("Ingrese el nombre completo");
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxRol_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            
            Color textColor = (e.Index == 0) ? Color.Gray : Color.Black;
            using (var brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(comboBoxRol.Items[e.Index].ToString(),
                    e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void ComboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRol.ForeColor = comboBoxRol.SelectedIndex == 0 ? Color.Gray : Color.Black;
        }
    }
}
