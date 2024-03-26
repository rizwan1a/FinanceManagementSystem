using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Owner { get; set; } = null!;
        public int TransactionLimit { get; set; } = 50000;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public virtual AccountType AccountType { get; set; } = null!;
        public int AccountTypeId { get; set; }

    }
}
