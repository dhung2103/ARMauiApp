using ARMauiApp.Models;

namespace ARMauiApp.Services
{
    public class CategoryService
    {
        private readonly List<CategoryDto> _categories = new()
        {
            new CategoryDto
            {
                Id = "shirts",
                Name = "Áo Sơ Mi",
                Description = "Áo sơ mi nam nữ các loại",
                CreatedAt = DateTime.Now.AddDays(-30),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new CategoryDto
            {
                Id = "t-shirts",
                Name = "Áo Thun",
                Description = "Áo thun polo, áo thun cổ tròn",
                CreatedAt = DateTime.Now.AddDays(-25),
                UpdatedAt = DateTime.Now.AddDays(-2)
            },
            new CategoryDto
            {
                Id = "pants",
                Name = "Quần Dài",
                Description = "Quần âu, quần jeans, quần kaki",
                CreatedAt = DateTime.Now.AddDays(-20),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new CategoryDto
            {
                Id = "shorts",
                Name = "Quần Shorts",
                Description = "Quần short thể thao, quần short casual",
                CreatedAt = DateTime.Now.AddDays(-18),
                UpdatedAt = DateTime.Now
            },
            new CategoryDto
            {
                Id = "dresses",
                Name = "Váy Đầm",
                Description = "Váy maxi, váy ngắn, đầm dự tiệc",
                CreatedAt = DateTime.Now.AddDays(-15),
                UpdatedAt = DateTime.Now.AddDays(-3)
            },
            new CategoryDto
            {
                Id = "shoes",
                Name = "Giày Dép",
                Description = "Giày thể thao, giày cao gót, sandal",
                CreatedAt = DateTime.Now.AddDays(-12),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new CategoryDto
            {
                Id = "accessories",
                Name = "Phụ Kiện",
                Description = "Túi xách, mũ, kính mát, trang sức",
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now
            }
        };

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            // Simulate API call
            await Task.Delay(300);
            return _categories;
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(string id)
        {
            // Simulate API call
            await Task.Delay(200);
            return _categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
