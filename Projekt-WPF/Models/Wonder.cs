using System.ComponentModel.DataAnnotations;

namespace Projekt_WPF.Models
{
    public class Wonder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public DateTime DateBuilt { get; set; } = DateTime.Now;
    }
}