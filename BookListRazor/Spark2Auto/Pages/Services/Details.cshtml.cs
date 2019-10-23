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

namespace Spark2Auto.Pages.Services
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public ServiceHeader ServiceHeader { get; set; }
        public List<ServiceDetails>  ServiceDetails { get; set; }
        public void OnGet(int serviceId)
        {
            ServiceHeader = _db.ServiceHeader.Include(s => s.Car).Include(s => s.Car.ApplicationUser).FirstOrDefault(s => s.Id == serviceId);
            ServiceDetails = _db.ServiceDetails.Where(s => s.ServiceHeaderId == serviceId).ToList();
        }
    }
}