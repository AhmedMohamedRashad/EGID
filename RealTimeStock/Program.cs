using Demo.BL.Interface;
using Demo.BL.Repository;
using Microsoft.EntityFrameworkCore;
using RealTimeStack.BL.Hub;
using RealTimeStock.BL.Mapper;
using RealTimeStock.DAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("EGIDConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Scoped (Take One Instance With All Operation)
builder.Services.AddScoped<IStockRep, StockRep>();
builder.Services.AddScoped<IOrderRep, OrderRep>();
builder.Services.AddScoped<IHistoryRep, HistoryRep>();
builder.Services.AddScoped<IOrderTypeRep, OrderTypeRep>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();
app.MapHub<StockHub>("/stocks");

app.Run();
