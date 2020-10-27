using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRepository.Models
{
    public class Book
    {
        public long BookID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please specify a paradigm")]
        public string Paradigm { get; set; }

        [Required(ErrorMessage = "Please list a bookseller")]
        public string BookSeller { get; set; }
    }
}
