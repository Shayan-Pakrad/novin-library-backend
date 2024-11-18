using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Novin.Library.Backend.API.DbContexts;
using Novin.Library.Backend.API.DTOs.Books;
using Novin.Library.Backend.API.Entities;
using Novin.Library.Backend.API.Interfaces;
using Novin.Library.Backend.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library"));
});

builder.Services.AddScoped<IRepository<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IRepository<Subscriber>, SubscriberRepository>();
builder.Services.AddScoped<IRepository<Borrow>, BorrowRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();




// Book CRUD

app.MapGet("/books/list", (IRepository<Book> repository) =>
{
    return Results.Ok(repository.GetAll()
    .Select(b=>new BookDto
    {
        Guid = b.Guid,
        Title = b.Title,
        Author = b.Author,
        Price = b.Price
    })
    .ToList());
});
app.MapPost("/books/add", (IRepository<Book> repository, BookAddOrUpdateDto book) =>
{
    var b = new Book{
        Title = book.Title,
        Author = book.Author,
        Price = book.Price
    };
    repository.Add(b);
});
app.MapPut("/books/update/{guid}", (IRepository<Book> repository, string guid, BookAddOrUpdateDto book) =>
{
    var dbBook = repository.GetByGuid(guid);
    if (dbBook != null)
    {
        dbBook.Author = book.Author;
        dbBook.Price = book.Price;
        dbBook.Title = book.Title;
        repository.Update(dbBook);
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/books/delete/{guid}", (IRepository<Book> repository, string guid) =>
{
    var dbBook = repository.GetByGuid(guid);
    if (dbBook != null)
    {
        repository.Remove(dbBook);
        return Results.Ok();
    }
    return Results.NotFound();
});




// Subscriber CRUD

app.MapGet("/subs/list", (IRepository<Subscriber> repository) =>
{
    return Results.Ok(repository.GetAll().ToList());
});
app.MapPost("/subs/add", (IRepository<Subscriber> repository, Subscriber sub) =>
{
    repository.Add(sub);
});
app.MapPut("/subs/update/{guid}", (IRepository<Subscriber> repository, string guid, Subscriber sub) =>
{
    var dbSub = repository.GetByGuid(guid);
    if (dbSub != null)
    {
        dbSub.Address = sub.Address;
        dbSub.Fullname = sub.Fullname;
        dbSub.PhoneNumber = sub.PhoneNumber;
        repository.Update(dbSub);
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/subs/delete/{guid}", (IRepository<Subscriber> repository, string guid) =>
{
    var dbSub = repository.GetByGuid(guid);
    if (dbSub != null)
    {
        repository.Remove(dbSub);
        return Results.Ok();
    }
    return Results.NotFound();
});





// Borrow CRUD

app.MapGet("/borrows/list", (IRepository<Borrow> repository) =>
{
    return Results.Ok(repository.GetAll().ToList());
});
app.MapPost("/borrows/add", (IRepository<Borrow> repository, Borrow borrow) =>
{
    repository.Add(borrow);
});
app.MapPut("/borrows/update/{guid}", (IRepository<Borrow> repository, string guid, Borrow borrow) =>
{
    var dbBorrow = repository.GetByGuid(guid);
    if (dbBorrow != null)
    {
        dbBorrow.BookId = borrow.BookId;
        dbBorrow.BorrowDate = borrow.BorrowDate;
        dbBorrow.ReturnDate = borrow.ReturnDate;
        dbBorrow.SubscriberId = borrow.SubscriberId;
        repository.Update(dbBorrow);
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/borrows/delete/{guid}", (IRepository<Borrow> repository, string guid) =>
{
    var dbBorrow = repository.GetByGuid(guid);
    if (dbBorrow != null)
    {
        repository.Remove(dbBorrow);
        return Results.Ok();
    }
    return Results.NotFound();
});


app.Run();



// PREVIOUS VERSION
/*app.MapGet("/books", (LibraryDB db) =>
{
    return Results.Ok(db.Books.ToList());
});

app.MapPost("/books", (LibraryDB db, Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
});

app.MapPut("/books/{guid}", (LibraryDB db, string guid, Book book) =>
{
    var dbBook = db.Books.FirstOrDefault(m => m.Guid == guid);
    if (dbBook != null)
    {
        dbBook.Author = book.Author;
        dbBook.Price = book.Price;
        dbBook.Title = book.Title;
        db.Books.Update(dbBook);
        db.SaveChanges();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.MapDelete("/books/{guid}", (LibraryDB db, string guid) =>
{
    var dbBook = db.Books.FirstOrDefault(m => m.Guid == guid);
    if (dbBook != null)
    {
        db.Books.Remove(dbBook);
        db.SaveChanges();
        return Results.Ok();
    }
    return Results.NotFound();
});*/