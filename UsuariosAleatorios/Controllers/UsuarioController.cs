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
            //client.BaseAddress = new Uri(urlApi);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlApi).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string jsonResposta = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll

                var lstUsuarios2 = JsonConvert.DeserializeObject<listausuarios>(jsonResposta);
                lstUsuarios = lstUsuarios2.results;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
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