using DigitalLibrary.Models.Base;

namespace DigitalLibrary.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Book>? Book { get; set; }
    }
}
