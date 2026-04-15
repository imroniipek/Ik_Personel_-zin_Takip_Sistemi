using Microsoft.EntityFrameworkCore;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Application.Extension;
using Personel.Personel.Application.Features.Department.CreateDepartment;

using Personel.Personel.Infrastucture.Context;
using Personel.Personel.Infrastucture.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonelDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateDepartmentCommandHandler).Assembly);
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPersonelEndpoints();

app.Run();