using AutoMapper;
using D2Soft.Application.Business.AccountMediator.Commands;
using D2Soft.Application.Business.AccountMediator.Queries;
using D2Soft.Application.Business.UnitOfWork;
using D2Soft.Application.Helper;
using D2Soft.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(typeof(GetAllActiveAccountsQuery));
//builder.Services.AddMediatR(typeof(AddAccountCommand));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
