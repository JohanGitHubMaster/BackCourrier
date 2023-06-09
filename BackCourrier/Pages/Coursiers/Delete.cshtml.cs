using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackCourrier.Data;
using BackCourrier.Models;

namespace BackCourrier.Pages.Coursiers
{
    public class DeleteModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public DeleteModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coursier Coursier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coursier == null)
            {
                return NotFound();
            }

            var coursier = await _context.Coursier.FirstOrDefaultAsync(m => m.Id == id);

            if (coursier == null)
            {
                return NotFound();
            }
            else 
            {
                Coursier = coursier;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coursier == null)
            {
                return NotFound();
            }
            var coursier = await _context.Coursier.FindAsync(id);

            if (coursier != null)
            {
                Coursier = coursier;
                _context.Coursier.Remove(Coursier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
