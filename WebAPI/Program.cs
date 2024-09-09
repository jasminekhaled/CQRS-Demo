using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Reflection;
using static Application.Features.UserFeatures.Commands.AddUserCommand;
using static Application.Features.UserFeatures.Commands.UpdateUserCommand;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString(name: "DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(AddUserCommandHandler).Assembly);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
