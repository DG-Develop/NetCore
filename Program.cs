using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela(
                "Platzi Academy",
                2012,
                TiposEscuela.Primaria,
                ciudad: "Bogota",
                pais: "Colombia"
            );

            /* var arregloCursos = new Curso[3]{
                new Curso(){ Nombre = "101" },
                new Curso(){ Nombre = "201" },
                new Curso{ Nombre = "301"}
            }; */

            /* Curso[] arregloCursos = {
                new Curso(){ Nombre = "101" },
                new Curso(){ Nombre = "201" },
                new Curso{ Nombre = "301"}
            };
 
            escuela.Cursos = arregloCursos; */

            escuela.Cursos = new Curso[] {
                new Curso(){ Nombre = "101" },
                new Curso(){ Nombre = "201" },
                new Curso{ Nombre = "301"}
            };
            // escuela.Cursos = null;
            //escuela = null;

            WriteLine(escuela);

            ImprimirCursosEscuela(escuela);

            //ImprimirCursosWhile(arregloCursos);
            //ImprimirCursosDoWhile(arregloCursos);
            //ImprimirCursosFor(arregloCursos);
            //ImprimirCursosForEach(arregloCursos);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("===============================");
            WriteLine("Cursos de la Escuela");
            WriteLine("===============================");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }

        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                WriteLine(
                    $"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}"
                );

                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                WriteLine(
                    $"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}"
                );

                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine(
                   $"Nombre: {arregloCursos[i].Nombre}, Id: {arregloCursos[i].UniqueId}"
               );
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var c in arregloCursos)
            {
                WriteLine($"Nombre: {c.Nombre}, Id: {c.UniqueId}");
            }
        }
    }
}
