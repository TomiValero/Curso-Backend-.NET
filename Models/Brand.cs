using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Brand//Clase que reprensta la tabla de brand en la base de datos
    {
        [Key]//indicar primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity de bd(autoincremento)
        public int BrandId { get; set; } 
        public string Name { get; set; }
    }
}
