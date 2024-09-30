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
    public class IndexModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.BuildingDbContext _context;

        public IndexModel(EpitmenyadoWebApp.Models.BuildingDbContext context)
        {
            _context = context;
        }

        public IList<Building> Building { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Building = await _context.Epitmenyek.ToListAsync();
        }
    }
}
