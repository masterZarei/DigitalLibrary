using DigitalLibrary.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibrary.Models
{
    public class DownloadedBook : BaseEntity
    {
        public int? BookId { get; set; }
        public string? userId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        [ForeignKey("userId")]
        public User? User { get; set; }
    }
}
