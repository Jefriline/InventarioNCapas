using System;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class ProductController
    {
        public List<CProducto> ObtenerTodosProductos()
        {
            try
            {
                BaseDatos baseDatos = new BaseDatos();
                return baseDatos.ObtenerTodosProductosConProveedor();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return new List<CProducto>(); 
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
            try
            {
                BaseDatos baseDatos = new BaseDatos();
                
                // Primero verificamos si el producto existe
                if (!baseDatos.ExisteCodigoProducto(codigo))
                {
                    return (false, $"No se encontró el producto con el código {codigo}.");
                }

                bool eliminado = baseDatos.EliminarProductoPorCodigo(codigo);
                return (eliminado, eliminado ? 
                    "Producto eliminado exitosamente." : 
                    "No se pudo eliminar el producto. Por favor, inténtelo nuevamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar el producto: {ex.Message}");
            }
        }



        public (bool success, string message) InsertProduct(string codReferent, string name, decimal price,
                                                  int stock, int idProveedor, byte[] imagen)
        {
            BaseDatos baseDatos = new BaseDatos();

            if (baseDatos.ExisteCodigoProducto(codReferent))
            {
                return (false, "El código de producto ya existe. Por favor ingrese un código diferente.");
            }

            try
            {
                int filas = baseDatos.InsertarProducto(codReferent, name, price, stock, idProveedor, imagen);
                return (filas > 0, filas > 0 ? "Producto agregado correctamente" : "No se pudo agregar el producto");
            }
            catch (Exception ex)
            {
                return (false, $"Error al agregar el producto: {ex.Message}");
            }
        }

        public (bool success, string message) ActualizarProducto(
            string codigoOriginal,
            string nuevoCodigo,
            string nombre,
            decimal precio,
            int stock,
            int idProveedor,
            byte[] imagen)
        {
            BaseDatos baseDatos = new BaseDatos();

            if (nuevoCodigo != codigoOriginal && baseDatos.ExisteCodigoProducto(nuevoCodigo))
            {
                return (false, "El nuevo código de producto ya existe. Por favor ingrese un código diferente.");
            }

            try
            {
                int filas = baseDatos.ActualizarProducto(codigoOriginal, nuevoCodigo, nombre, precio, stock, idProveedor, imagen);
                return (filas > 0, filas > 0 ? "Producto actualizado correctamente" : "No se pudo actualizar el producto");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar el producto: {ex.Message}");
            }
        }
    }
}
