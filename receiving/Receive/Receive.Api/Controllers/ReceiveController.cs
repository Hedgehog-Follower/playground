using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Receive.Domain;

namespace Receive.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiveController : ControllerBase
    {
        private readonly IReverser _reverser;

        public ReceiveController(IReverser reverser)
        {
            _reverser = reverser;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _reverser.Reverse(new[] { "Hi", "you", "call", "receiving", "API" });
        }
    }
}
