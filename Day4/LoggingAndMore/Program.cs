using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => 
        configuration.ReadFrom.Configuration(context.Configuration));


builder.Configuration.AddJsonFile("redisSettings.json", true);
builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseOutputCache();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

var redisHost = app.Configuration["Redis:Host"];


app.Run();


//Trace: The most detailed level of logging, used for tracing and debugging purposes.
//Debug: Used for debugging information that is valuable for developers during development and troubleshooting.
//Information: Used to provide information about normal application behavior.
//Warning: Indicates a potential problem or an abnormal condition that does not prevent the application from functioning.
//Error: Represents errors that are recoverable and don't prevent the application from continuing its execution.
//Critical: Represents critical errors or failures that may lead to application termination or unexpected behavior.





// default configuration providers:
// appsettings.json
// appsetttings.{env}.json
// Env varivables
// userSercrets - only dev env
// Command args

// default logging providers
// ConsoleLogging
// EventLog logging
