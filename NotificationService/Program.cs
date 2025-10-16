using Microsoft.EntityFrameworkCore;
using NotificationService.Consumers;
using NotificationService.Service;
using Shared.Data;
using Shared.ProducerSetting;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FPTSTrainingDBContext>(options =>
    options.UseOracle(connect));


builder.Services.AddScoped<IProducerSettings, ProducerSettings>();
builder.Services.AddScoped<INotificationService, NotificationServices>();
builder.Services.AddHostedService<NotificationConsumer>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
