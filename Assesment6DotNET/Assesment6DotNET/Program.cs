using Assesment6DotNET.Interfaces;
using Assesment6DotNET.MySQL;
using Assesment6DotNET.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the connection to the MySQL database
//var MySQLConfig = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConnection"));
//builder.Services.AddSingleton(MySQLConfig);

builder.Services.AddSingleton(new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConnection")));

builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
