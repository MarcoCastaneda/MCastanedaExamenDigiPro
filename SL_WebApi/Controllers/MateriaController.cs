using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class MateriaController : ApiController
    {

        // GET api/subcategoria
        [Route("api/Materia/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
          

            ML.Result result = BL.Materia.GetAll();
            if (!result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Materia/GetbyId/{IdMateria}")]
        // GET api/subcategoria/5
        public IHttpActionResult GetById(int IdMateria)
        {
            var result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Materia/GetById/{id}")]

        // GET api/subcategoria/5
        public IHttpActionResult Get(int id)
        {
            var result = BL.Materia.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Materia/Add")]

        // POST api/subcategoria
        public IHttpActionResult Post([FromBody] ML.Materia materia)
        {


            ML.Result result = BL.Materia.Add(materia);


            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Materia/update")]

        // PUT api/subcategoria/5
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Materia/delete/{IdMateria}")]

        // DELETE api/subcategoria/5
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;
            ML.Result result = BL.Materia.Delete(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }




        }


    }



}

