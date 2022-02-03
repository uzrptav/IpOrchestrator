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

        [HttpGet]
        public string GetIP()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            return String.IsNullOrEmpty(_ipAddr) ? Convert.ToString(remoteIpAddress) : _ipAddr;
        }

        [HttpPost]
        public IActionResult SetIP(string ipaddress)
        {
            _ipAddr = ipaddress;
            return Ok(_ipAddr);
        }
    }
}
