﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AlumnoMateria
    {
        public int IdAlumnoMateria { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }
        public ML.Alumno Alumno { get; set; }
        public ML.Materia Materia { get; set; }
        public List<object> AlumnoMaterias { get; set; }    
    }
}
