using CommunityToolkit.Maui.Alerts;

namespace ARMauiApp.Pages;

public partial class AccountPage : ContentPage
{
    public AccountPage()
    {
        InitializeComponent();
    }

    private async void OnEditProfileTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Chỉnh sửa hồ sơ", "Tính năng này sẽ được triển khai sớm.", "OK");
    }

    private async void OnChangePasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Đổi mật khẩu", "Tính năng này sẽ được triển khai sớm.", "OK");
    }

    private async void OnSettingsTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Cài đặt", "Tính năng này sẽ được triển khai sớm.", "OK");
    }

    private async void OnHelpTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Trợ giúp & Hỗ trợ", "Để được hỗ trợ, vui lòng liên hệ: support@arproject.com", "OK");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Đăng xuất", "Bạn có chắc chắn muốn đăng xuất không?", "Có", "Không");
        if (result)
        {
            await Toast.Make("Đăng xuất thành công").Show();
            await Shell.Current.GoToAsync("//login");
        }
    }
}
