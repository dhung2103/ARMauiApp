using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ARMauiApp.Models;
using ARMauiApp.Services;
using CommunityToolkit.Maui.Alerts;

namespace ARMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isLoading = false;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        async Task Login()
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

        [RelayCommand]
        async Task NavigateToRegister()
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}
