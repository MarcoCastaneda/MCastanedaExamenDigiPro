using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ML
{
    public class Alumno
    {
        [DataMember]
        public int IdAlumno { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]

        public List<object> Alumnos { get; set; }


    }
}