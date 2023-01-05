using comisionesapi.Context;
using comisionesapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comisionesapi.Controllers;

[ApiController]
[Route("Demo")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration configuration;

    public DbMysqlServerContext DbMysqlServerContext { get; }

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IConfiguration configuration,
        DbMysqlServerContext DbMysqlServerContext
        )
    {
        _logger = logger;
        this.configuration = configuration;
        this.DbMysqlServerContext = DbMysqlServerContext;
    }

    [HttpGet("/demo")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("otros")]
    public string Demo()
    {
        return this.configuration.GetValue<string>("connectionMysql:IpServer");
    }
    [HttpGet("select")]
    public async Task<List<AdministracionRed>> DemoSelect()
    {
        this._logger.LogWarning("entrado a api");
        var resultado = await this.DbMysqlServerContext.AdministracionRed.FromSqlRaw(@"
            SELECT AR.susuarioadd,AR.dtfechamod,AR.lcontacto_id
                FROM AdministracionRed as AR
            WHERE
                AR.lpatrocinador2g = '608'
                AND AR.lpatrocinador1g = '85062';
            ").ToListAsync();
        return resultado;
    }
}

