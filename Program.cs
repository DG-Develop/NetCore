using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            //Printer.Beep(10000, cantidad:10);
            engine.Inicializar();

            ImprimirCursosEscuela(engine.Escuela);

            //var obj = new ObjetoEscuelaBase();
            Printer.WriteTitle("Pruebas de Polomorfismo");
            var alumnoTest = new Alumno { Nombre = "David Antonio" };

            ObjetoEscuelaBase ob = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"ObjetoEscuela: {ob.Nombre}");
            WriteLine($"ObjetoEscuela: {ob.UniqueId}");
            WriteLine($"ObjetoEscuela: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase{Nombre="Monica Hndz"};
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"ObjetoEscuela: {objDummy.Nombre}");
            WriteLine($"ObjetoEscuela: {objDummy.UniqueId}");
            WriteLine($"ObjetoEscuela: {objDummy.GetType()}");

            alumnoTest = (Alumno) ob;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

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
