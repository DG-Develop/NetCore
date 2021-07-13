using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(
            Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc
        )
        {
            if (dicObsEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }

            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {
            //var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);

            if (_diccionario.TryGetValue(
                LlaveDiccionario.Evaluacion,
                out IEnumerable<ObjetoEscuelaBase> lista
            ))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion> listaEvaluaciones
        )
        {
            listaEvaluaciones = GetListaEvaluacion();

            return (from ev in listaEvaluaciones
                    where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionXAsig()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                dicRta.Add(asig, evalsAsig);
            }

            return dicRta;
        }

        public Dictionary<string, IEnumerable<Object>> GetPromedioAlumnPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<Object>>();

            var dicEvalXAsig = GetDicEvaluacionXAsig();
            foreach (var asigConEval in dicEvalXAsig)
            {
                // En los valores anonimos no se pueden regresar valores con el mismo nombre
                // para ello se pone un nombre identificador y se iguala al valor relacionado

                //En los linq agrupados en este ejemplo se agrupa por asigunarura y despues
                // por el id unico del alumno
                var dummy = from eval in asigConEval.Value
                            group eval by eval.Alumno.UniqueId
                            into grupoEvalsalumno
                            select new
                            {
                                AlumnoId = grupoEvalsalumno.Key,
                                Promedio = grupoEvalsalumno.Average(evaluacion => evaluacion.Nota)
                            };
            }
            return rta;
        }
    }
}
