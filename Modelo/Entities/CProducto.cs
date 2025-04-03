using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entities
{
    public class CProducto
    {
        public string codReferent { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
        public int proveedorName { get; set; } 
        public string ProveedorNombre { get; set; } // Nuevo campo para el nombre
        public byte[] imagen { get; set; }
    }
}