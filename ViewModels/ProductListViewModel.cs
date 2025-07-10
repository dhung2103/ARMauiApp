using ARMauiApp.Models;
using ARMauiApp.Services;
using System.Windows.Input;

namespace ARMauiApp.ViewModels
{
    public partial class ProductListViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        [ObservableProperty]
        private ObservableCollection<ProductDto> products = new();

        [ObservableProperty]
        private string searchText = string.Empty;

        [ObservableProperty]
        private bool isLoading = false;

        [ObservableProperty]
        private bool isRefreshing = false;

        public ICommand LoadProductsCommand { get; }
        public ICommand RefreshProductsCommand { get; }
        public ICommand SearchProductsCommand { get; }
        public ICommand ViewProductDetailCommand { get; }

        public ProductListViewModel(ProductService productService)
        {
            _productService = productService;

            // Đăng ký commands trong constructor
            LoadProductsCommand = new AsyncRelayCommand(LoadProducts);
            RefreshProductsCommand = new AsyncRelayCommand(RefreshProducts);
            SearchProductsCommand = new AsyncRelayCommand(SearchProducts);
            ViewProductDetailCommand = new AsyncRelayCommand<ProductDto?>(ViewProductDetail);
        }

        private async Task LoadProducts()
        {
            if (IsLoading) return;

            IsLoading = true;

            try
            {
                var productList = await _productService.GetProductsAsync();
                Products.Clear();

                foreach (var product in productList)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                // Handle error
                await Shell.Current.DisplayAlert("Error", $"Failed to load products: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task RefreshProducts()
        {
            IsRefreshing = true;
            await LoadProducts();
            IsRefreshing = false;
        }

        private async Task SearchProducts()
        {
            if (IsLoading) return;

            IsLoading = true;

            try
            {
                var productList = await _productService.SearchProductsAsync(SearchText);
                Products.Clear();

                foreach (var product in productList)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Search failed: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ViewProductDetail(ProductDto? product)
        {
            if (product == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                ["ProductId"] = product.Id
            };

            await Shell.Current.GoToAsync("productdetail", navigationParameter);
        }

        public async Task Initialize()
        {
            await LoadProducts();
        }
    }
}
