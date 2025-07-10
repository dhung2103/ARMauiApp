using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ARMauiApp.Models;
using ARMauiApp.Services;
using CommunityToolkit.Maui.Alerts;
using System.Windows.Input;

namespace ARMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string email = "test@example.com";

        [ObservableProperty]
        private string password = "123456";

        [ObservableProperty]
        private bool isLoading = false;

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
            
            // Đăng ký commands trong constructor
            LoginCommand = new AsyncRelayCommand(Login);
            NavigateToRegisterCommand = new AsyncRelayCommand(NavigateToRegister);
        }

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Toast.Make("Please enter email and password").Show();
                return;
            }

            IsLoading = true;

            try
            {
                var loginDto = new UserLoginDto
                {
                    Email = Email,
                    Password = Password
                };

                var success = await _authService.LoginAsync(loginDto);

                if (success)
                {
                    await Toast.Make("Login successful!").Show();
                    // Navigate to main page
                    await Shell.Current.GoToAsync("//products");
                }
                else
                {
                    await Toast.Make("Invalid email or password").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Login failed: {ex.Message}").Show();
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task NavigateToRegister()
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}
