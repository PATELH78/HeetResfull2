using AutoMapper;
using Heetapp1;
using Heetapp1.Interfaces;
using Heetapp1.Mappings;
using Heetapp1.Repositories;
using Heetapp1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("CustomerDb"));


builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
