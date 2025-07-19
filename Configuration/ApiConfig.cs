namespace ARMauiApp.Configuration
{
    public static class ApiConfig
    {
        public const string BaseUrl = "https://ar-project-api-v258.onrender.com/api/";
        
        // API Endpoints
        public static class Endpoints
        {
            public const string Categories = "v1/Category";
            public const string Products = "v1/Product";
            public const string Health = "health";
        }
        
        // HTTP Client configuration
        public static class HttpClient
        {
            public const int TimeoutSeconds = 30;
            public const int RetryCount = 3;
        }

        // API Response configuration
        public static class Response
        {
            public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}
