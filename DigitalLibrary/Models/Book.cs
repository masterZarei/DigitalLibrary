using DigitalLibrary.Models.Base;

namespace DigitalLibrary.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string? Translator { get; set; }
        public string? ImageUrl { get; set; }
        public string? FileUrl { get; set; }
        public string? Description { get; set; }
        public string? PublishDate { get; set; }
    }
}
