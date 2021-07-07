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
            if(dicObsEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }

            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {
            _diccionario[LlaveDiccionario.Evaluacion]
        }
    }
}
