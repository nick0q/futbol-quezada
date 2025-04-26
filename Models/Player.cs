using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace futbol.Models
{
    [Table("t_jugadores")]  
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        public int? Edad{ get; set;}

        [Required(ErrorMessage = "Posicion es obligatorio")]
        public string? Posicion { get; set; }

        public string? EquipoActual { get; set; }
    }
}