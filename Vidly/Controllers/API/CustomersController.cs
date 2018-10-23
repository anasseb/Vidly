using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;
using System;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers : get all customers
        public IEnumerable<CustomerDto> GetCustomer()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/id : get one customer by id
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST api/customer : save customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT api/customer/id : Edit customer by id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerIndb = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customerIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //customerIndb.Name = customer.Name;
            //customerIndb.BirthDay = customer.BirthDay;
            //customerIndb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerIndb.MembershipTypeId = customer.MembershipTypeId;

            Mapper.Map(customerDto, customerIndb);

            _context.SaveChanges();
        }

        //DELETE api/customer/id : Delete customer by id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerIndb = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customerIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerIndb);
            _context.SaveChanges();
        }
    }
}
