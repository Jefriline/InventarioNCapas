using System;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class ProductController
    {
        public (bool success, string message) InsertProduct(string codReferent, string name, float price,
                                                  int stock, int idProveedor, byte[] imagen)
        {
            BaseDatos baseDatos = new BaseDatos();

            // Validar código único
            if (baseDatos.ExisteCodigoProducto(codReferent))
            {
                return (false, "El código de producto ya existe. Por favor ingrese un código diferente.");
            }

            int filas = baseDatos.InsertarProducto(codReferent, name, price, stock, idProveedor, imagen);
            return (filas > 0, filas > 0 ? "Datos Guardados" : "No se han guardado los datos");
        }

        public List<CProducto> ObtenerTodosProductos()
        {
            try
            {
                BaseDatos baseDatos = new BaseDatos();
                return baseDatos.ObtenerTodosProductosConProveedor();
            }
            catch (Exception ex)
            {
                // Puedes agregar logging aquí si lo necesitas
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return new List<CProducto>(); // Retorna lista vacía en caso de error
            }
        }

        public bool ExisteCodigoProducto(string codigo)
        {
            BaseDatos baseDatos = new BaseDatos();
            return baseDatos.ExisteCodigoProducto(codigo);
        }

        public CProducto ObtenerProductoPorCodigo(string codigo)
        {
            BaseDatos baseDatos = new BaseDatos();
            return baseDatos.ObtenerProductoPorCodigo(codigo);

        }

        public (bool success, string message) EliminarProductoPorCodigo(string codigo)
        {
            BaseDatos baseDatos = new BaseDatos();
            bool eliminado = baseDatos.EliminarProductoPorCodigo(codigo);
            return (eliminado, eliminado ? "Producto eliminado exitosamente." : "No se encontró el producto con ese código.");
        }

    }
}
