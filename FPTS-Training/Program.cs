using FPTS_Training.Data;
using FPTS_Training.Mapper;
using FPTS_Training.Mapper.Implementation;
using FPTS_Training.Services;
using FPTS_Training.Services.Implement;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FPTSTrainingDBContext>(options =>
    options.UseOracle(connect));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IBuyerMapper, BuyerMapper>();
builder.Services.AddScoped<IOrderService, OrderSerrvice>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderItemMapper, OrderItemMapper>();
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
