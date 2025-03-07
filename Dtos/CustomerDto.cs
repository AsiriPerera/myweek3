using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Models;

namespace Week3EntityFramework.Dtos
{
    internal class CustomerDto
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public CustomerDto(Customer customer) 
        {
            CustomerFirstName = customer?.FirstName;
            CustomerLastName = customer?.LastName;
        }
    }
}
