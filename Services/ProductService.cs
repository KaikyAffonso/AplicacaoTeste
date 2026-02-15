using AplicacaoTeste.Models;

namespace AplicacaoTeste.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        private int nextId = 1;

        public List<Product> GetAll()
        {
            return products;
        }

        public void Create(string name, decimal price, int quantity, string username)
        {
            products.Add(new Product
            {
                Id = nextId++,
                Name = name,
                Price = price,
                Quantity = quantity,
                LastModifiedBy = username
            });
        }


        public void Update(int id, string name, decimal price, int quantity, string username)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null) return;

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.LastModifiedBy = username;
        }


        public void Deactivate(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null) return;

            product.Active = false;
        }
    }
}
