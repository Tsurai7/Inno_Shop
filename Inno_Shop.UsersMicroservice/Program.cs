using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Infrastucture.Data;
using Inno_Shop.UsersMicroservice.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDb"));
});

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
