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
        await DisplayAlert("Edit Profile", "This feature will be implemented soon.", "OK");
    }

    private async void OnChangePasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Change Password", "This feature will be implemented soon.", "OK");
    }

    private async void OnSettingsTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Settings", "This feature will be implemented soon.", "OK");
    }

    private async void OnHelpTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Help & Support", "For support, please contact: support@arproject.com", "OK");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (result)
        {
            await Toast.Make("Logged out successfully").Show();
            await Shell.Current.GoToAsync("//login");
        }
    }
}
