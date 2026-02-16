using AplicacaoTeste.Data;
using AplicacaoTeste.Models;

namespace AplicacaoTeste.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Create(string name, decimal price, int quantity, string username)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Active = true,
                LastModifiedBy = username
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, string name, decimal price, int quantity, string username)
        {
            var product = _context.Products.Find(id);
            if (product == null) return;

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.LastModifiedBy = username;

            _context.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return;

            product.Active = false;
            _context.SaveChanges();
        }
    }
}
