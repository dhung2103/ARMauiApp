# ARMauiApp

A .NET MAUI mobile application built with UraniumUI and CommunityToolkit.Maui. This app demonstrates a modern mobile architecture with authentication, product management, and navigation.

## Features

- **Authentication System**: Login and registration with validation
- **Product Management**: Browse products and view detailed information
- **Modern UI**: Built with UraniumUI and InputKit for a polished experience
- **Navigation**: Shell-based navigation with bottom tab bar
- **MVVM Architecture**: Clean separation of concerns with ViewModels

## Tech Stack

- **.NET MAUI 8.0**: Cross-platform mobile framework
- **UraniumUI**: Modern UI library for MAUI
- **CommunityToolkit.Maui**: Additional controls and helpers
- **InputKit**: Enhanced input controls
- **MVVM Pattern**: Model-View-ViewModel architecture

## Project Structure

```
ARMauiApp/
├── Models/                 # Data Transfer Objects
│   ├── UserLoginDto.cs
│   ├── UserRegisterDto.cs
│   └── ProductDto.cs
├── Services/              # Business logic services
│   ├── AuthService.cs
│   └── ProductService.cs
├── ViewModels/            # MVVM ViewModels
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── ProductListViewModel.cs
│   └── ProductDetailViewModel.cs
├── Pages/                 # XAML pages
│   ├── LoginPage.xaml
│   ├── RegisterPage.xaml
│   ├── ProductListPage.xaml
│   ├── ProductDetailPage.xaml
│   └── AccountPage.xaml
├── Resources/             # App resources
│   ├── Styles/
│   │   ├── Colors.xaml
│   │   └── Styles.xaml
│   └── Images/
│       ├── shop.svg
│       └── user.svg
├── Converters/           # Value converters
│   └── CommonConverters.cs
└── Platforms/            # Platform-specific code
    └── Android/
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code with C# extension
- Android SDK (for Android development)

### Building and Running

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run on Android:**
   ```bash
   dotnet build -f net8.0-android
   ```

3. **For development with hot reload:**
   ```bash
   dotnet run --framework net8.0-android
   ```

### Authentication

The app includes a mock authentication system:
- **Default Login**: Use any email/password combination
- **Registration**: Creates a new mock user account
- **Navigation**: Successful login redirects to the main app

### Navigation Structure

- **Login/Register**: Initial authentication flow
- **Products Tab**: Browse and search products
- **Account Tab**: User profile and settings

## Key Components

### Services
- **AuthService**: Handles user authentication and session management
- **ProductService**: Manages product data and filtering

### UI Features
- **Validation**: Input validation using UraniumUI
- **Search**: Real-time product search functionality
- **Responsive Design**: Adapts to different screen sizes
- **Modern Icons**: SVG icons for tab navigation

## Development Notes

This project follows UraniumUI demo conventions and includes:
- Proper dependency injection setup
- MVVM data binding patterns
- Clean separation of concerns
- Modern MAUI app architecture

## License

This project uses only free and open-source packages:
- MIT licensed packages
- Official Microsoft .NET packages
