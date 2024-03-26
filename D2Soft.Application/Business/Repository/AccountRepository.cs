using AutoMapper;
using D2Soft.Application.Business.GenericImplementation;
using D2Soft.Application.Business.Interfaces;
using D2Soft.Application.DTOs;
using D2Soft.Application.Validators;
using D2Soft.Domain.Entities;
using D2Soft.Infrastructure;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccount
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AccountRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AccountDTO>> GetAllActiveAccounts()
        {
            var accounts = await _context.Accounts.Where(x => x.IsActive && x.IsDeleted == false).ToListAsync();
            return (accounts.Select(_mapper.Map<AccountDTO>).ToList());
        }

        public void DeleteAccount(Account account)
        {
            account.IsDeleted = true;
            _context.Accounts.Update(account);
        }

        public Account MapToAccount(AccountDTO accountDTO)
        {
            var account = _mapper.Map<Account>(accountDTO);
            return account;
        }

        public AccountDTO MapToAccountDTO(Account account)
        {
            var accountDTO = _mapper.Map<AccountDTO>(account);
            return accountDTO;
        }

        public List<ValidationFailure> Validate(AccountDTO accountDTO)
        {
            var accountTypeIds = _context.AccountTypes.Select(x => x.Id).ToList();
            var validationFailure = new List<ValidationFailure>();

            var validator = new AccountValidator();
            var validationResult = validator.Validate(accountDTO);
            if (!validationResult.IsValid)
            {
                validationFailure = validationResult.Errors.ToList();
            }
            if (!accountTypeIds.Contains(accountDTO.AccountTypeId))
            {
                var error = new ValidationFailure("", $"No Foreign Key exists for accountType {accountDTO.AccountTypeId}");
                validationFailure.Add(error);
            }
            return validationFailure;

        }
    }
}
