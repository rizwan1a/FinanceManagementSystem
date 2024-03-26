using D2Soft.Application.Business.UnitOfWork;
using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Validators
{
    public class AccountValidator : AbstractValidator<AccountDTO>
    {
        public AccountValidator()
        {
            RuleFor(account => account.AccountNumber)
           .NotEmpty().WithMessage("Account number is required.")
           .Must(BeExactlyEightDigits).WithMessage("Account number must be exactly 8 digits long.");

            RuleFor(account => account.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to zero.");

            RuleFor(account => account.Owner)
                .NotEmpty().WithMessage("Owner is required.");

            RuleFor(account => account.TransactionLimit)
                .GreaterThanOrEqualTo(50000).WithMessage("Transaction limit must be greater than or equal to 50000.");

            RuleFor(account => account.AccountTypeId)
                .NotEmpty().WithMessage("Account type ID is required.");

        }


        private bool BeExactlyEightDigits(int accountNumber)
        {
            return accountNumber >= 10000000 && accountNumber <= 99999999;
        }
    }
}
