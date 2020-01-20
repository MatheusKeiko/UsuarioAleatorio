using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsuariosAleatorios.Models
{
    public class usuario
    {

        [Display(Name = "Gênero")]
        public string gender { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string phone { get; set; }

        [Display(Name = "Celular")]
        public string cell { get; set; }

        [Display(Name = "Naturalidade")]
        public string nat { get; set; }





        public usuario_nome name { get; set; }

        public usuario_login login { get; set; }

        public usuario_picture picture { get; set; }


        public usuario_location location { get; set; }


        [Display(Name = "Nome completo")]
        public string NomeCompleto
        {
            get
            {
                return name.first + " " + name.last;

            }

        }




    }
}
