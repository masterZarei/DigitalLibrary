using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalLibrary.Pages.Admin.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public IFormFile? ImgUp { get; set; }

        [BindProperty]
        public IFormFile? FileUp { get; set; }

        public IActionResult OnGet(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Book = _db.Books.FirstOrDefault(a => a.Id == Id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImgUp != null)
            {

                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", Book.ImageUrl);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }



                string saveDir = "wwwroot/Images";
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                Book.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, Book.ImageUrl);
                using (var filestream = new FileStream(savepath, FileMode.Create))
                {
                    ImgUp.CopyTo(filestream);
                }
            }
            if (FileUp != null)
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/", Book.FileUrl);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }


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


            _db.Update(Book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
