using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P1v4.test.Models
{
    public class Entry
    {
        public int EntryID { get; set; }

        public int UserID { get; set; }
        public virtual User User { set; get; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Entrada")]
        public DateTime? HE { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Entrada Almuerzo")]
        public DateTime? HE_A { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Salida Almuerzo")]
        public DateTime? HS_A { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Salida")]
        public DateTime? HS { get; set; }

        


    }
}
