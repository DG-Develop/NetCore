using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using CoreEscuela.App;
using static System.Console;
using System;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            /* AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(800, 1000, 2);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento; //Remueve el evento */

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluacion();
            var listaAg = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluacionXAsig();
            var listaPromXAsig = reporteador.GetPromedioAlumnPorAsignatura();
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(300, 1000, 3);
            Printer.WriteTitle("SALIO");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                    
                }
            }

        }

    }
}
