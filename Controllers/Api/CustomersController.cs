using AutoMapper;
using Course.Data;
using Course.DTOs;
using Course.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Course.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include((customer) => customer.MembershipType);

            if (!string.IsNullOrEmpty(query))
                customersQuery = customersQuery.Where((customer) 
                    => customer.Name.ToUpper().Contains(query.ToUpper()));

            var customersDTO = customersQuery.
                ToList().
                Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customersDTO);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include((c) => c.MembershipType).
                SingleOrDefault((c) => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault((c) => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault((c) => c.Id == id);

            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }

    }
}
