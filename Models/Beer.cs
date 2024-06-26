using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Beer //Clase que reprensta la tabla de beer en la base de datos
    {
        [Key]//indicar primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity de bd(autoincremento)
        public int BeerId { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }

        [Column(TypeName = "decimal(18,2)")]//Indica cuantos decimales dejar despues de la coma
        public decimal Alcohol { get; set; }

        [ForeignKey("BrandId")] // indica que branid es una clave foreanea de brand
        public virtual Brand Brand { get; set; }
    }
}

