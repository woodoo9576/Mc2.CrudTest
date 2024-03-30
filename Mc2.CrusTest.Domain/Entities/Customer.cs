using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Common.Entities;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public long BankAccountNumber { get; set; }

    }
}
