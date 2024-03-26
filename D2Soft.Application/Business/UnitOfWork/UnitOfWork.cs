using AutoMapper;
using D2Soft.Application.Business.Interfaces;
using D2Soft.Application.Business.Repository;
using D2Soft.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Account = new AccountRepository(_context, _mapper);
            AccountType = new AccountTypeRepository(_context);
        }
        public IAccount Account { get; set; }
        public IAccountType AccountType { get; set; }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
