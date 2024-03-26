using D2Soft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Owner { get; set; } = null!;
        public int TransactionLimit { get; set; }
        public int AccountTypeId { get; set; }
    }
}
