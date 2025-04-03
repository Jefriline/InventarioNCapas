using System;
using System.Drawing;
using System.Windows.Forms;
using Logica;

namespace Principal
{
    public partial class addUsuario : Form
    {
        private UsuarioController usuarioController;
        private Color enterColor = Color.Black;
        private Color leaveColor = Color.Gray;

        public addUsuario()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            InicializarComboBox();
        }

        private void InicializarComboBox()
        {
            comboBoxRol.Items.Clear();
            comboBoxRol.Items.Add("Seleccione el rol del usuario");
            comboBoxRol.Items.Add("Administrador");
            comboBoxRol.Items.Add("Vendedor");
            comboBoxRol.SelectedIndex = 0;
            comboBoxRol.ForeColor = Color.Gray;

            comboBoxRol.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxRol.DrawItem += ComboBoxRol_DrawItem;
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

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var result = MessageBox.Show(
                    "¿Está seguro que desea agregar este usuario?",
                    "Confirmar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.OK)
                {
                    return;
                }

                bool success = usuarioController.Insert(
                    textBoxNombreCompleto.Text.Trim(),
                    textBoxContrasena.Text.Trim(),
                    comboBoxRol.Text
                );

                if (success)
                {
                    MessageBox.Show("Usuario agregado correctamente", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el usuario", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreCompleto.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre completo del usuario");
                textBoxNombreCompleto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese una contraseña");
                textBoxContrasena.Focus();
                return false;
            }

            if (comboBoxRol.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor seleccione un rol válido");
                comboBoxRol.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRol.ForeColor = comboBoxRol.SelectedIndex == 0 ? Color.Gray : Color.Black;
        }

        private void ChangedColorTextbox(TextBox textBox, string mode)
        {
            if (mode == "enter")
            {
                textBox.ForeColor = enterColor;
            }
            else if (mode == "leave")
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.ForeColor = leaveColor;
                }
            }
        }

        private void textBoxNombreCompleto_Enter(object sender, EventArgs e)
        {
            ChangedColorTextbox(textBoxNombreCompleto, "enter");
        }

        private void textBoxNombreCompleto_Leave(object sender, EventArgs e)
        {
            ChangedColorTextbox(textBoxNombreCompleto, "leave");
        }

        private void textBoxContrasena_Enter(object sender, EventArgs e)
        {
            ChangedColorTextbox(textBoxContrasena, "enter");
        }

        private void textBoxContrasena_Leave(object sender, EventArgs e)
        {
            ChangedColorTextbox(textBoxContrasena, "leave");
        }
    }
}
