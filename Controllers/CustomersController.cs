﻿using Course.Data;
using Course.Models;
using Course.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class CustomersController : Controller
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

        // GET: Customers
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include((c) => c.MembershipType).SingleOrDefault((c) => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
                Types = new SelectList(membershipTypes, "Id", "Name"),
                Customer = new Customer()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                var membershipTypes = _context.MembershipTypes.ToList();
                var viewModel = new NewCustomerViewModel
                {
                    MembershipTypes = membershipTypes,
                    Types = new SelectList(membershipTypes, "Id", "Name"),
                    Customer = customer
                };
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include((c) => c.MembershipType).SingleOrDefault((c) => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new EditCostumerViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes,
                Types = new SelectList(membershipTypes, "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            var customerInDb = _context.Customers.SingleOrDefault((c) => c.Id == customer.Id);

            if (customerInDb == null)
                return HttpNotFound();

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}