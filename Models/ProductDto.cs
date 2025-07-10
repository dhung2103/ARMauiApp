namespace ARMauiApp.Models
{
    public class ProductDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string? Model3DUrl { get; set; }
        public List<string> Sizes { get; set; } = new List<string>();
        public string CategoryId { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
