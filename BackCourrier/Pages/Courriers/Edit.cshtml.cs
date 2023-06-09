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

namespace BackCourrier.Pages.Courriers
{
    public class EditModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public EditModel(BackCourrier.Data.CourrierContext context)
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

            var courriers =  await _context.Courrier.FirstOrDefaultAsync(m => m.Id == id);
            if (courriers == null)
            {
                return NotFound();
            }
            Courriers = courriers;
           ViewData["CoursierId"] = new SelectList(_context.Coursier, "Id", "Id");
           ViewData["FlagId"] = new SelectList(_context.Flag, "Id", "Id");
           ViewData["ReceptionisteId"] = new SelectList(_context.Receptioniste, "Id", "Id");
           ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
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

            _context.Attach(Courriers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourriersExists(Courriers.Id))
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

        private bool CourriersExists(int id)
        {
          return (_context.Courrier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
