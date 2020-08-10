using DeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel[] GetCustomers();

        CustomerModel GetCustomer(int customerId);

        CustomerModel CreateCustomer(BaseCustomerModel model);
    }
}
