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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library"));
});

builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Subscriber>, SubscriberRepository>();
builder.Services.AddScoped<IRepository<Borrow>, BorrowRepository>();
builder.Services.AddScoped<BookService, BookService>();
// builder.Services.AddScoped<SubscriberDto, SubscriberDto>();


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

app.MapGet("/subs/list", (IRepository<Subscriber> repository) =>
{
    return Results.Ok(repository.GetAll()
    .Select(s=>new SubscriberDto{
        Guid = s.Guid,
        Address = s.Address,
        Fullname = s.Fullname,
        PhoneNumber = s.PhoneNumber
    })
    .ToList());
});
app.MapPost("/subs/add", (IRepository<Subscriber> repository, SubscriberAddOrUpdateDto sub) =>
{
    var s = new Subscriber{
        Address = sub.Address,
        Fullname = sub.Fullname,
        PhoneNumber = sub.PhoneNumber
    };
    repository.Add(s);
});
app.MapPut("/subs/update/{guid}", (IRepository<Subscriber> repository, string guid, SubscriberAddOrUpdateDto sub) =>
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
    return Results.Ok(repository.GetAll()
    .Select(b => new BorrowDto{
        Guid = b.Guid,
        BorrowDate = b.BorrowDate,
        ReturnDate = b.ReturnDate,
        Book = b.Book,
        BookId = b.BookId,
        Subscriber = b.Subscriber,
        SubscriberId = b.SubscriberId
    })
    .ToList());
});
app.MapPost("/borrows/add", (IRepository<Borrow> repository, BorrowAddOrUpdateDto borrow) =>
{
    var b = new Borrow{
        BorrowDate = borrow.BorrowDate,
        ReturnDate = borrow.ReturnDate,
        Book = borrow.Book,
        BookId = borrow.BookId,
        Subscriber = borrow.Subscriber,
        SubscriberId = borrow.SubscriberId
    };
    repository.Add(b);
});
app.MapPut("/borrows/update/{guid}", (IRepository<Borrow> repository, string guid, BorrowAddOrUpdateDto borrow) =>
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