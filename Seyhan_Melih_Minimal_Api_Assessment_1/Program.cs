using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();



app.UseHttpsRedirection();

// Authentication endpoints
app.MapPost("/auth/login", () => "That route handles login");
app.MapPost("/auth/register", () => "That route handles registration" );
app.MapGet("/auth/logout", () => "That route handles logout");

// Dashboard endpoint
app.MapGet("/dashboard", () => "That route return dashboard data");

// Book management endpoints
app.MapGet("/books", () => "that route list all the book on the system") ;
app.MapPost("/book", () => "This route add a new book");
app.MapGet("/book/{bookId}", (int bookId) => "This route return a specific book's details by using its id");
app.MapPut("/book/{bookId}", (int bookId) => "This route update a specific book's details by using its id");;
app.MapDelete("/book/{bookId}", (int bookId) => "This route delete a specific book's details by using its id");

// Borrowing management endpoints
app.MapGet("/borrowings", () =>  "this route list all borrowings");
app.MapPost("/borrowing", ()=> "This route create a new borrowing record");
app.MapGet("/borrowing/{borrowingId}", (int borrowingId) => "This route retrive a specific borrowing record by using its id");
app.MapPut("/borrowing/{borrowingId}", (int borrowingId) => "This route update a specific borrowing record by using its id");
app.MapDelete("/borrowing/{borrowingId}", (int borrowingId) => "This route delete a specific borrowing record by using its id");

// Reader management endpoints
app.MapGet("/readers", () => "This route list all readers");
app.MapPost("/reader", () => "This route add a new readers");
app.MapGet("/reader/{readerId}", (int readerId) => "This route retrieve a specific reader's details");
app.MapPut("/reader/{readerId}", (int readerId) => "This route update a specific reader's details");
app.MapDelete("/reader/{readerId}", (int readerId) => "This route delete a specific reader");

// Reporting endpoints
app.MapGet("/reports/borrowings", () => "This route generate borrowings report");
app.MapGet("/reports/books", () => "This route generate books report");
app.MapGet("/reports/readers", () => "This route generate readers report");

// Overdue management endpoints
app.MapGet("/overdue/check", () => "This route check overdue books and calculate charges");
app.MapGet("/overdue/charges/{borrowingId}", (int borrowingId) => "This route Retrieve overdue charges for a specific borrowing");

app.Run();
