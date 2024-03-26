using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Domain.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
