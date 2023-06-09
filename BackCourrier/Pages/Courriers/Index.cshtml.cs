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
    public class IndexModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public IndexModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }

        public IList<Models.Courriers> Courriers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courrier != null)
            {
                Courriers = await _context.Courrier
                .Include(c => c.Coursier)
                .Include(c => c.Flag)
                .Include(c => c.Receptioniste)
                .Include(c => c.Status).Take(100).ToListAsync();
            }
        }
    }
}
