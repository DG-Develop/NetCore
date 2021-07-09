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
            IEnumerable<Evaluacion> rta;

            if (_diccionario.TryGetValue(
                LlaveDiccionario.Evaluacion,
                out IEnumerable<ObjetoEscuelaBase> lista
            ))
            {
                return rta = lista.Cast<Evaluacion>();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            var listaEvaluaciones = GetListaEvaluacion();

            return (from ev in listaEvaluaciones
                    where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionXAsig()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            return dicRta;
        }
    }
}
