using BackCourrier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackCourrier.Pages.Coursiers
{
    public class LoginModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public LoginModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }
        //public IList<Coursier> Coursier { get; set; } = default!;
        [BindProperty]
        public Coursier Coursier { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Coursier != null)
            {
               // Coursier = await _context.Coursier.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ( _context.Coursier.Where(x=>x.Nom == Coursier.Nom).Count()>0)
                    {
                       var s = await _context.Coursier.Where(x => x.Nom == Coursier.Nom).FirstOrDefaultAsync();
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
