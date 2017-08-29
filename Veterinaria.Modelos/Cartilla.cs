using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Veterinaria.Modelos
{
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
}
