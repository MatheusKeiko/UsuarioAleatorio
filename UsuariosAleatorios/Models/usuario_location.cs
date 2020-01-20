using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsuariosAleatorios.Models
{
    public class usuario_location
    {
        public usuario_street street { get; set; }

        [Display(Name = "Cidade")]
        public string city { get; set; }

        [Display(Name = "Estado")]
        public string state { get; set; }

        [Display(Name = "CEP")]
        public string postcode { get; set; }

        [Display(Name = "Pais")]
        public string country { get; set; }
        public usuario_location_coordinates coordinates { get; set; }

        public usuario_location_timezone timezone { get; set; }






        [Display(Name = "Endereço Completo")]
        public string EndereçoCompleto
        {
            get
            {
                return street.name + " " + street.number;

            }

        }



    }

    public struct usuario_location_timezone
    {
        public string offset;
        public string description;
    }
}