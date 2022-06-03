using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            SL_WCF.Result Resultservice = new SL_WCF.Result();
            Resultservice.Correct = result.Correct;
            Resultservice.ErrorMessage = result.ErrorMessage;
            Resultservice.Ex = result.Ex;
            Resultservice.Object = result.Object;
            Resultservice.Objects = result.Objects;

            return Resultservice;

        }

        public SL_WCF.Result Update(ML.Alumno alumno)

        {
            ML.Result result = BL.Alumno.Update(alumno);
            SL_WCF.Result Resultservice = new SL_WCF.Result();
            Resultservice.Correct = result.Correct;
            Resultservice.ErrorMessage = result.ErrorMessage;
            Resultservice.Ex = result.Ex;
            Resultservice.Object = result.Object;
            Resultservice.Objects = result.Objects;

            return Resultservice;

        }

        public SL_WCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);
            SL_WCF.Result Resultservice = new SL_WCF.Result();
            Resultservice.Correct = result.Correct;
            Resultservice.ErrorMessage = result.ErrorMessage;
            Resultservice.Ex = result.Ex;
            Resultservice.Object = result.Object;
            Resultservice.Objects = result.Objects;

            return Resultservice;

        }

        public SL_WCF.Result GetAll(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.GetAll();
            SL_WCF.Result Resultservice = new SL_WCF.Result();
            Resultservice.Correct = result.Correct;
            Resultservice.ErrorMessage = result.ErrorMessage;
            Resultservice.Ex = result.Ex;
            Resultservice.Object = result.Object;
            Resultservice.Objects = result.Objects;

            return Resultservice;

        }

        public SL_WCF.Result GetById(int alumno)
        {
            ML.Result result = BL.Alumno.GetById(alumno);
            SL_WCF.Result Resultservice = new SL_WCF.Result();
            Resultservice.Correct = result.Correct;
            Resultservice.ErrorMessage = result.ErrorMessage;
            Resultservice.Ex = result.Ex;
            Resultservice.Object = result.Object;
            Resultservice.Objects = result.Objects;

            return Resultservice;

        }

    }
}
