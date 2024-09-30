using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpitmenyadoWebApp.Models;

namespace EpitmenyadoWebApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.BuildingDbContext _context;

        public DetailsModel(EpitmenyadoWebApp.Models.BuildingDbContext context)
        {
            _context = context;
        }

        public Building Building { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Epitmenyek.FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            else
            {
                Building = building;
            }
            return Page();
        }
    }
}
