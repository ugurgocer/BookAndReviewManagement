using BookAndReviewManagement.Data;
using BookAndReviewManagement.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*
 * Open API/Swagger ayarlaması için gerekli metotlar.
 */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<BookReviewContext>(
    builder.Configuration.GetConnectionString("BookReviewManagement")
);

var app = builder.Build();
await app.MigrateDb();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app
    .AddBookEndpoints()
    .AddReviewEndpoints();

app.Run();