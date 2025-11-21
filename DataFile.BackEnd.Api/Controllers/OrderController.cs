using Microsoft.AspNetCore.Mvc;

namespace DataFile.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<int> Get()
        {
            return null;
        }
    }
}
