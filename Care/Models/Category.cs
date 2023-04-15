using System.ComponentModel.DataAnnotations;

namespace Care.Models
{
    public class Category
    {
        //here we will write the property of our table columns here

        //for keeping required constrains we will user data antonations

        [Key]
        public string? CatId { get; set; }

        [Required]
        public string? CatName { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? Price { get; set; }
 
    }
}
