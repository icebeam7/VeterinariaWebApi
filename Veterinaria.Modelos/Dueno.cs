using System;

namespace Veterinaria.Modelos
{
    public class Dueno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
