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

        public List<string> GenderOptions { get; } = new() { "Male", "Female", "Other" };

        public RegisterViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Toast.Make("Please fill in all required fields").Show();
                return;
            }

            if (Password.Length < 6)
            {
                await Toast.Make("Password must be at least 6 characters").Show();
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
                    await Toast.Make("Registration successful! Please login.").Show();
                    await Shell.Current.GoToAsync("//login");
                }
                else
                {
                    await Toast.Make("Registration failed. Please try again.").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Registration failed: {ex.Message}").Show();
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
