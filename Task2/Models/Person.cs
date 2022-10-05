using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class Person
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
