using Basket.Common.Attibutes;
using Basket.Api.Bootstrappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAttribute>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
