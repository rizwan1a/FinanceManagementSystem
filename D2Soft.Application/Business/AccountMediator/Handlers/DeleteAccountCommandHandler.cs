using D2Soft.Application.Business.AccountMediator.Commands;
using D2Soft.Application.Business.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.AccountMediator.Handlers
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Account.FindById(request.Id);
            if (account == null)
            {
                throw new Exception($"Account with ID {request.Id} not found.");
            }
            _unitOfWork.Account.DeleteAccount(account);
            await _unitOfWork.SaveChanges();
            return Unit.Value;
        }
    }
}
