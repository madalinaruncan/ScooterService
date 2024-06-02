
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ScooterService.Data;
using ScooterService.Dtos;
using ScooterService.Entities.Validators;
using ScooterService.Repository;
using ScooterService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
//builder.Services.AddCors(option =>
//{
//    option.AddPolicy("DefaultPolicy", builder =>
//    {
//        builder.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader();
//    });
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IReparationRepository, ReparationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReparationService, ReparationService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IScooterRepository, ScooterRepository>();
builder.Services.AddScoped<IScooterService, ScooterServiceImpl>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IIssueService, IssueServiceImpl>();

builder.Services.AddControllers().AddFluentValidation();

<<<<<<< HEAD
builder.Services.AddTransient<IValidator<ScooterAddDto>, ScooterAddDtoValidator>();
builder.Services.AddTransient<IValidator<IssueAddDto>, IssueAddDtoValidator>();
builder.Services.AddTransient<IValidator<ReparationAddDto>, ReparationAddDtoValidator>();
builder.Services.AddTransient<IValidator<ReparationUpdateDto>, ReparationUpdateDtoValidator>();
=======

builder.Services.AddScoped<IValidator<Reparation>, ReparationValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DefaultPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

DbInitiallizer.InitializeDatabase(app);

app.Run();
