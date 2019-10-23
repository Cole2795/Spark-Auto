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
using Spark2Auto.Models.ViewModel;
using Spark2Auto.Utility;

namespace Spark2Auto.Pages.Services
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CarServiveViewModel CarServiceVM {get;set;}
        public  CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int carId)
        {
            CarServiceVM = new CarServiveViewModel
            {
                Car = await _db.Car.Include(c => c.ApplicationUser).FirstOrDefaultAsync(c => c.Id == carId),
                ServiceHeader = new Models.ServiceHeader()
            };
            List<string> lstServiceTypeInShoppingCart = _db.ServiceShoppingCart
                                                            .Include(c => c.ServiceType)
                                                            .Where(c => c.CardId == carId)
                                                            .Select(c => c.ServiceType.Name)
                                                            .ToList();

            IQueryable<ServiceType> lstService = from s in _db.ServiceType
                                                  where !(lstServiceTypeInShoppingCart.Contains(s.Name))
                                                  select s;

            CarServiceVM.ServiceTypesList = lstService.ToList();
            CarServiceVM.ServiceShoppingCartList = _db.ServiceShoppingCart.Include(c => c.ServiceType).Where(c => c.CardId == carId).ToList();
            CarServiceVM.ServiceHeader.TotalPrice = 0;

            foreach(var item in CarServiceVM.ServiceShoppingCartList)
            {
                CarServiceVM.ServiceHeader.TotalPrice += item.ServiceType.Price;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                CarServiceVM.ServiceHeader.DateAdded = DateTime.Now;
                CarServiceVM.ServiceShoppingCartList = _db.ServiceShoppingCart.Include(c => c.ServiceType).Where(c=> c.CardId == CarServiceVM.Car.Id).ToList();
                foreach(var item in CarServiceVM.ServiceShoppingCartList)
                {
                    CarServiceVM.ServiceHeader.TotalPrice += item.ServiceType.Price;
                }
                CarServiceVM.ServiceHeader.CarId = CarServiceVM.Car.Id;
                _db.ServiceHeader.Add(CarServiceVM.ServiceHeader);
                await _db.SaveChangesAsync();
                foreach(var detail in CarServiceVM.ServiceShoppingCartList)
                {
                    ServiceDetails serviceDetails = new ServiceDetails
                    {
                        ServiceHeaderId = CarServiceVM.ServiceHeader.Id,
                        ServiceName = detail.ServiceType.Name,
                        ServicePrice = detail.ServiceType.Price,
                        ServiceTypeId = detail.ServiceTypeId
                    };
                    _db.ServiceDetails.Add(serviceDetails);
                    
                }
                _db.ServiceShoppingCart.RemoveRange(CarServiceVM.ServiceShoppingCartList);
                await _db.SaveChangesAsync();
                return RedirectToPage("../Cars/Index", new { userId = CarServiceVM.Car.UserId });
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAddToCart()
        {
            ServiceShoppingCart objServiceCart = new ServiceShoppingCart()
            {
                CardId = CarServiceVM.Car.Id,
                ServiceTypeId = CarServiceVM.ServiceDetails.ServiceTypeId
            };
            _db.ServiceShoppingCart.Add(objServiceCart);
            await _db.SaveChangesAsync();
            return RedirectToPage("Create", new { CarId = CarServiceVM.Car.Id });
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int serviceTypId)
        {
            ServiceShoppingCart objServiceCart = _db.ServiceShoppingCart
                .FirstOrDefault(u => u.CardId == CarServiceVM.Car.Id && u.ServiceTypeId == serviceTypId);

            _db.ServiceShoppingCart.Remove(objServiceCart);
            await _db.SaveChangesAsync();
            return RedirectToPage("Create", new { CarId = CarServiceVM.Car.Id });
        }
    }
}