using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.DTOs.Borrows;
using Novin.Library.Backend.API.DTOs.Subscribers;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Repositories;
using Novin.Library.Backend.API.Services;
using Novin.Library.Backend.API.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Subscriber>, SubscriberRepository>();
builder.Services.AddScoped<IRepository<Borrow>, BorrowRepository>();
builder.Services.AddScoped<BookService, BookService>();
builder.Services.AddScoped<SubscriberService, SubscriberService>();
builder.Services.AddScoped<BorrowService, BorrowService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
