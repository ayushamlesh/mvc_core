using System.ComponentModel.DataAnnotations;

namespace Care.Models
{
    public class Medecine
    {
        //here we will write the property of our table columns here

        //for keeping required constrains we will user data antonations

        [Key]
        public string? BatchId { get; set; }

        [Required]
        public string? MedName { get; set; }
        [Required]
        public string? Quantity { get; set; }
        [Required]
        public string? Price { get; set; }
        [Required]
        public DateTime? Expire { get; set;}
    }
}
