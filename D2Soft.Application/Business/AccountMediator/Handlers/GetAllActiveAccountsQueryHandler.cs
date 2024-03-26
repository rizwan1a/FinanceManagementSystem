using D2Soft.Application.Business.AccountMediator.Queries;
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
    public class GetAllActiveAccountsQueryHandler : IRequestHandler<GetAllActiveAccountsQuery, List<AccountDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllActiveAccountsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountDTO>> Handle(GetAllActiveAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Account.GetAllActiveAccounts();
        }
    }
}
