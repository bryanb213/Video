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

        public ActionResult New()
        {
            var viewModel = new NewCustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerFormViewModel
                {
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            {
                dbContext.Customers.Add(customer);
            }
            else
            {
                var cInDb = dbContext.Customers.Single(s => s.Id == customer.Id);
                cInDb.Name = customer.Name;
                cInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                cInDb.Birthdate = customer.Birthdate;
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return Content("Not found");

            var viewModel = new NewCustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }
        [HttpGet("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(m => m.Id == id);

            if (customer == null)
            {
                return Content("Not Found");
            }

            dbContext.Remove(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}
