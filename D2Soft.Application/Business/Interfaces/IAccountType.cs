using D2Soft.Application.Business.GenericImplementation;
using D2Soft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.Interfaces
{
    public interface IAccountType : IGeneric<AccountType>
    {
        List<int> GetAllAccountTypeIds();
    }
}
