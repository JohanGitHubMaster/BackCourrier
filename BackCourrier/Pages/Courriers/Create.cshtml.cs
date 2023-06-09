﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackCourrier.Data;
using BackCourrier.Models;

namespace BackCourrier.Pages.Courriers
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
        ViewData["CoursierId"] = new SelectList(_context.Coursier, "Id", "Nom");
        ViewData["FlagId"] = new SelectList(_context.Flag, "Id", "Type");
        ViewData["ReceptionisteId"] = new SelectList(_context.Receptioniste, "Id", "Nom");
        ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Type");
        ViewData["DestinataireId"] = new SelectList(_context.Destinataire, "Id", "Nom");
        return Page();
        }
        
        [BindProperty]
        public Models.Courriers Courriers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          var dest =  Request.Form["destinataires"];
          if (!ModelState.IsValid || _context.Courrier == null || Courriers == null)
            {
                return Page();
            }
            if (Courriers.CourrierDestinataires == null) Courriers.CourrierDestinataires = new List<CourrierDestinataire>();
          foreach(var d in dest)
            {
                
                Courriers.CourrierDestinataires.Add(new CourrierDestinataire() { CourrierId = Courriers.Id, DestinataireId = Int32.Parse(d) });
            }
            _context.Courrier.Add(Courriers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
