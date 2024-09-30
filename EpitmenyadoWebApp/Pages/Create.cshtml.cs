using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpitmenyadoWebApp.Models;

namespace EpitmenyadoWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.BuildingDbContext _context;

        public CreateModel(EpitmenyadoWebApp.Models.BuildingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Building Building { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Epitmenyek.Add(Building);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
