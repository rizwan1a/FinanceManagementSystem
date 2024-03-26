using AutoMapper;
using D2Soft.Application.Business.AccountMediator.Commands;
using D2Soft.Application.Business.UnitOfWork;
using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.AccountMediator.Handlers
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, AccountDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AccountDTO> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var checkValidation = _unitOfWork.Account.Validate(request.Account);
            if (checkValidation.Count > 0)
            {
                string errorMessage = string.Join(Environment.NewLine, checkValidation);
                throw new Exception(errorMessage);
            }
            var account = _unitOfWork.Account.MapToAccount(request.Account);
            if (account.Id == 0)
            {
                _unitOfWork.Account.AddEntity(account);
            }
            else
            {
                _unitOfWork.Account.UpdateEntity(account);
            }
            await _unitOfWork.SaveChanges();
            return _unitOfWork.Account.MapToAccountDTO(account);
        }
    }
}
