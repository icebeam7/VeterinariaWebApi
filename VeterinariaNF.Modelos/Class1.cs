using System.ComponentModel.DataAnnotations.Schema;
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

    public class Cartilla
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Animal")]
        public int IdAnimal { get; set; }

        //Navegacion
        public virtual Animal Animal { get; set; }
    }

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


