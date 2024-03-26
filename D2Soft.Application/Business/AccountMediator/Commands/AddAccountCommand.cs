using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.AccountMediator.Commands
{
    public class AddAccountCommand : IRequest<AccountDTO>
    {
        public AccountDTO Account { get; set; }
    }
}
