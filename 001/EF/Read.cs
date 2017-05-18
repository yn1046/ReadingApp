using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.EF
{
    public class Read
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdBook { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(IdBook))]
        public virtual Book MyBook { get; set; }

        [ForeignKey(nameof(IdUser))]
        public virtual User MyUser { get; set; }        
    }
}
