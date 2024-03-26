using D2Soft.Application.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
        public IAccount Account { get; set; }
        public IAccountType AccountType { get; set; }
    }
}
