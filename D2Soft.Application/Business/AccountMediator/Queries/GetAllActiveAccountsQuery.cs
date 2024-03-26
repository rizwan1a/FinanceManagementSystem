using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.AccountMediator.Queries
{
    public class GetAllActiveAccountsQuery:IRequest<List<AccountDTO>>
    {
    }
}
