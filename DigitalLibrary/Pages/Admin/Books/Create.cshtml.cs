using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalLibrary.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public IFormFile ImgUp { get; set; }

        [BindProperty]
        public IFormFile FileUp { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImgUp != null)
            {
                string saveDir = "wwwroot/Images";
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                Book.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Book.ImageUrl);
                using(var filestream = new FileStream(savepath, FileMode.Create))
                {
                    ImgUp.CopyTo(filestream);
                }
            }
            if (FileUp != null)
            {
                string saveDir = "wwwroot/Files";
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                Book.FileUrl = Guid.NewGuid().ToString() + Path.GetExtension(FileUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Book.FileUrl);
                using (var filestream = new FileStream(savepath, FileMode.Create))
                {
                    FileUp.CopyTo(filestream);
                }
            }

            await _db.AddAsync(Book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
