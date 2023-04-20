using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? OrderId { get; set; }

        [Required(ErrorMessage = "Medicine is required.")]
    
        public string? CatName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }

}
