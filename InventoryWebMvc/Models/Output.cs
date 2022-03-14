using System.ComponentModel.DataAnnotations;

namespace InventoryWebMvc.Models
{
    public class Output
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Range(1, 50000, ErrorMessage = "{0} must be from {1} to {2}")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Moment { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public String Place { get; set; }
       
        public Product Product { get; set; }
       
        public int ProductId { get; set; }

        public Output()
        {

        }

        public Output(int id, int quantity, DateTime moment, string place, Product product)
        {
            Id = id;
            Quantity = quantity;
            Moment = moment;
            Place = place;
            Product = product;
        }

    }
}
