using System;

namespace Modelo.Entities
{
    public class CUsuario
    {
        public int id_usuario { get; set; }
        public string nombre_completo { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
    }
}
