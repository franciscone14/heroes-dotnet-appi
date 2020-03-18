using System.ComponentModel.DataAnnotations;

namespace TourOfHeroes.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "This field accepts up to 30 chars")]
        public string Nome { get; set; }
    }
}