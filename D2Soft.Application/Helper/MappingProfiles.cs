using AutoMapper;
using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();
        }
    }
}
