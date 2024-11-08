﻿


namespace CqrsMediatrExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Test Product 1" },
            new Product { Id = 2, Name = "Test Product 2" },
            new Product { Id = 3, Name = "Test Product 3" }
        };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);
        public async Task<Product> GetProductById(int id)=> await Task.FromResult(_products.Single(x => x.Id == id));

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = _products.Single(x => x.Id == product.Id);
            existingProduct.Name = product.Name;
            await Task.CompletedTask;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            if (!_products.Any(x => x.Id == id))
            {
                return await Task.FromResult(false);
            }
            _products.Remove(_products.Single(x => x.Id == id));
            return await Task.FromResult(true);
        }
    }
}
