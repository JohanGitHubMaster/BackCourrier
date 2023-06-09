using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackCourrier.Data;
using BackCourrier.Models;

namespace BackCourrier.Pages.Coursiers
{
    public class CreateModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public CreateModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coursier Coursier { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Coursier == null || Coursier == null)
            {
                return Page();
            }

            _context.Coursier.Add(Coursier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
