using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Video.Models;
using Video.ViewModels;

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

        public ActionResult New()
        {
            var viewModel = new NewCustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }
    }
}
