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
        public List<CProveedor> ObtenerProveedores()
        {
            BaseDatos baseDatos = new BaseDatos();
            return baseDatos.CargarProveedores();
        }
    }
}
