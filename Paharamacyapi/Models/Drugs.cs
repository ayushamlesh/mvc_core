using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paharamacyapi.Models
{
    public class Drugs
    {
        [Key]
        public string? Id { get; set; }
       [Required(ErrorMessage = "Name is required")]   //not null 
        [MaxLength(30)]
        public string DrugName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? OrderId { get; set; }

        [Required(ErrorMessage = "Medicine is required.")]

        public string? DrugName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
