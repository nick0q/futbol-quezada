using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace futbol.Models
{
    [Table("t_jugadorEquipo")] 
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        
    }
}