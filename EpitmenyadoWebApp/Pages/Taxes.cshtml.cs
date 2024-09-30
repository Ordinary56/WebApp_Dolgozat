using EpitmenyadoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EpitmenyadoWebApp.Pages
{
    public class Tax
    {
        public int TaxNum { get; set; }
        public int TotalTax { get; set; }
    }

    public class TaxesModel : PageModel
    {
        BuildingDbContext _context;
        [BindProperty]
        public List<Tax> Taxes { get; set; } = [];
        public async void OnGetAsync()
        {
            List<Building> buildings = await _context.Epitmenyek.ToListAsync();
            int[] numbers = buildings.Select(x => x.TaxNumber).Distinct().ToArray();
            foreach(var num in numbers)
            {
                Tax tax = new Tax() { TaxNum = num};
                Taxes.Add(tax);
            }
            for(int i = 0; i < Taxes.Count; i++)
            {
                var AllBuildings = buildings.Where(x => x.TaxNumber == Taxes[i].TaxNum).ToList();
                int A_Line = AllBuildings.Where(x => x.Line == 'A').Sum(x => x.Area * 800);
                int B_Line = AllBuildings.Where(x => x.Line == 'B').Sum(x => x.Area * 600);
                int C_Line = AllBuildings.Where(x => x.Line == 'C').Sum(x => x.Area * 100);
                int Sum = A_Line + B_Line + C_Line;
                Taxes[i].TotalTax = Sum < 10_000 ? 0 : Sum;
            }
        }
        public TaxesModel(BuildingDbContext context)
        {
            _context = context;
        }
    }
}
