using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entities;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class BaseDatos : ConexionMYSQL
    {

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
            p.id_proveedor AS proveedorId,
            pr.nombre AS ProveedorNombre,
            p.fecha_actualizacion
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
                    price = dr.GetDecimal("precio"),
                    stock = dr.GetInt32("stock"),
                    imagen = (byte[])dr["imagen"],
                    proveedorId = dr.GetInt32("proveedorId"),
                    ProveedorNombre = dr.GetString("ProveedorNombre"),
                    fecha_actualizacion = dr.GetDateTime("fecha_actualizacion")
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
            p.id_proveedor AS proveedorId,
            p.fecha_actualizacion,
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
                    price = dr.GetDecimal("precio"),
                    stock = dr.GetInt32("stock"),
                    imagen = (byte[])dr["imagen"],
                    proveedorId = dr.GetInt32("proveedorId"),
                    ProveedorNombre = dr.GetString("ProveedorNombre"),
                    fecha_actualizacion = dr.GetDateTime("fecha_actualizacion")
                };
            }
            dr.Close();
            return producto;
        }

        public bool EliminarProductoPorCodigo(string codReferent)
        {
            MySqlCommand cmd = null;
            MySqlTransaction transaction = null;

            try
            {
                cmd = Getconnection().CreateCommand();
                transaction = Getconnection().BeginTransaction();
                cmd.Transaction = transaction;

                // Primero verificamos si el producto existe y obtenemos su ID
                cmd.CommandText = @"SELECT id_producto 
                                  FROM Producto 
                                  WHERE codigo_interno = @codReferent";
                cmd.Parameters.AddWithValue("@codReferent", codReferent);

                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    transaction.Rollback();
                    return false;
                }

                int idProducto = Convert.ToInt32(result);

                // Primero eliminamos los movimientos de inventario relacionados
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM MovimientoInventario WHERE id_producto = @idProducto";
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.ExecuteNonQuery();

                // Ahora eliminamos el producto
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Producto WHERE id_producto = @idProducto";
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                int filasAfectadas = cmd.ExecuteNonQuery();
                
                if (filasAfectadas > 0)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { /* ignore rollback error */ }
                }
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
                throw; // Propagamos la excepción para mejor manejo de errores
            }
        }


        // En Modelo/BaseDatos.cs

        public int InsertarProducto(string codReferent, string name, decimal price, int stock, int proveedorID, byte[] imagen)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();

            // Convertir imagen a hexadecimal
            string imagenHex = BitConverter.ToString(imagen).Replace("-", "");

            // Iniciar transacción para asegurar integridad
            MySqlTransaction transaction = Getconnection().BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                // 1. Insertar producto
                cmd.CommandText = @"INSERT INTO Producto 
                          (codigo_interno, nombre, precio, stock, imagen, id_proveedor) 
                          VALUES (@codReferent, @name, @price, @stock, UNHEX(@imagenHex), @proveedorID)";

                cmd.Parameters.AddWithValue("@codReferent", codReferent);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@imagenHex", imagenHex);
                cmd.Parameters.AddWithValue("@proveedorID", proveedorID);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    // 2. Obtener ID del producto insertado
                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    int idProducto = Convert.ToInt32(cmd.ExecuteScalar());

                    // 3. Registrar movimiento de entrada
                    cmd.CommandText = @"INSERT INTO MovimientoInventario 
                              (id_producto, tipo_movimiento, cantidad) 
                              VALUES (@idProducto, 'entrada', @stock)";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return filasAfectadas;
                }
                else
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error en transacción: " + ex.Message);
                throw; 
            }
        }

        public int ActualizarProducto(string codigoOriginal, string nuevoCodigo, string nombre,
                                     decimal precio, int stock, int idProveedor, byte[] imagen)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();

            
            MySqlTransaction transaction = Getconnection().BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                
                cmd.CommandText = "SELECT id_producto, stock FROM Producto WHERE codigo_interno = @codigoOriginal";
                cmd.Parameters.AddWithValue("@codigoOriginal", codigoOriginal);

                MySqlDataReader dr = cmd.ExecuteReader();
                int idProducto = 0;
                int stockAnterior = 0;

                if (dr.Read())
                {
                    idProducto = dr.GetInt32("id_producto");
                    stockAnterior = dr.GetInt32("stock");
                }
                dr.Close();

                
                string imagenHex = imagen != null ? BitConverter.ToString(imagen).Replace("-", "") : "";

                cmd.CommandText = @"UPDATE Producto 
                          SET codigo_interno = @nuevoCodigo,
                              nombre = @nombre,
                              precio = @precio,
                              stock = @stock,
                              id_proveedor = @idProveedor" +
                              (imagen != null && imagen.Length > 0 ? ", imagen = UNHEX(@imagenHex)" : "") +
                          @" WHERE codigo_interno = @codigoOriginal";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nuevoCodigo", nuevoCodigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                if (imagen != null && imagen.Length > 0)
                {
                    cmd.Parameters.AddWithValue("@imagenHex", imagenHex);
                }
                cmd.Parameters.AddWithValue("@codigoOriginal", codigoOriginal);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    
                    int diferenciaStock = stock - stockAnterior;

                    if (diferenciaStock != 0)
                    {
                        string tipoMovimiento = diferenciaStock > 0 ? "entrada" : "salida";
                        int cantidadMovimiento = Math.Abs(diferenciaStock);

                        cmd.CommandText = @"INSERT INTO MovimientoInventario 
                                  (id_producto, tipo_movimiento, cantidad) 
                                  VALUES (@idProducto, @tipoMovimiento, @cantidad)";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);
                        cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                        cmd.Parameters.AddWithValue("@cantidad", cantidadMovimiento);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return filasAfectadas;
                }
                else
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error en transacción: " + ex.Message);
                throw;
            }
        }

        public List<CProveedor> ObtenerProveedores()
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"SELECT id_proveedor, nombre, telefono, email, fecha_registro 
                              FROM Proveedor 
                              ORDER BY nombre";

            MySqlDataReader dr = cmd.ExecuteReader();
            List<CProveedor> proveedores = new List<CProveedor>();

            while (dr.Read())
            {
                CProveedor proveedor = new CProveedor
                {
                    Id = dr.GetInt32("id_proveedor"),
                    Nombre = dr.GetString("nombre"),
                    Telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? null : dr.GetString("telefono"),
                    Email = dr.IsDBNull(dr.GetOrdinal("email")) ? null : dr.GetString("email"),
                    FechaRegistro = dr.GetDateTime("fecha_registro")
                };
                proveedores.Add(proveedor);
            }
            dr.Close();
            return proveedores;
        }

        public CProveedor ObtenerProveedorPorId(int id)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"SELECT id_proveedor, nombre, telefono, email, fecha_registro 
                              FROM Proveedor 
                              WHERE id_proveedor = @id";
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();
            CProveedor proveedor = null;

            if (dr.Read())
            {
                proveedor = new CProveedor
                {
                    Id = dr.GetInt32("id_proveedor"),
                    Nombre = dr.GetString("nombre"),
                    Telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? null : dr.GetString("telefono"),
                    Email = dr.IsDBNull(dr.GetOrdinal("email")) ? null : dr.GetString("email"),
                    FechaRegistro = dr.GetDateTime("fecha_registro")
                };
            }
            dr.Close();
            return proveedor;
        }

        public bool EliminarProveedor(int id)
        {
            MySqlCommand cmd = null;
            MySqlTransaction transaction = null;

            try
            {
                cmd = Getconnection().CreateCommand();
                transaction = Getconnection().BeginTransaction();
                cmd.Transaction = transaction;

                // Verificar si el proveedor tiene productos asociados
                cmd.CommandText = "SELECT COUNT(*) FROM Producto WHERE id_proveedor = @id";
                cmd.Parameters.AddWithValue("@id", id);
                
                int productosAsociados = Convert.ToInt32(cmd.ExecuteScalar());
                if (productosAsociados > 0)
                {
                    transaction.Rollback();
                    return false;
                }

                // Eliminar el proveedor
                cmd.CommandText = "DELETE FROM Proveedor WHERE id_proveedor = @id";
                int filasAfectadas = cmd.ExecuteNonQuery();

                transaction.Commit();
                return filasAfectadas > 0;
            }
            catch (Exception)
            {
                if (transaction != null) transaction.Rollback();
                throw;
            }
        }

        public int ActualizarProveedor(int id, string nombre, string telefono, string email)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"UPDATE Proveedor 
                              SET nombre = @nombre, 
                                  telefono = @telefono, 
                                  email = @email 
                              WHERE id_proveedor = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);

            return cmd.ExecuteNonQuery();
        }

        public int InsertarProveedor(string nombre, string telefono, string email)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = @"INSERT INTO Proveedor (nombre, telefono, email, fecha_registro) 
                              VALUES (@nombre, @telefono, @email, NOW())";

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);

            return cmd.ExecuteNonQuery();
        }

        public List<CUsuario> ObtenerTodosUsuarios()
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            MySqlDataReader dr = cmd.ExecuteReader();
            List<CUsuario> usuarios = new List<CUsuario>();

            while (dr.Read())
            {
                CUsuario usuario = new CUsuario();
                usuario.id_usuario = dr.GetInt32("id_usuario");
                usuario.nombre_completo = dr.GetString("nombre_completo");
                usuario.contrasena = dr.GetString("contrasena");
                usuario.rol = dr.GetString("rol");
                usuarios.Add(usuario);
            }
            dr.Close();
            return usuarios;
        }

        public int AgregarUsuario(string nombreCompleto, string contrasena, string rol)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "INSERT INTO Usuario (nombre_completo, contrasena, rol) VALUES (@nombre, @contrasena, @rol)";
            cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
            cmd.Parameters.AddWithValue("@contrasena", contrasena);
            cmd.Parameters.AddWithValue("@rol", rol);
            return cmd.ExecuteNonQuery();
        }

        public int ModificarUsuario(int idUsuario, string nombreCompleto, string contrasena, string rol)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            string query = "UPDATE Usuario SET nombre_completo = @nombre, rol = @rol";
            
            if (!string.IsNullOrEmpty(contrasena))
            {
                query += ", contrasena = @contrasena";
            }
            
            query += " WHERE id_usuario = @id";
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@id", idUsuario);
            cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
            cmd.Parameters.AddWithValue("@rol", rol);
            
            if (!string.IsNullOrEmpty(contrasena))
            {
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
            }

            return cmd.ExecuteNonQuery();
        }

        public int BorrarUsuario(int idUsuario)
        {
            MySqlCommand cmd = Getconnection().CreateCommand();
            cmd.CommandText = "DELETE FROM Usuario WHERE id_usuario = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);
            return cmd.ExecuteNonQuery();
        }
    }
}
