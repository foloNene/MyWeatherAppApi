using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Formatting.Json;
using System.Text;
using WeatherApi.Services;
using WeatherCore;
using WeatherData.Configuration;

//log
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
     .CreateLogger();



var builder = WebApplication.CreateBuilder(args);

//use of serilog to Log
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();



//Database Connection
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Key fr JWT Token
var Key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);

//For JWT REFRESH Token as My Parameters
var tokenValidationParams = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Key),
    ValidateIssuer = false, //for development
    ValidateAudience = false, //for development
    ValidateLifetime = true, 
    RequireExpirationTime = false, //for development

};

//Add tokenValidation params as a singleton for the Refreshtoken
builder.Services.AddSingleton(tokenValidationParams);

//Add services to log the Machine info
builder.Services.AddSingleton<IScopeInformation, ScopeInformation>();

//Reg my Auth Services
builder.Services.AddScoped<IUserRepository, UserRepository>();

//register Key through DI
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));



//Add Email 
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(jwt =>
   {
         jwt.SaveToken = true;
         jwt.TokenValidationParameters = tokenValidationParams;
   });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApiDbContext>();

//Claims Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DepartmentPolicy",
        policy => policy.RequireClaim("department"));

});

builder.Services.AddHttpClient();

//Confirm Email Verify
//builder.Services.Configure<IdentityOptions>(
//    opts => opts.SignIn.RequireConfirmedEmail = true
//    );



var app = builder.Build();

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

app.Run();
