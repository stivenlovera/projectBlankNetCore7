using comisionesapi.Context;
using comisionesapi.Utils;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


/* config serilog */
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    //.WriteTo.Console()
    .WriteTo.File("Logs/Log-.log", Serilog.Events.LogEventLevel.Warning, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u15}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

/*
    *Services
*/
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*config Conexion*/
var getStringConnectionMysql = builder.Configuration.GetSection("connectionMysql").Get<StringConnection>();
var mysqlConnect = $"Server={getStringConnectionMysql.IpServer};Port={getStringConnectionMysql.Port};Database={getStringConnectionMysql.Database};User={getStringConnectionMysql.User};Password={getStringConnectionMysql.Password};";

var getStringConnectionSqlServer = builder.Configuration.GetSection("connectionSqlServer").Get<StringConnection>();
var sqlServerConnect = $"Server={getStringConnectionMysql.IpServer};Database={getStringConnectionMysql.Database};User={getStringConnectionMysql.User};Password={getStringConnectionMysql.Password};";

builder.Services.AddDbContext<DbMysqlServerContext>(options =>
{
    options.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect));
});

builder.Services.AddDbContext<DbSqlServerContext>(options =>
{
    options.UseSqlServer(sqlServerConnect);
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Warning("Iniciando Web API");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return;
}
