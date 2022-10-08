namespace APIRest.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int IdEquipo { get; set; }
        public string Distrito { get; set; }
        public bool Activo { get; set; }
    }
}
