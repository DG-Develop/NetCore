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

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(10, "JuanK");
            diccionario.Add(20, "Lorem Ipsum");


            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }
            
            var dictmp = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(dictmp);
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
