using ARMauiApp.Models;
using ARMauiApp.Services;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace ARMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;
        private readonly TokenService _tokenService;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isLoading = false;

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public LoginViewModel(TokenService tokenService, AuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;

            LoginCommand = new AsyncRelayCommand(Login);
            NavigateToRegisterCommand = new AsyncRelayCommand(NavigateToRegister);
        }

        private async Task Login()
        {
            // Validate input trước khi gửi request
            var validationResult = ValidateInput();
            if (!validationResult.IsValid)
            {
                await Toast.Make(validationResult.ErrorMessage).Show();
                return;
            }

            IsLoading = true;

            try
            {
                var loginDto = new UserLoginDto
                {
                    Email = Email.Trim(),
                    Password = Password
                };

                var (success, user) = await _authService.LoginAsync(loginDto);

                if (success)
                {
                    var message = user != null
                        ? $"Chào mừng {user.Username}!"
                        : "Đăng nhập thành công!";

                    await Toast.Make(message).Show();
                    await Shell.Current.GoToAsync("//products");
                }
                else
                {
                    await Toast.Make("Email hoặc mật khẩu không hợp lệ").Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make($"Đăng nhập thất bại: {ex.Message}").Show();
            }
            finally
            {
                IsLoading = false;
            }
        }

        private (bool IsValid, string ErrorMessage) ValidateInput()
        {
            // Validate Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                return (false, "Email là bắt buộc");
            }

            if (!IsValidEmail(Email.Trim()))
            {
                return (false, "Định dạng email không hợp lệ");
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(Password))
            {
                return (false, "Mật khẩu là bắt buộc");
            }

            if (Password.Length < 6)
            {
                return (false, "Mật khẩu phải có ít nhất 6 ký tự");
            }

            return (true, string.Empty);
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Sử dụng EmailAddressAttribute để validate
                var emailAttribute = new EmailAddressAttribute();
                return emailAttribute.IsValid(email);
            }
            catch
            {
                return false;
            }
        }

        private async Task NavigateToRegister()
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}