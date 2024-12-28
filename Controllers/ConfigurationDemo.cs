using Microsoft.AspNetCore.Mvc;
namespace ConfigurationDemo.Controllers;


public class DatabaseOption
{
    public const string SectionName = "Database";
    public string Type { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}

[ApiController]
[Route("[controller]")]
public class ConfigurationController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    [Route("my-key")]
    public ActionResult GetMyKey()
    {
        var myKey = configuration["MyKey"];
        return Ok(myKey);
    }

    [HttpGet]
    [Route("db-configurations")]
    public ActionResult GetDBConfig()
    {
        var type = configuration["Database:Type"];
        var dbConfigString = configuration["Database:ConnectionString"];

        return Ok(new {Type = type, DBConfig = dbConfigString});
    }

    [HttpGet]
    [Route("database-configuration-with-bind")]
    public ActionResult GetDBConfigurations()
    {
        var databaseOption = new DatabaseOption();
        configuration.GetSection(DatabaseOption.SectionName).Bind(databaseOption);
        // configuration.bind(DatabaseOption.SectionName, databaseOption);   DOES SAME
        return Ok(new {
            databaseOption.Type, databaseOption.ConnectionString
        });
    }
}

