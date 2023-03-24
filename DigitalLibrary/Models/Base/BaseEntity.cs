namespace DigitalLibrary.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; }
    }
}
