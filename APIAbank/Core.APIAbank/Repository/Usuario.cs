using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.APIAbank.Repository
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime? fechanacimiento { get; set; }
        public string direccion { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime fechamodificacion { get; set; }
    }
}
