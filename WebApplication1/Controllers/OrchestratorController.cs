using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrchestratorController : ControllerBase
    {
        private readonly ILogger<OrchestratorController> _logger;

        private static string _ipAddr = string.Empty;
        public OrchestratorController(ILogger<OrchestratorController> logger)
        {
            _logger = logger;
        }

        //curl -X GET "https://localhost:44338/Orchestrator" -H  "accept: text/plain"
        [HttpGet]
        public string GetIP()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            return String.IsNullOrEmpty(_ipAddr) ? Convert.ToString(remoteIpAddress) : _ipAddr;
        }

        //curl -X POST "https://localhost:44338/Orchestrator?ipaddress=192.168.1.1" -H  "accept: */*" -d ""
        [HttpPost]
        public IActionResult SetIP(string ipaddress)
        {
            _ipAddr = ipaddress;
            return Ok(_ipAddr);
        }
    }
}
