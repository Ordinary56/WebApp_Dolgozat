using EpitmenyadoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EpitmenyadoWebApp.Pages
{
    public class UploadStreetFileModel : PageModel
    {
        BuildingDbContext _context;
        IWebHostEnvironment _env;
        [BindProperty]
        public IFormFile Upload { get; set; } = default!;
        public void OnGet()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        public UploadStreetFileModel(IWebHostEnvironment env, BuildingDbContext context)
        {
            _env = env;
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Upload is null)
            {
                return BadRequest("Error, file is invalid or nothing has been uploaded");
            }
            string uploadDirPath = Path.Combine(_env.ContentRootPath, "uploads");
            string uploadPath = Path.Combine(uploadDirPath, Upload!.FileName);
            FileStream stream = null;
            if (Path.Exists(uploadPath))
            {
                stream = new(uploadPath, FileMode.Append);
            }
            else
            {
                stream = new(uploadPath, FileMode.Create);
            }
            string? line = "";
            string[] lines;
            await Upload!.CopyToAsync(stream);
            stream.Close();
            await stream.DisposeAsync();
            using StreamReader sr = new(uploadPath);
            await sr.ReadLineAsync();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                lines = line!.Split(' ');
                if (line is null || lines.Length < 4) break;
                Building building = new()
                {
                    TaxNumber = int.Parse(lines[0]),
                    StreetName = lines[1],
                    StreetNum = lines[2],
                    Line = lines[3].First(),
                    Area = int.Parse(lines[4])
                };
                await _context.Epitmenyek.AddAsync(building);
            }
            await _context.SaveChangesAsync();
            return Page();
        } // Post
    } // Class

} // namespace


