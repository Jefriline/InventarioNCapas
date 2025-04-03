using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entities;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class BaseDatos : ConexionMYSQL
    {
        public CUsuario CargarUsuarios()
        {

            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "Select * from usuarios limit 1";

            MySqlDataReader dr = cmd.ExecuteReader();
            CUsuario usuario = new CUsuario();

            while (dr.Read())
            {
                usuario.Id = dr.GetInt32(0);
                usuario.Name = dr.GetString(1);
                usuario.Description = dr.GetString(2);
            }

            return usuario;
        }

        public int InsertarUsuario(string name, string description)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "Insert into usuarios (name,descripcion) values" + " ( '" + name + "', '" + description + "')";
            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas;
        }

        public int InsertarProducto(string codReferent, string name, float price, int stock, int proveedorID, byte[] imagen)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();

            string imagenHex = BitConverter.ToString(imagen).Replace("-", "");

            cmd.CommandText = "INSERT INTO Producto (codigo_interno, nombre, precio, stock, imagen, id_proveedor) VALUES " +
                              "(@codReferent, @name, @price, @stock, UNHEX(@imagenHex), @proveedorID)";

            cmd.Parameters.AddWithValue("@codReferent", codReferent);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@imagenHex", imagenHex);
            cmd.Parameters.AddWithValue("@proveedorID", proveedorID);

            Console.WriteLine("Consulta SQL: " + cmd.CommandText);
            Console.WriteLine("Proveedor ID: " + proveedorID);

            int filasAfectadas = cmd.ExecuteNonQuery();
            Console.WriteLine("Filas afectadas: " + filasAfectadas);

            return filasAfectadas;
        }







        public List<CProveedor> CargarProveedores()
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "SELECT id_proveedor, nombre FROM Proveedor";

            MySqlDataReader dr = cmd.ExecuteReader();
            List<CProveedor> proveedores = new List<CProveedor>();

            while (dr.Read())
            {
                CProveedor proveedor = new CProveedor
                {
                    Id = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                };
                proveedores.Add(proveedor);
            }

            return proveedores;
        }

        public bool ExisteCodigoProducto(string codigo)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Producto WHERE LOWER(codigo_interno) = LOWER(@codigo)";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public List<CProducto> ObtenerTodosProductosConProveedor()
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"
        SELECT 
            p.codigo_interno, 
            p.nombre, 
            p.precio, 
            p.stock, 
            p.imagen,
            p.id_proveedor AS proveedorName,
            pr.nombre AS ProveedorNombre
        FROM Producto p
        INNER JOIN Proveedor pr ON p.id_proveedor = pr.id_proveedor
        ORDER BY p.nombre";

            MySqlDataReader dr = cmd.ExecuteReader();
            List<CProducto> productos = new List<CProducto>();

            while (dr.Read())
            {
                productos.Add(new CProducto
                {
                    codReferent = dr.GetString("codigo_interno"),
                    name = dr.GetString("nombre"),
                    price = dr.GetFloat("precio"),
                    stock = dr.GetInt32("stock"),
                    imagen = (byte[])dr["imagen"],
                    proveedorName = dr.GetInt32("proveedorName"), // Compatibilidad con código existente
                    ProveedorNombre = dr.GetString("ProveedorNombre") // Nuevo campo
                });
            }
            dr.Close();
            return productos;
        }

        public bool ExisteCodigoProducto2(string codigo)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Producto WHERE LOWER(codigo_interno) = LOWER(@codigo)";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public CProducto ObtenerProductoPorCodigo(string codigo)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"
        SELECT 
            p.codigo_interno, 
            p.nombre, 
            p.precio, 
            p.stock, 
            p.imagen,
            p.id_proveedor AS proveedorName,
            pr.nombre AS ProveedorNombre
        FROM Producto p
        INNER JOIN Proveedor pr ON p.id_proveedor = pr.id_proveedor
        WHERE p.codigo_interno = @codigo";

            cmd.Parameters.AddWithValue("@codigo", codigo);

            MySqlDataReader dr = cmd.ExecuteReader();
            CProducto producto = null;

            if (dr.Read())
            {
                producto = new CProducto
                {
                    codReferent = dr.GetString("codigo_interno"),
                    name = dr.GetString("nombre"),
                    price = dr.GetFloat("precio"),
                    stock = dr.GetInt32("stock"),
                    imagen = (byte[])dr["imagen"],
                    proveedorName = dr.GetInt32("proveedorName"),
                    ProveedorNombre = dr.GetString("ProveedorNombre")
                };
            }
            dr.Close();
            return producto;
        }

        public bool EliminarProductoPorCodigo(string codReferent)
        {
            try
            {
                MySqlCommand cmd = Getconnection().CreateCommand();
                cmd.CommandText = "DELETE FROM Producto WHERE codigo_interno = @codReferent";
                cmd.Parameters.AddWithValue("@codReferent", codReferent);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
                return false;
            }
        }
    }
}
