using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackCourrier.Data;
using BackCourrier.Models;

namespace BackCourrier.Pages.Courriers
{
    public class DeleteModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public DeleteModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Courriers Courriers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courrier == null)
            {
                return NotFound();
            }

            var courriers = await _context.Courrier.FirstOrDefaultAsync(m => m.Id == id);

            if (courriers == null)
            {
                return NotFound();
            }
            else 
            {
                Courriers = courriers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Courrier == null)
            {
                return NotFound();
            }
            var courriers = await _context.Courrier.FindAsync(id);

            if (courriers != null)
            {
                Courriers = courriers;
                _context.Courrier.Remove(Courriers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
