using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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