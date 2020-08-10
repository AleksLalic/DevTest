using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedJob = context.Add(new Customer
            {
                Name = model.Name,
                Type = model.Type
            });

            context.SaveChanges();

            return new CustomerModel
            {
                CustomerId = addedJob.Entity.CustomerId,
                Name = addedJob.Entity.Name,
                Type = addedJob.Entity.Type
            };
        }
    

        public CustomerModel GetCustomer(int customerId)
        {
            return context.Customers.Where(x => x.CustomerId == customerId).Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Type = x.Type
            }).SingleOrDefault();
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Type = x.Type
            }).ToArray();
        }
    }
}
