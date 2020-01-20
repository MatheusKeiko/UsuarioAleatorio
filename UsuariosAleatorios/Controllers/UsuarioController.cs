using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using UsuariosAleatorios.Models;

namespace UsuariosAleatorios.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : Controller
    {
        public List<usuario> PegarUsuariosNaAPI()
        {
            List<usuario> lstUsuarios = new List<usuario>();

            string urlApi = "https://randomuser.me/api?results=10&seed=matheus";

            HttpClient client = new HttpClient();


            // adiciona e aceita formato json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(urlApi).Result;
            if (response.IsSuccessStatusCode)
            {

                string jsonResposta = response.Content.ReadAsStringAsync().Result;

                var lstUsuarios2 = JsonConvert.DeserializeObject<listausuarios>(jsonResposta);
                lstUsuarios = lstUsuarios2.results;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }




            client.Dispose();

            return lstUsuarios;
        }


        // GET: Usuario
        public ActionResult Index()
        {
            var lst = PegarUsuariosNaAPI();
            return View(lst);
        }

        public ActionResult Details(string uuid)
        {
            var listaUsuarios = PegarUsuariosNaAPI();

            foreach (var item in listaUsuarios)
            {
                if (item.login.uuid == uuid)
                {
                    return View(item);
                }
            }

            // Não encontrou o código informado
            return HttpNotFound();
        }
    }
}