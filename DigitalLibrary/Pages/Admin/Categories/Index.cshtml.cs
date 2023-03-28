using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalLibrary.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _db.Categories
                .OrderByDescending(a => a.CreateDate)
                .ToList();
        }
    }
}
