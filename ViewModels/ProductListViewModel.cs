using ARMauiApp.Models;
using ARMauiApp.Services;
using System.Windows.Input;

namespace ARMauiApp.ViewModels
{
    public partial class ProductListViewModel : ObservableObject
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        [ObservableProperty]
        private ObservableCollection<ProductDto> products = new();

        [ObservableProperty]
        private ObservableCollection<CategoryDto> categories = new();

        [ObservableProperty]
        private CategoryDto? selectedCategory;

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
        public ICommand LoadCategoriesCommand { get; }
        public ICommand FilterByCategoryCommand { get; }

        public ProductListViewModel(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;

            // Đăng ký commands trong constructor
            LoadProductsCommand = new AsyncRelayCommand(LoadProducts);
            RefreshProductsCommand = new AsyncRelayCommand(RefreshProducts);
            SearchProductsCommand = new AsyncRelayCommand(SearchProducts);
            ViewProductDetailCommand = new AsyncRelayCommand<ProductDto?>(ViewProductDetail);
            LoadCategoriesCommand = new AsyncRelayCommand(LoadCategories);
            FilterByCategoryCommand = new AsyncRelayCommand<CategoryDto?>(FilterByCategory);
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
                await Shell.Current.DisplayAlert("Lỗi", $"Không thể tải sản phẩm: {ex.Message}", "OK");
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
                await Shell.Current.DisplayAlert("Lỗi", $"Tìm kiếm thất bại: {ex.Message}", "OK");
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
            await LoadCategories();
            await LoadProducts();
        }

        private async Task LoadCategories()
        {
            try
            {
                var categoryList = await _categoryService.GetCategoriesAsync();
                Categories.Clear();

                // Add "All Categories" option
                Categories.Add(new CategoryDto { Id = "", Name = "Tất cả danh mục", Description = "Hiển thị tất cả sản phẩm" });

                foreach (var category in categoryList)
                {
                    Categories.Add(category);
                }

                // Set default selection to "All Categories"
                SelectedCategory = Categories.FirstOrDefault();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Lỗi", $"Không thể tải danh mục: {ex.Message}", "OK");
            }
        }

        private async Task FilterByCategory(CategoryDto? category)
        {
            if (category == null) return;

            SelectedCategory = category;

            if (IsLoading) return;
            IsLoading = true;

            try
            {
                List<ProductDto> productList;

                if (string.IsNullOrEmpty(category.Id))
                {
                    // Show all products
                    productList = await _productService.GetProductsAsync();
                }
                else
                {
                    // Filter by category
                    productList = await _productService.GetProductsByCategoryAsync(category.Id);
                }

                Products.Clear();
                foreach (var product in productList)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Lỗi", $"Không thể lọc sản phẩm: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
