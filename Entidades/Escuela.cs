namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); }
        }

        public int AnioCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public Curso[] Cursos { get; set; }

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

    }
}