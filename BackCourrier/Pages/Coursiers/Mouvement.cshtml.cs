using BackCourrier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackCourrier.Pages.Coursiers
{
    public class MouvementModel : PageModel
    {
        private readonly BackCourrier.Data.CourrierContext _context;

        public MouvementModel(BackCourrier.Data.CourrierContext context)
        {
            _context = context;
        }
        //public IList<Coursier> Coursier { get; set; } = default!;
        [BindProperty]
        public Models.Courriers Courrier { get; set; } = default!;

        public async Task OnGetAsync(int? courrierId)
        {
            Courrier = await _context.Courrier.FindAsync(courrierId);
        }
        public async Task<IActionResult> OnPostAsync(int? courrierId)
        {
            Courrier = await _context.Courrier.FindAsync(courrierId);
            if (Courrier != null && Courrier.StatusId == 2)
            {
                Courrier.StatusId = 3;
                MouvementCourrier m = new MouvementCourrier() { ReceptionisteId = Courrier.ReceptionisteId, DatedeMouvement = DateTime.Now, CourriersId = courrierId, StatusId = Courrier.StatusId };
                if (Courrier.MouvementCourriers == null) Courrier.MouvementCourriers = new List<MouvementCourrier>();
                Courrier.MouvementCourriers.Add(m);
                _context.Attach(Courrier).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index", new { id = Courrier.CoursierId });
            }

            return Page();
        }
    }
}
