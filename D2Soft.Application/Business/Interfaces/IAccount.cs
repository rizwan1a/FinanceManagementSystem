using D2Soft.Application.Business.GenericImplementation;
using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.Interfaces
{
    public interface IAccount : IGeneric<Account>
    {
        Task<List<AccountDTO>> GetAllActiveAccounts();
        void DeleteAccount(Account account);
        Account MapToAccount(AccountDTO accountDTO);
        AccountDTO MapToAccountDTO(Account account);
        List<ValidationFailure> Validate(AccountDTO accountDTO);
    }
}
