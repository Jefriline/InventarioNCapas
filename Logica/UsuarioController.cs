using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class UsuarioController
    {
        private BaseDatos baseDatos;

        public UsuarioController()
        {
            baseDatos = new BaseDatos();
        }

        public List<CUsuario> GetAll()
        {
            try
            {
                return baseDatos.ObtenerTodosUsuarios();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar usuarios: " + ex.Message);
                return null;
            }
        }

        public bool Insert(string nombreCompleto, string contrasena, string rol)
        {
            try
            {
                return baseDatos.AgregarUsuario(nombreCompleto, contrasena, rol) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
                return false;
            }
        }

        public bool Update(int idUsuario, string nombreCompleto, string contrasena, string rol)
        {
            try
            {
                return baseDatos.ModificarUsuario(idUsuario, nombreCompleto, contrasena, rol) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar usuario: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int idUsuario)
        {
            try
            {
                return baseDatos.BorrarUsuario(idUsuario) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                return false;
            }
        }

        public CUsuario ValidarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                var usuarios = baseDatos.ObtenerTodosUsuarios();
                if (usuarios == null) return null;

                return usuarios.FirstOrDefault(u => 
                    u.nombre_completo.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && 
                    u.contrasena == contrasena);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar usuario: {ex.Message}");
            }
        }
    }
}
