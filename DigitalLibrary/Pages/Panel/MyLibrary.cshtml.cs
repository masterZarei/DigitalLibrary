using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Pages.Panel
{
    [Authorize]
    public class MyLibraryModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public MyLibraryModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public List<DownloadedBook> DBooks { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var user = await _db.Users.FirstOrDefaultAsync(a => a.UserName == User.Identity.Name);

            DBooks = _db.DownloadedBooks
                 .Include(a => a.Book)
                 .Where(a => a.userId == user.Id).ToList();

            return Page();
        }
    }
}
