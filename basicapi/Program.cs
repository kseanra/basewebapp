using basicapi.Configurations;
using Microsoft.EntityFrameworkCore;
using basicapi.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add AutoMapper and scan for profiles in the assembly
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// Add MediatR from Application layer
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(unhandledExceptionBehavior<,>));

builder.Services.Configure<DbConfig>(builder.Configuration.GetSection("db"));

builder.Services.AddScoped<IUserRepository, basicapi.Infrastructrue.Services.EfUserRepository>();

// Register AppDbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();

