﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _db.Car.FindAsync(id);

            if (Car != null)
            {
                _db.Car.Remove(Car);
                await _db.SaveChangesAsync();
                StatusMessage = "Car has been deleted sucessfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}