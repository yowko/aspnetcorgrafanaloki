using Serilog;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Log.Logger = new LoggerConfiguration()
//     .MinimumLevel.Information()
//     .MinimumLevel.Override( "Microsoft" ,LogEventLevel.Warning)
//     .MinimumLevel.Override( "Microsoft.Hosting.Lifetime",LogEventLevel.Warning)
//     .Enrich.FromLogContext()
//     .WriteTo.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {SourceContext} [{Level}] {Message}{NewLine}{Exception}")
//     .WriteTo.GrafanaLoki(
//         "http://localhost:3100", new List<LokiLabel>()
//         {
//             new LokiLabel
//             {
//                 Key = "app",
//                 Value = "web_app_GrafanaLoki"
//             }
//         },propertiesAsLabels:new List<string>(){"level","from"})
//     .CreateLogger();

//
// Log.Logger = new LoggerConfiguration()
//     .ReadFrom.Configuration(builder.Configuration)
//     .CreateLogger();

// builder.Host.UseSerilog((context, configuration) =>
//     {
//         configuration.MinimumLevel.Information()
//             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//             .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
//             .Enrich.FromLogContext()
//             .WriteTo.Console(
//                 outputTemplate: "[{Timestamp:HH:mm:ss} {SourceContext} [{Level}] {Message}{NewLine}{Exception}")
//             .WriteTo.GrafanaLoki(
//                 "http://localhost:3100", new List<LokiLabel>()
//                 {
//                     new LokiLabel
//                     {
//                         Key = "app",
//                         Value = "web_app_GrafanaLoki"
//                     }
//                 }, propertiesAsLabels: new List<string>() { "level","from" });
//     }
// );

builder.Host.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();