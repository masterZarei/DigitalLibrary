using DigitalLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalLibrary.Pages.Panel
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string FullName { get; set; }
        public IActionResult OnGet()
        {
            FullName = _db.Users.FirstOrDefault(a => a.UserName == User.Identity.Name).FullName;
            return Page();
        }
    }
}
