namespace InventoryWebMvc.Models.ViewModels
{
    public class InputFormViewModel
    {
        public Input Input { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
