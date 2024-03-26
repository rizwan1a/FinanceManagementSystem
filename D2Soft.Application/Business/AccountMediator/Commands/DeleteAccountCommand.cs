using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.AccountMediator.Commands
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
