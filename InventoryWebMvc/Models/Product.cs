using System.ComponentModel.DataAnnotations;

namespace InventoryWebMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public String Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Registration Number")]
        public int RegistrationNumber { get; set; }
        public String Manufacturer { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public ICollection<Input> Inputs { get; set; } = new List<Input>();
        public ICollection<Output> Outputs { get; set; } = new List<Output>();

        public Product()
        {

        }

        public Product(int id, string name, int registrationNumber, string manufacturer, string type, string description)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            Manufacturer = manufacturer;
            Type = type;
            Description = description;
        }

        public void AddInput(Input input)
        {
            Inputs.Add(input);
        }

        public void RemoveInput(Input input)
        {
            Inputs.Remove(input);
        }

        public void AddOutput(Output output)
        {
            Outputs.Add(output);
        }

        public void RemoveOutput(Output output)
        {
            Outputs.Remove(output);
        }
    }
}
