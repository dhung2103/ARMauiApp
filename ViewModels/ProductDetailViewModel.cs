using ARMauiApp.Models;
using ARMauiApp.Services;

namespace ARMauiApp.ViewModels
{
    [QueryProperty(nameof(ProductId), "ProductId")]
    public partial class ProductDetailViewModel : ObservableObject
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        [ObservableProperty]
        private string productId = string.Empty;

        [ObservableProperty]
        private ProductDto? product;

        [ObservableProperty]
        private bool isLoading = false;

        [ObservableProperty]
        private string selectedSize = string.Empty;

        [ObservableProperty]
        private string categoryName = string.Empty;

        public ProductDetailViewModel(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [RelayCommand]
        async Task LoadProduct()
        {
            if (string.IsNullOrEmpty(ProductId) || IsLoading) return;

            IsLoading = true;

            try
            {
                Product = await _productService.GetProductByIdAsync(ProductId);

                if (Product?.Sizes?.Any() == true)
                {
                    SelectedSize = Product.Sizes.First();
                }

                // Load category name
                if (Product != null && !string.IsNullOrEmpty(Product.CategoryId))
                {
                    var category = await _categoryService.GetCategoryByIdAsync(Product.CategoryId);
                    CategoryName = category?.Name ?? Product.CategoryId;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load product: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task TryNow()
        {
            if (Product == null) return;

            // Simulate try now action
            await Shell.Current.DisplayAlert("Thử ngay", $"Bạn đang thử {Product.Name} ({SelectedSize}). Cảm giác thế nào?", "Tuyệt vời!");
        }

        partial void OnProductIdChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _ = LoadProductAsync();
            }
        }

        private async Task LoadProductAsync()
        {
            await LoadProduct();
        }
    }
}
