using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Modelos
{
    public class Animal
    {
        public int Id { get; set; }
        public string PerroGato { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Imagen { get; set; }
        public bool Esterilizado { get; set; }

        [ForeignKey("Dueno")]
        public int IdDueno { get; set; }

        // Navegacion
        public virtual Dueno Dueno { get; set; }
    }
}
