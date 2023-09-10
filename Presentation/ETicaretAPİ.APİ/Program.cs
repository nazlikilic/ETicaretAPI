using ETicaretAP�.AP�.Filters;
using ETicaretAP�.AP�.MiddleWares;
using ETicaretAP�.Apllication.Mapping;
using ETicaretAP�.Apllication.Repositories;
using ETicaretAP�.Apllication.Services;
using ETicaretAP�.Apllication.UnitOfWorks;
using ETicaretAP�.Domain.Entities;
using ETicaretAP�.�nsfrastructure.AppDbContexts;
using ETicaretAP�.Persistence.Repositories;
using ETicaretAP�.Persistence.Services;
using ETicaretAP�.Persistence.UnitOfWorks;
using ETicaretAP�.Persistence.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {options.Filters.Add(new ValidaterFilterAttribute()); }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContextProduct>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"), option =>
    {
        _ = option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContextProduct)).GetName().Name);
    });

});

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContextProduct>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomeException();

app.UseAuthorization();

app.MapControllers();

app.Run();
