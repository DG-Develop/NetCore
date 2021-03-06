using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {
       
        public int AnioCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);

        public Escuela(
            string nombre,
            int anio,
            TiposEscuela tipo,
            string pais = "",
            string ciudad = ""
        ) => (Nombre, AnioCreacion, TipoEscuela, Pais, Ciudad) = (nombre, anio, tipo, pais, ciudad);

        public override string ToString() =>
        $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}";

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            foreach(var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            
            Printer.WriteTitle($"Escuela {Nombre} Limpia");
            Printer.Beep(200, cantidad:3);
        }
    }
}