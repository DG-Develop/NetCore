
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela(
                            "Platzi Academy",
                            2012,
                            TiposEscuela.Primaria,
                            ciudad: "Bogota",
                            pais: "Colombia"
                        );
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic)
        {
            foreach(var obj in dic)
            {
                Printer.WriteTitle($"{obj.Key}");
                foreach (var val in obj.Value)
                {
                    Console.WriteLine(val);
                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {


            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listatmp = new List<Evaluacion>();
            var listatmpas = new List<Asignatura>();
            var listatmpal = new List<Alumno>();

            foreach (var curso in Escuela.Cursos)
            {
                listatmpas.AddRange(curso.Asignaturas);
                listatmpal.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listatmp.AddRange(alumno.Evaluaciones);

                }
            }

            diccionario.Add(
                LlaveDiccionario.Asignatura,
                listatmpas.Cast<ObjetoEscuelaBase>()
            );
            diccionario.Add(LlaveDiccionario.Alumno, listatmpal.Cast<ObjetoEscuelaBase>());

            diccionario.Add(
                LlaveDiccionario.Evaluacion,
                listatmp.Cast<ObjetoEscuelaBase>()
            );


            return diccionario;
        }

        #region ReanOnlyList
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }


            return listaObj.AsReadOnly();
        }

        #endregion

        #region Metodos de Carga 
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = {
                "Alba",
                "Felipa",
                "Eusebio",
                "Farid",
                "Donald",
                "Alvaro",
                "Nicolás"
            };
            string[] apellido1 = {
                "Ruiz",
                "Sarmiento",
                "Uribe",
                "Maduro",
                "Trump",
                "Toledo",
                "Herrera"
            };
            string[] nombre2 = {
                "Freddy",
                "Anabel",
                "Rick",
                "Murty",
                "Silvana",
                "Diomedes",
                "Nicomedes",
                "Teodoro"
            };

            //Combinatoria de nombres con Linq
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            //El metodo Orderby ordena por medio de un delegado los id de los alumnos
            //El metodo Take hace que la lista solo devuelva una cierta cantidad asignada 
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){ Nombre = "101", Jornada = TiposJornada.Maniana  },
                new Curso(){ Nombre = "201", Jornada = TiposJornada.Maniana  },
                new Curso{ Nombre = "301", Jornada = TiposJornada.Maniana },
                new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde  },
                new Curso(){ Nombre = "501", Jornada = TiposJornada.Tarde  },
            };

            Random rnd = new Random();


            foreach (var curso in Escuela.Cursos)
            {

                int cantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        #endregion
    }
}