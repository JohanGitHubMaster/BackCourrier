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
    public class IndexModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public IndexModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }

        public IList<Coursier> Coursiers { get;set; } = default!;
        public Coursier Coursier { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            if (_context.Coursier != null)
            {
                Coursier = await _context.Coursier.Where(x=>x.Id== id).Include(x=>x.Courriers.Take(10)).ThenInclude(x=>x.Status).FirstOrDefaultAsync();
            }
        }


    }
}
