using JeanPruebaNet.Domain;
using JeanPruebaNet.Application;
using JeanPruebaNet.Application.Services.ProductStockService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder);


builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IProductStockService, ProductStockService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:8081/api/product");
});



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.UseCors();
app.Run();

