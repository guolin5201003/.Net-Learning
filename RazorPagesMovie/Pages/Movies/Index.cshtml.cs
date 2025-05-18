using  System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }

        public async Task<IActionResult> OnPostImportAsync(IFormFile importFile)
        {
            if (importFile == null || importFile.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select a file.");
                await OnGetAsync();
                return Page();
            }

            var movies = new List<Movie>();

            if (Path.GetExtension(importFile.FileName).ToLower() == ".csv")
            {
                using var reader = new StreamReader(importFile.OpenReadStream(), Encoding.UTF8);
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var columns = line.Split(',');
                    if (columns.Length < 4) continue;
                    movies.Add(new Movie
                    {
                        Title = columns[0],
                        ReleaseDate = DateTime.TryParse(columns[1], out var date) ? date : DateTime.Now,
                        Genre = columns[2],
                        Price = decimal.TryParse(columns[3], out var price) ? price : 0
                    });
                }
            }
            else if (Path.GetExtension(importFile.FileName).ToLower() == ".xlsx")
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using var stream = importFile.OpenReadStream();
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++) // 假设第一行为表头
                {
                    movies.Add(new Movie
                    {
                        Title = worksheet.Cells[row, 1].Text,
                        ReleaseDate = DateTime.TryParse(worksheet.Cells[row, 2].Text, out var date) ? date : DateTime.Now,
                        Genre = worksheet.Cells[row, 3].Text,
                        Price = decimal.TryParse(worksheet.Cells[row, 4].Text, out var price) ? price : 0
                    });
                }
            }

            if (movies.Count > 0)
            {
                _context.Movie.AddRange(movies);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
