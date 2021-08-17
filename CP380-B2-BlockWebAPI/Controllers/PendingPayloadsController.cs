using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        // TODO
        private readonly PendingPayloads pending_Payload;
        public PendingPayloadsController(PendingPayloads pendingPayloads)
        {
            pending_Payload = pendingPayloads;
        }

        [HttpGet("/PendingPayloads")]
        public ActionResult Get()
        {
            return Ok(pending_Payload.payloads);
        }

        [HttpPost("/PendingPayloads")]
        public ActionResult Post(Payload payload)
        {
            pending_Payload.payloads.Add(payload);
            return Ok();
        }
    }
}
