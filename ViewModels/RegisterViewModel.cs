using ARMauiApp.Models;
using ARMauiApp.Services;
using CommunityToolkit.Maui.Alerts;

namespace ARMauiApp.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private int selectedGender = 0;

        [ObservableProperty]
        private double height = 170;

        [ObservableProperty]
        private double weight = 70;

        [ObservableProperty]
        private bool isLoading = false;

        public List<string> GenderOptions { get; } = new() { "Nam", "Nữ", "Khác" };

        public RegisterViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Toast.Make("Vui lòng điền đầy đủ các trường bắt buộc").Show();
                return;
            }

            if (Password.Length < 6)
            {
                await Toast.Make("Mật khẩu phải có ít nhất 6 ký tự").Show();
                return;
            }

            IsLoading = true;

            try
            {
                var registerDto = new UserRegisterDto
                {
                    Username = Username,
                    Email = Email,
                    Password = Password,
                    Gender = SelectedGender,
                    Height = Height,
                    Weight = Weight,
                    RoleId = "user"
                };

                var success = await _authService.RegisterAsync(registerDto);

                if (success)
                {
                    await Toast.Make("Đăng ký thành công! Vui lòng đăng nhập.").Show();
                    await Shell.Current.GoToAsync("//login");
                }
                else
                {
                    await Toast.Make("Đăng ký thất bại. Vui lòng thử lại.").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Đăng ký thất bại: {ex.Message}").Show();
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        async Task NavigateToLogin()
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}
