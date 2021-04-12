using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Send.Domain;

namespace Send.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {
        private readonly IReverser _reverser;

        public SendController(IReverser reverser)
        {
            _reverser = reverser;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _reverser.Reverse(new[] { "Hi", "you", "call", "sending", "API" });
        }
    }
}
