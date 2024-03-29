using CookingBook.Application;
using CookingBook.Infrastructure;
using CookingBook.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontedClient", policyBuilder =>
    {
        policyBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});
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

app.UseCors("FrontedClient");
app.UseHttpsRedirection();
app.UseShared();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program{}