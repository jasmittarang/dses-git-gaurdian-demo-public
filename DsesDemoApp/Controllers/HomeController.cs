using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DsesDemoApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConfiguration AppSettings;

        public HomeController(IConfiguration appSettings)
        {
            AppSettings = appSettings;
        }

        [Route("/")]
        [HttpGet]
        public Dictionary<string, string> GetHomePage()
        {
            return new Dictionary<string, string>() {
                { "DSES", "Developer Security Enablement Services"},
                { "Environment", AppSettings["Environment"] }
            };
        }
    }
}
