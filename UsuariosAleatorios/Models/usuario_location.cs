using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsuariosAleatorios.Models
{
    public class usuario_location
    {
        public usuario_street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public usuario_location_coordinates coordinates { get; set; }
        
        public usuario_location_timezone timezone { get; set; }
    }

    public struct usuario_location_timezone
    {
        public string offset;
        public string description;
    }
}