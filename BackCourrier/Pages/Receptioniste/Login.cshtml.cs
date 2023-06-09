using BackCourrier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackCourrier.Pages.Receptioniste
{
    public class LoginModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public LoginModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Receptioniste Receptioniste { get; set; } = default!;
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_context.Receptioniste.Where(x => x.Nom == Receptioniste.Nom).Count() > 0)
                    {
                        var s = await _context.Receptioniste.Where(x => x.Nom == Receptioniste.Nom).FirstOrDefaultAsync();
                        return RedirectToPage("./Index", new { id = s.Id });

                    }
                }
            }
            catch (Exception)
            {

            }

            return Page();
        }
    }
}
