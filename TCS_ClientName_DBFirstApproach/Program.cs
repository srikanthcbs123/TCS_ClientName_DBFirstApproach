
using Microsoft.EntityFrameworkCore;
using TCS_ClientName_DBFirstApproach;
using TCS_ClientName_DBFirstApproach.DBConnect;
using TCS_ClineName_CodeFirstApproach.Repositories;
using TCS_ClineName_CodeFirstApproach;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TcsClinetNameCodeFirstApproachContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TcsConnection")));

builder.Services.AddDbContext<MidlandContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MidLandConnection")));


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
