using CookingBook.Application;
using CookingBook.Infrastructure;
using CookingBook.Infrastructure.EF;
using CookingBook.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
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
SeedDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<Seeder>();
        dbInitializer.Seed();
    }
}