using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Pages.Admin.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Category Category { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Category = await _db.Categories.FirstOrDefaultAsync(a => a.Id == Id);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
