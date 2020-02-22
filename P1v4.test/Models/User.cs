using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P1v4.test.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
