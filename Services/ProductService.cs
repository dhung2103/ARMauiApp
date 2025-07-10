using ARMauiApp.Models;

namespace ARMauiApp.Services
{
    public class ProductService
    {
        private readonly List<ProductDto> _products = new()
        {
            new ProductDto
            {
                Id = "1",
                Name = "iPhone 15 Pro",
                Description = "Latest iPhone with A17 Pro chip and titanium design",
                Price = 999.99m,
                Images = new List<string> { "https://via.placeholder.com/300x200?text=iPhone+15+Pro" },
                Sizes = new List<string> { "128GB", "256GB", "512GB", "1TB" },
                CategoryId = "phones",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "2",
                Name = "MacBook Pro M3",
                Description = "Powerful laptop with M3 chip for professionals",
                Price = 1999.99m,
                Images = new List<string> { "https://via.placeholder.com/300x200?text=MacBook+Pro+M3" },
                Sizes = new List<string> { "14-inch", "16-inch" },
                CategoryId = "laptops",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now
            },
            new ProductDto
            {
                Id = "3",
                Name = "iPad Air",
                Description = "Versatile tablet for work and creativity",
                Price = 599.99m,
                Images = new List<string> { "https://via.placeholder.com/300x200?text=iPad+Air" },
                Sizes = new List<string> { "64GB", "256GB" },
                CategoryId = "tablets",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now
            },
            new ProductDto
            {
                Id = "4",
                Name = "AirPods Pro",
                Description = "Premium wireless earbuds with noise cancellation",
                Price = 249.99m,
                Images = new List<string> { "https://via.placeholder.com/300x200?text=AirPods+Pro" },
                Sizes = new List<string> { "One Size" },
                CategoryId = "accessories",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-7),
                UpdatedAt = DateTime.Now.AddDays(-2)
            }
        };

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            // Simulate API call
            await Task.Delay(500);
            return _products;
        }

        public async Task<ProductDto?> GetProductByIdAsync(string id)
        {
            // Simulate API call
            await Task.Delay(300);
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string query)
        {
            // Simulate API call
            await Task.Delay(500);
            
            if (string.IsNullOrWhiteSpace(query))
                return _products;

            return _products.Where(p => 
                p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
