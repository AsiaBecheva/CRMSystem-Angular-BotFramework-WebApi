﻿using System;
using System.Linq;
using CRMSystem.Data;
using CRMSystem.DTOModels.Models;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Server.Controllers
{
    //[Authorize(Roles = "Employees", Policy = "OnlyEmployees")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CRMDbContext db;

        public CustomersController(CRMDbContext db)
        {
            this.db = db;
        }

        public IActionResult Get()
        {
            var customers = this.db
                .Customers
                .ToList();

            return this.Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = db.Customers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                return this.NotFound("There is no customer with such ID!");
            }

            return this.Ok(customer);
        }


        [HttpPost]
        public IActionResult Post([FromBody]CustomerDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Customer customer = new Customer
            {
                Username = model.Username,
                Company = model.Company,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Email = model.Email,
                Phone = model.Phone,
                Status = model.Status,
                AddedOn = DateTime.Now
            };

            this.db.Customers.Add(customer);
            this.db.SaveChanges();

            return this.Created(this.Url.ToString(), customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CustomerDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var customerForUpdate = this.db.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customerForUpdate == null)
            {
                return BadRequest("There is no customer with such ID!");
            }

            customerForUpdate.Username = model.Username;
            customerForUpdate.Company = model.Company;
            customerForUpdate.FirstName = model.FirstName;
            customerForUpdate.LastName = model.LastName;
            customerForUpdate.Address = model.Address;
            customerForUpdate.Email = model.Email;
            customerForUpdate.City = model.City;
            customerForUpdate.Phone = model.Phone;
            customerForUpdate.Status = model.Status;

            this.db.Customers.Update(customerForUpdate);
            this.db.SaveChanges();

            return this.Ok(customerForUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerForDelete = this.db.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customerForDelete == null)
            {
                return this.BadRequest();
            }

            this.db.Customers.Remove(customerForDelete);

            return this.Ok("Customer was deleted!");
        }
    }
}
