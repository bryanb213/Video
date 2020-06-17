using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Video.Models;

namespace Video.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext dbContext;

        public CustomersController(AppDbContext context)
        {
            dbContext = context;
        }

        
        public ActionResult Index()
        {
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }

        [HttpGet("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return null;

            return View(customer);
        }
    }
}
