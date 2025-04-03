using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entities;
using Modelo;

namespace Logica
{
    public class ProveedorController
    {
        private BaseDatos baseDatos;

        public ProveedorController()
        {
            baseDatos = new BaseDatos();
        }

        public List<CProveedor> ObtenerProveedores()
        {
            try
            {
                return baseDatos.ObtenerProveedores();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proveedores: {ex.Message}");
                return new List<CProveedor>();
            }
        }

        public (bool success, string message) EliminarProveedor(int id)
        {
            try
            {
                bool eliminado = baseDatos.EliminarProveedor(id);
                return (eliminado, eliminado ? 
                    "Proveedor eliminado exitosamente." : 
                    "No se pudo eliminar el proveedor porque está siendo utilizado en otros registros.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar el proveedor: {ex.Message}");
            }
        }

        public CProveedor ObtenerProveedorPorId(int id)
        {
            try
            {
                return baseDatos.ObtenerProveedorPorId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proveedor: {ex.Message}");
                return null;
            }
        }

        public (bool success, string message) ActualizarProveedor(int id, string nombre, string telefono, string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return (false, "El nombre del proveedor es requerido.");
                }

                int filasAfectadas = baseDatos.ActualizarProveedor(id, nombre, telefono, email);
                return (filasAfectadas > 0, filasAfectadas > 0 ? 
                    "Proveedor actualizado exitosamente." : 
                    "No se pudo actualizar el proveedor.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar el proveedor: {ex.Message}");
            }
        }

        public (bool success, string message) InsertarProveedor(string nombre, string telefono, string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return (false, "El nombre del proveedor es requerido.");
                }

                int filasAfectadas = baseDatos.InsertarProveedor(nombre, telefono, email);
                return (filasAfectadas > 0, filasAfectadas > 0 ? 
                    "Proveedor agregado exitosamente." : 
                    "No se pudo agregar el proveedor.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al agregar el proveedor: {ex.Message}");
            }
        }
    }
}
