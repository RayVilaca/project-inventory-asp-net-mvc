namespace InventoryWebMvc.Models.ViewModels
{
    public class OutputFormViewModel
    {
        public Output Output { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
