using InventoryWebMvc.Models;

namespace InventoryWebMvc.Data
{
    public class SeedingService
    {
        private InventoryWebMvcContext _context;

        public SeedingService(InventoryWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Product.Any() || _context.Input.Any() || _context.Output.Any())
            {
                return; // DB has been seeded
            }

            Product p1 = new Product(1, "Camiseta", 12345, "Nike", "Vestimenta", "Confortável");
            Product p2 = new Product(2, "Bermuda", 12346, "South", "Vestimenta", "Confortável");
            Product p3 = new Product(3, "Óculos", 12347, "Ray Ban", "Acessórios", "Moderno");
            Product p4 = new Product(4, "Patins", 12348, "Oxer", "Esporte", "Veloz");

            Input i1 = new Input(1, 10, new DateTime(2022, 02, 11), "Recreio dos Bandeirantes", p1);
            Input i2 = new Input(2, 40, new DateTime(2022, 03, 01), "Barra de Guaratiba", p1);
            Input i3 = new Input(3, 100, new DateTime(2022, 02, 02), "Barra da Tijuca", p2);
            Input i4 = new Input(4, 20, new DateTime(2022, 03, 13), "Petrópolis", p3);
            Input i5 = new Input(5, 1, new DateTime(2022, 01, 02), "Barra da Tijuca", p4);

            Output o1 = new Output(1, 5, new DateTime(2022, 02, 11), "Recreio dos Bandeirantes", p1);
            Output o2 = new Output(2, 4, new DateTime(2022, 03, 01), "Barra de Guaratiba", p1);
            Output o3 = new Output(3, 10, new DateTime(2022, 02, 02), "Barra da Tijuca", p2);
            Output o4 = new Output(4, 2, new DateTime(2022, 03, 13), "Petrópolis", p3);
            Output o5 = new Output(5, 1, new DateTime(2022, 01, 02), "Barra da Tijuca", p4);

            _context.Product.AddRange(p1, p2, p3, p4);
            _context.Input.AddRange(i1, i2, i3, i4, i5);
            _context.Output.AddRange(o1, o2, o3, o4, o5);
            _context.SaveChanges();
        }

    }
}
