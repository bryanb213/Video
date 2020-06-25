using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the movie name.")]
        public string Name { get; set; }


        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage ="Please enter the date the movie was released.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage ="Must have between 1 & 20 copies")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}
