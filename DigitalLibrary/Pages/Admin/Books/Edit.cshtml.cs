using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        #region DropDown
        public SelectList Options { get; set; }
        [BindProperty]
        public string SelectedOption { get; set; }
        #endregion


        public IActionResult OnGet(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Book = _db.Books
                .Include(a => a.Category)
                .FirstOrDefault(a => a.Id == Id);
            if (Book == null)
            {
                return NotFound();
            }
            initCats();
            return Page();
        }
        void initCats()
        {
            Options = new SelectList(_db.Categories, nameof(Category.Id), nameof(Category.Name), Book.CategoryId);

        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(SelectedOption))
            {
                initCats();
                return Page();
            }

            int catId = Convert.ToInt32(SelectedOption);
            Category category = _db.Categories.Find(catId);
            if (category == null)
            {
                return NotFound();
            }
            Book.CategoryId = catId;

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
