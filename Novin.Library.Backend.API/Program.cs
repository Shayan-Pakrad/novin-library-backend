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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();




// Book CRUD

app.MapGet("/books/list", (BookService bookService) =>
{
    return Results.Ok(bookService.List());
});
app.MapPost("/books/add", (BookService bookService, BookAddOrUpdateDto book) =>
{
    bookService.Add(book);
});
app.MapPut("/books/update/{guid}", (BookService bookService, string guid, BookAddOrUpdateDto book) =>
{
    bookService.Update(guid, book);
});
app.MapDelete("/books/delete/{guid}", (BookService bookService, string guid) =>
{
    bookService.Remove(guid);
});




// Subscriber CRUD

app.MapGet("/subs/list", (SubscriberService subscriberService) =>
{
    return Results.Ok(subscriberService.List());
});
app.MapPost("/subs/add", (SubscriberService subscriberService, SubscriberAddOrUpdateDto sub) =>
{
    subscriberService.Add(sub);
});
app.MapPut("/subs/update/{guid}", (SubscriberService subscriberService, string guid, SubscriberAddOrUpdateDto sub) =>
{
    subscriberService.Update(guid, sub);
});
app.MapDelete("/subs/delete/{guid}", (SubscriberService subscriberService, string guid) =>
{
    subscriberService.Remove(guid);
});





// Borrow CRUD

app.MapGet("/borrows/list", (BorrowService borrowService) =>
{
    return Results.Ok(borrowService.List());
});
app.MapPost("/borrows/add", (BorrowService borrowService, BorrowAddOrUpdateDto borrow) =>
{
    borrowService.Add(borrow);
});
app.MapPut("/borrows/update/{guid}", (BorrowService borrowService, string guid, BorrowAddOrUpdateDto borrow) =>
{
    borrowService.Update(guid, borrow);
});
app.MapDelete("/borrows/delete/{guid}", (BorrowService borrowService, string guid) =>
{
    borrowService.Remove(guid);
});


app.Run();
