using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ScooterService.Entities;
using ScooterService.Data;
using ScooterService.Dtos;
using ScooterService.Entities.Validators;
using ScooterService.Repository;
using ScooterService.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//to be able to inject JWTService in Controllers
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ContextSeedService>();

//Add IdentityCore service
builder.Services.AddIdentityCore<User>(options =>
{   //password config
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    //email confirmation
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddRoles<IdentityRole>() //be able to add roles
    .AddRoleManager<RoleManager<IdentityRole>>() //be able to make use of RoleManager
    .AddEntityFrameworkStores<AppDbContext>() //provides the context
    .AddSignInManager<SignInManager<User>>() //make use of SigInManager
    .AddUserManager<UserManager<User>>() //make use of UserManager to create users
    .AddDefaultTokenProviders(); //generate tokens for email confirmation

//to be able to authenticate user using JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, //validate token based on the key provided in config
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])), //issuer signin key based on JWT:key
            ValidIssuer = builder.Configuration["JWT:Issuer"], //api url
            ValidateIssuer = true, //validate the issuer
            ValidateAudience = false // do not validate the audience (Angular app)
        };
    });

builder.Services.AddCors();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IReparationRepository, ReparationRepository>();
builder.Services.AddScoped<IReparationService, ReparationService>();

builder.Services.AddScoped<IScooterRepository, ScooterRepository>();
builder.Services.AddScoped<IScooterService, ScooterServiceImpl>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IIssueService, IssueServiceImpl>();




builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddTransient<IValidator<ScooterAddDto>, ScooterAddDtoValidator>();
builder.Services.AddTransient<IValidator<IssueAddDto>, IssueAddDtoValidator>();
builder.Services.AddTransient<IValidator<ReparationAddDto>, ReparationAddDtoValidator>();
builder.Services.AddTransient<IValidator<ReparationUpdateDto>, ReparationUpdateDtoValidator>();


var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithOrigins(builder.Configuration["JWT:ClientUrl"]);

});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

DbInitiallizer.InitializeDatabase(app);

#region ContextSeed
using var scope = app.Services.CreateScope();
try
{
    var contextSeedService = scope.ServiceProvider.GetService<ContextSeedService>();
    await contextSeedService.InitializeContextAsync();
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
    logger.LogError(ex.Message, "Failed to initialize and seed the database");
}
#endregion

app.Run();
