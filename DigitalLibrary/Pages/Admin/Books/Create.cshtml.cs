using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        #region Upload
        [BindProperty]
        public IFormFile ImgUp { get; set; }

        [BindProperty]
        public IFormFile FileUp { get; set; }
        #endregion

        #region DropDown
        public SelectList Options { get; set; }
        [BindProperty]
        public string SelectedOption { get; set; }
        #endregion


        public void OnGet()
        {
            initCats();
        }
        void initCats()
        {
            Options = new SelectList(_db.Categories, nameof(Category.Id), nameof(Category.Name));

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
