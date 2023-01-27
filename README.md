# MyWeatherAppApi
Asp.Net Core Web Api, Which gives the weather report of a location based on City, through a 3rd part open API "openweathermap"
it is a cross platform application, that was built with ASP.NET Core, which runs Windows, Linux, and Ios.
Best Pratices such as Seperation of concerns, effective logging, Dependency Injection (for loose coupling was adapted in the Application)

## Installation

Open project with visual studio , Run Restore nuget on the solution level to restore nuget for all projects. Build the solution

the following nuget packages was installed during the development of the project 
Microsoft.AspNetCore.Authentication.JwtBearer,
Microsoft.AspNetCore.Identity.UI
Microsoft.EntityFrameworkCore,
Microsoft.EntityFrameworkCore.Tools,
Serilog.AspNetCore,
Serilog.Sinks.Console,
Serilog.Sinks.File

## OnBoarding
On installation, you will be required to register, Only auntheticated users can access the Application,
the Aunthentication was done using JWT Token, through the Microsoft.AspNetCore.Identity using Register Async, 
it required UserRegistrationDto (Email, username & Password).
On registeration, A Jwt Token and Refresh Token. Which is used authentication across the Wire.

#Authorization
On registeration, A user claim is assign to every User, also, A Policy can the given to specific User based on their Functionality (i.e Admin)

```
builder.Host.UseSerilog();
....................
builder.Services.AddScoped<!--Some Code missing -->, !--Some Code missing -->>();
..........................
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy( <!--Some Code missing -->,
        policy => policy.RequireClaim("<---->));
});

```

## Third Party Api
A Third API (openweathermap.org/api) was used to generated the Data(Weather Report), 
the unique Key was saved in the secret manager to prevent Security Issues.
Http client was used to consume the API, through the Http client factory

```
<!--Some Code missing -->
  var httpClient = httpClientFactory.CreateClient();
  var r.....e = await httpClient.GetAsync(url);
  <!--Some Code missing -->
  
```
##Logging
Effective Logging was done with the help of third party library, Serilog.


```
<!--Some Code missing -->
<!--Some Code missing -->
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("<!--Some Code missing -->", rollingInterval: RollingInterval.Day)
     .CreateLogger();
  <!--Some Code missing -->
 <!--Some Code missing -->
</ContentPage>
```

the Logs are recorded to check the activty of the App.
logs suchs as Search histroy, User's information such as Email e.t.c,,,,,

```
 public class MyWeatherForcastController : ControllerBase
    {
    <!--Some Code missing -->
    <!--Some Code missing -->

public async Task<ActionResult> City(string city)
    <!--Some Code missing -->
    <!--Some Code missing -->
    
                    var userEmail = User.Claims.FirstOrDefault(a => a.Type == "Email")?.Value;
                var userId = User.Claims.FirstOrDefault(a => a.Type == "Sub")?.Value;

                object[] Infos = { User.Claims, userEmail };
                object[] Info = { User.Claims, userId };

                //Additional Info like machine name.
                using (_logger.BeginScope(_scopeInfo.HostScopeInfo))
                {
                    _logger.LogInformation(message: "{userEmail} gets weather forcast {claims}",
                     args: Infos);
                    _logger.LogInformation(message: "{userId} is inside get weather forcast{claims}",
                        args: Info);
                }
          <!------Some Code missing ------>
            <!------Some Code missing ------>
              <!------Some Code missing ------>

```



