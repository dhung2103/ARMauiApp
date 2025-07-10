using ARMauiApp.Models;
using ARMauiApp.Services;

namespace ARMauiApp.ViewModels
{
    [QueryProperty(nameof(ProductId), "ProductId")]
    public partial class ProductDetailViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        [ObservableProperty]
        private string productId = string.Empty;

        [ObservableProperty]
        private ProductDto? product;

        [ObservableProperty]
        private bool isLoading = false;

        [ObservableProperty]
        private string selectedSize = string.Empty;

        public ProductDetailViewModel(ProductService productService)
        {
            _productService = productService;
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
        async Task AddToCart()
        {
            if (Product == null) return;

            // Simulate add to cart
            await Shell.Current.DisplayAlert("Success", $"Added {Product.Name} ({SelectedSize}) to cart!", "OK");
        }

        partial void OnProductIdChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Task.Run(LoadProduct);
            }
        }
    }
}
