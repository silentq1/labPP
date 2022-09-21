using NLog;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees;

[Route("[controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private ILoggerManager _logger;
    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("��� �������������� ��������� �� ������ ����������� ��������.");
       
        _logger.LogDebug("��� ���������� ��������� �� ������ ����������� ��������.");
       
        _logger.LogWarn("��� ��������� �������������� �� ������ ����������� ��������.");
       
        _logger.LogError("��� ��������� �� ������ �� ������ ����������� ��������.");
        return new string[] { "value1", "value2" };
    }
}

public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
