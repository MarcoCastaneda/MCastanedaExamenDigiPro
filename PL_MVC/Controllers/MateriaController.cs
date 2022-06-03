using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {

            ML.Materia resulmateria = new ML.Materia();
            resulmateria.Materias = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1034/");
                var responseTask = client.GetAsync("api/Materia/GetAll");
                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach(var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resulmateria.Materias.Add(resultItemList);
                    }
                }
            }
                return View(resulmateria);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            if (IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                ML.Materia resulmateria = new ML.Materia();
                resulmateria.Materias = new List<object>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1034/");
                    var responseTask = client.GetAsync("api/Materia/GetById/" + IdMateria);
                    var resul = responseTask.Result;

                    if (resul.IsSuccessStatusCode)
                    {
                        var readTask = resul.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            resulmateria.Materias.Add(resultItemList);
                        }
                    }
                }



            }
            return View(materia);
        }
       




        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            if (materia.IdMateria == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1034/");
                    var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/Add", materia);
                    postTask.Wait();

                    var resultA = postTask.Result;

                    if (resultA.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El alumno se ha agregado";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El alumno NO se ha agregado";
                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1034/");
                    var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/update/", materia);
                    postTask.Wait();

                    var resultA = postTask.Result;

                    if (resultA.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El alumno se ha actualizado";
                    }
                    else
                    {

                        ViewBag.Message = "El alumno NO se actualizo";
                    }
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1034/");
                var postTask = client.GetAsync("api/Materia/delete/" + IdMateria);
                postTask.Wait();
                var resultA = postTask.Result;



                if (resultA.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha eliminado el alumno en la BD";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha eliminado el alumno en la BD";
                }
            }
            return PartialView("Modal");
        }
    }
}





