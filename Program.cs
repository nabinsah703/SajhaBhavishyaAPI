using Microsoft.EntityFrameworkCore;
using SajhaBhavishyaAPI.Data;
using SajhaBhavishyaAPI.Repositories;
using SajhaBhavishyaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<SajhaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Register services
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
