using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Pages.Admin.Books
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FindAsync(id);

            if (Book != null)
            {


                string ImagedeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", Book.ImageUrl);
                if (System.IO.File.Exists(ImagedeletePath))
                {
                    System.IO.File.Delete(ImagedeletePath);
                }

                string FiledeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/", Book.FileUrl);
                if (System.IO.File.Exists(FiledeletePath))
                {
                    System.IO.File.Delete(FiledeletePath);
                }


                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
