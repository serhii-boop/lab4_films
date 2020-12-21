using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_films.DataModel
{
    public class Film
    {
        [Key]
        public int film_id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Довжина повинна бути менше ніж 50")]
        public string film { get; set; }
        [Required]
        public string main_director { get; set; }
        [Required]
        public decimal budget { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Film()
        {
            Actors = new List<Actor>();
        }

    }
}
