using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Pages
{
    public class BookDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public BookDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Book = await _db.Books
                .Include(a=>a.Category)
                .FirstOrDefaultAsync(a => a.Id == Id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/Identity/Account/Login?ReturnUrl=/BookDetails?Id={Book.Id}");
            }

            var user = _db.Users.FirstOrDefaultAsync(a => a.UserName == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }





            return Redirect($"/Files/{Book.FileUrl}");
        }
    }
}
