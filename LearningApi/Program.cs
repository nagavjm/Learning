using LearningApi.Business;
using LearningApi.Data;
using LearningApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------- DATABASE: EF Core + SQL Server ----------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// ---------- DEPENDENCY INJECTION (wiring the layers together) ----------
// Whenever IProductBusiness is requested, give a ProductBusiness.
// Whenever IProductRepository is requested, give a ProductRepository.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ---------- API LAYER: routes come from Controller classes ----------
app.MapControllers();

app.Run();
