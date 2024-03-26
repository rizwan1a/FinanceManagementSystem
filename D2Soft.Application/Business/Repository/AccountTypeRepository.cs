using D2Soft.Application.Business.GenericImplementation;
using D2Soft.Application.Business.Interfaces;
using D2Soft.Domain.Entities;
using D2Soft.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.Repository
{
    public class AccountTypeRepository : GenericRepository<AccountType>, IAccountType
    {
        private readonly ApplicationDbContext _context;
        public AccountTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<int> GetAllAccountTypeIds()
        {
            var accountTypeIds = _context.AccountTypes.Select(x => x.Id).ToList();
            return accountTypeIds;
        }
    }
}
