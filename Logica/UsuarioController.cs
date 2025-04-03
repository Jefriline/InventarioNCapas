using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Entities;


namespace Logica
{
    public class UsuarioController
    {
        public CUsuario mostrarUsuario()
        {

            CUsuario cUsuario = new CUsuario();
            BaseDatos baseDatos = new BaseDatos();

            cUsuario = baseDatos.CargarUsuarios();

            return cUsuario;
        }


        public string InsertarUsuarios(string name, string description)
        {
            string resultado = "";
            BaseDatos baseDatos = new BaseDatos();

            int filas = baseDatos.InsertarUsuario(name, description); 
            if (filas > 0 )
            {
                resultado = "Datos Guardados";
            }
            else
            {
                resultado = "No se han guardado los datos";
            }

            return resultado;
        }

        public static implicit operator UsuarioController(ProductController v)
        {
            throw new NotImplementedException();
        }
    }
}
