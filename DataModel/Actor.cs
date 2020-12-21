using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_films.DataModel
{
    public class Actor
    {
        [Key]
        public int actor_id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string nationality { get; set; }
        public string played_rolles { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new List<Film>();
        }

    }
}
