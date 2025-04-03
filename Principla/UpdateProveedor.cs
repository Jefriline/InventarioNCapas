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
    public partial class updateProveedor : Form
    {
        private readonly ProveedorController proveedorController;
        private readonly int proveedorId;

        public updateProveedor(int id)
        {
            InitializeComponent();
            proveedorId = id;
            proveedorController = new ProveedorController();
            Load += (s, e) => CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            try
            {
                var proveedor = proveedorController.ObtenerProveedorPorId(proveedorId);
                if (proveedor == null)
                {
                    MessageBox.Show("No se encontró el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtNombre.Text = proveedor.Nombre;
                txtTelefono.Text = proveedor.Telefono;
                txtEmail.Text = proveedor.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del proveedor: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (success, message) = proveedorController.ActualizarProveedor(
                proveedorId,
                txtNombre.Text.Trim(),
                string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim()
            );

            MessageBox.Show(message, success ? "Éxito" : "Error", 
                MessageBoxButtons.OK, 
                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (success)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
