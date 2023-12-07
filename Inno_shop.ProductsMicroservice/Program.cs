using FluentValidation;
using Inno_Shop.Services.Products.Application.Common.Behaviours;
using Inno_Shop.Services.Products.Application.Common.Mappings;
using Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct;
using Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct;
using Inno_Shop.Services.Products.Application.Products.Commands.UpdateProduct;
using Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails;
using Inno_Shop.Services.Products.Application.Products.Queries.GetProductList;
using Inno_Shop.Services.Products.Presentation.Middleware;
using Inno_Shop.Services.Products.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDbContext")));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ProductsDbContext).Assembly));
    
});


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(GetProductDetailsQueryHandler).Assembly,
        typeof(GetProductDetailsQuery).Assembly);

    config.RegisterServicesFromAssemblies(typeof(GetProductListQueryHandler).Assembly,
        typeof(GetProductListQuery).Assembly);

    config.RegisterServicesFromAssemblies(typeof(CreateProductCommandHandler).Assembly,
        typeof(CreateProductCommand).Assembly);

    config.RegisterServicesFromAssemblies(typeof(UpdateProductCommandHandler).Assembly,
        typeof(UpdateProductCommand).Assembly);

    config.RegisterServicesFromAssemblies(typeof(DeleteProductCommandHandler).Assembly,
        typeof(DeleteProductCommand).Assembly);
});


builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));


var app = builder.Build();

app.UseCustomExceptions();

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
