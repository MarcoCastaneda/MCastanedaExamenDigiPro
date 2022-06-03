using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
       
       public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();
            ML.Alumno alumno = new ML.Alumno();
            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                //ML.Result result = new ML.Result();
                //result = BL.Alumno.GetById(IdAlumno.Value);
                var result = alumnoClient.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = ((ML.Alumno)result.Object);
                    return View(alumno);
                }

            }
            return View(alumno);
        }
       

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();

            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                //result = BL.Alumno.Add(alumno);
                var resultAlumno = alumnoClient.Add(alumno);
               
                if (resultAlumno.Correct)
                {
                    ViewBag.Mensaje = "El alumno se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El alumno NO se ha agregado";
                }
            }
            else
            {
                var resultAlumno = alumnoClient.Update(alumno);
                //result = BL.Alumno.Update(alumno);
                if (resultAlumno.Correct)
                {
                    ViewBag.Mensaje = "El alumno se ha actualizado";
                }
                else
                {

                    ViewBag.Mensaje = "El alumno NO se actualizo";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Alumno alumno)
        {
            ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();
            //ML.Result result = new ML.Result();
            if (alumno.IdAlumno != 0)
            {

                var resultAlumno = alumnoClient.Delete(alumno);
               // result = BL.Alumno.Delete(alumno);
                if (resultAlumno.Correct)
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





     