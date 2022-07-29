using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMoroni.Models
{
    public class ScriptureNote
    {
        [Key]
        [Required]
        public int ScriptureNoteId { get; set; }

        [Required(ErrorMessage = "Please enter a reference.")]
        public string Reference { get; set; }

        public string Link { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a scripture or quote.")]
        public string Quote { get; set; }

        [Required(ErrorMessage = "Please enter your notes.")]
        public string Notes { get; set; }

        // Build foreign key relationship
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
