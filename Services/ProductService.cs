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
                Name = "Áo Sơ Mi Trắng Premium",
                Description = "Áo sơ mi trắng cao cấp, chất liệu cotton 100%, phù hợp cho môi trường công sở",
                Price = 450000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Áo+Sơ+Mi+Trắng" },
                Sizes = new List<string> { "S", "M", "L", "XL", "XXL" },
                CategoryId = "shirts",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "2",
                Name = "Áo Thun Polo Nam",
                Description = "Áo polo thể thao, chất liệu thấm hút mồ hôi tốt, phù hợp cho hoạt động thường ngày",
                Price = 320000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Áo+Polo+Nam" },
                Sizes = new List<string> { "S", "M", "L", "XL" },
                CategoryId = "t-shirts",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-8),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "3",
                Name = "Quần Jeans Slim Fit",
                Description = "Quần jeans nam form slim, chất liệu denim cao cấp, thiết kế hiện đại",
                Price = 680000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Quần+Jeans" },
                Sizes = new List<string> { "28", "29", "30", "31", "32", "33", "34" },
                CategoryId = "pants",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-6),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "4",
                Name = "Váy Maxi Hoa Nhí",
                Description = "Váy maxi nữ họa tiết hoa nhí, chất liệu voan mềm mại, phù hợp dạo phố",
                Price = 550000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Váy+Maxi" },
                Sizes = new List<string> { "S", "M", "L" },
                CategoryId = "dresses",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "5",
                Name = "Giày Sneaker Trắng",
                Description = "Giày thể thao unisex màu trắng, đế cao su chống trượt, phù hợp mọi hoạt động",
                Price = 890000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Giày+Sneaker" },
                Sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42", "43" },
                CategoryId = "shoes",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-4),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "6",
                Name = "Quần Short Kaki",
                Description = "Quần short nam chất liệu kaki, thoáng mát, phù hợp cho mùa hè",
                Price = 280000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Quần+Short" },
                Sizes = new List<string> { "S", "M", "L", "XL" },
                CategoryId = "shorts",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "7",
                Name = "Túi Xách Nữ Da Thật",
                Description = "Túi xách nữ cao cấp bằng da thật, thiết kế sang trọng, nhiều ngăn tiện dụng",
                Price = 1200000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Túi+Xách" },
                Sizes = new List<string> { "One Size" },
                CategoryId = "accessories",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new ProductDto
            {
                Id = "8",
                Name = "Áo Sơ Mi Sọc Xanh",
                Description = "Áo sơ mi nam họa tiết sọc xanh navy, phong cách business casual",
                Price = 520000m,
                Images = new List<string> { "https://via.placeholder.com/300x400?text=Áo+Sọc+Xanh" },
                Sizes = new List<string> { "S", "M", "L", "XL", "XXL" },
                CategoryId = "shirts",
                CreatedBy = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now
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

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(string categoryId)
        {
            // Simulate API call
            await Task.Delay(400);

            if (string.IsNullOrWhiteSpace(categoryId))
                return _products;

            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
