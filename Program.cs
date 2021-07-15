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
            var listaTop = reporteador.GetListaTopPromedio(5, "Matemáticas");

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            var newEval = new Evaluacion(); 
            string nombre, notastring;
            //float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();

            nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            
            notastring = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(notastring))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notastring);
                    if(newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota deb estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluacion ha sido ingresado correctamente");
                }
                catch(ArgumentOutOfRangeException ex){
                    Printer.WriteTitle(ex.Message);
                    WriteLine("Saliendo del programa");
                }
                catch(Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es un numero valido");
                    WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.WriteTitle("Finally");
                }
            }
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
