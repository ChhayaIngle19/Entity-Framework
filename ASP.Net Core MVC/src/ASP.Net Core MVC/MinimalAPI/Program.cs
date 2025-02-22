
using System.Runtime.InteropServices;

namespace MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Atomic Habit", Author = "ABC", Price = 364 },
                new Book { Id = 2, Title = "C# Language", Author = "Christian Nagel", Price = 475},
                new Book { Id = 3, Title = "The Power of now", Author = "XYZ", Price = 453 },
            };
            app.MapGet("/book", () =>
            {
                return books;
            });

            app.MapGet("/book/{id}", (int id) =>
            {
                var book = books.Find(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound("This book dooesn't exist.");
                }
                return Results.Ok(book);
            });

            app.MapPost("/book", (Book book) =>
            {
                books.Add(book);
                return books;
            });

            app.MapPut("/book/{id}", (Book updateBook, int id) =>
            {
                var book = books.Find(b => b.Id == id);
                if (book is null)
                {
                    return Results.NotFound("This book dooesn't exist.");
                }
                book.Author = updateBook.Author;
                book.Title = updateBook.Title;

                return Results.Ok(books);
            });

            app.MapDelete("/book/{id}", (int id) =>
            {
                var book = books.Find(b => b.Id == id);
                if (book is null)
                
                    return Results.NotFound("This book dooesn't exist.");
                    books.Remove(book); 
                 
                    return Results.Ok(books);
            });

            app.Run();
        }
            class Book
        {
            public int Id { get; set; }
            public required string Title { get; set; }
            public required string Author { get; set; }
            public decimal Price { get; set; }

        
        }
    }
}
