using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewCustomer()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipType
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("NewCustomer", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.First(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("CustomersList", "Customers");
        }

        public ActionResult CustomersEdit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("NewCustomer", viewModel);
        }

        [Route("Customers/CustomersList")]
        public ActionResult CustomersList()
        {
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }

        [Route("Customers/CustomersDetails/{id}")]
        public ActionResult CustomersDetails(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer{Name = "Anass", Id = 1},
        //        new Customer{Name = "Karima", Id = 2 }
        //    };

        //    return customers;
        //}

        public class MyDbContext : DbContext
        {
            public MyDbContext()
            {
            }
        }
    }
}