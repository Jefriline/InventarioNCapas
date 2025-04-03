using System;
using System.Collections.Generic;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class UsuarioController
    {
        BaseDatos baseDatos = new BaseDatos();

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
    }
}
