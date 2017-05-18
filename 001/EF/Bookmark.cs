using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.EF
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdBook { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        [StringLength(10)]
        public string Text { get; set; }
    }
}
