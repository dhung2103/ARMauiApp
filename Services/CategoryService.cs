using ARMauiApp.Models;
using ARMauiApp.Configuration;

namespace ARMauiApp.Services
{
    public class CategoryService : BaseApiService
    {
        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await GetListAsync<CategoryDto>(ApiConfig.Endpoints.Categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(string id)
        {
            return await GetAsync<CategoryDto>($"{ApiConfig.Endpoints.Categories}/{id}");
        }
    }
}
