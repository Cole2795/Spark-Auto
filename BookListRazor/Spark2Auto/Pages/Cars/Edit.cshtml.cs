using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spark2Auto.Data;
using Spark2Auto.Models;

namespace Spark2Auto.Pages.Cars
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car Car { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _db.Car.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var CarFromDb = await _db.Car.FirstOrDefaultAsync(s => s.Id == Car.Id);

            CarFromDb.VIN = Car.VIN;
            CarFromDb.Make = Car.Make;
            CarFromDb.Model = Car.Model;
            CarFromDb.Style = Car.Style;
            CarFromDb.Year = Car.Year;
            CarFromDb.Miles = Car.Miles;
            CarFromDb.Make = Car.Color;
            await _db.SaveChangesAsync();
            StatusMessage = "Car has been updated sucessfully.";
            return RedirectToPage("./Index");
        }


    }
}