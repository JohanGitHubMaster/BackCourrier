using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackCourrier.Data;
using BackCourrier.Models;

namespace BackCourrier.Pages.Coursiers
{
    public class EditModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public EditModel(BackCourrier.Data.CourrierContext context)
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

            var coursier =  await _context.Coursier.FirstOrDefaultAsync(m => m.Id == id);
            if (coursier == null)
            {
                return NotFound();
            }
            Coursier = coursier;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coursier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursierExists(Coursier.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoursierExists(int? id)
        {
          return (_context.Coursier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
