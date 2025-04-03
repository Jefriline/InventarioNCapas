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

namespace Principal
{
    public partial class addProveedor : Form
    {
        private ProveedorController proveedorController;

        public addProveedor()
        {
            InitializeComponent();
            proveedorController = new ProveedorController();

            // Configurar el botón de guardar
            btnAgregarProveedor.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxNameProveedor.Text))
                {
                    MessageBox.Show("El nombre del proveedor es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var (success, message) = proveedorController.InsertarProveedor(
                    textBoxNameProveedor.Text.Trim(),
                    string.IsNullOrWhiteSpace(textBoxTelefonoProveedor.Text) ? null : textBoxTelefonoProveedor.Text.Trim(),
                    string.IsNullOrWhiteSpace(textBoxEmailProveedor.Text) ? null : textBoxEmailProveedor.Text.Trim()
                );

                MessageBox.Show(message, success ? "Éxito" : "Error", 
                    MessageBoxButtons.OK, 
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    this.Close();
                }
            };
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
