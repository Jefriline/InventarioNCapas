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
        public decimal price { get; set; }
        public int stock { get; set; }
        public byte[] imagen { get; set; }
        public int proveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime fecha_actualizacion { get; set; } 
    }
}