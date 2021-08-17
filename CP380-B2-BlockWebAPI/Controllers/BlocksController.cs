using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;


namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        // TODO
        private readonly BlockList block_list;
        public BlocksController(BlockList blockList)
        {
            block_list = blockList;
        }
        [HttpGet("/blocks")]
        public ActionResult Get()
        {
            return Ok(block_list.Chain.Select(block => new BlockSummary()
            {
                Hash = block.Hash,
                PreviousHash = block.PreviousHash,
                TimeStamp = block.TimeStamp
            }));
        }

        [HttpGet("/blocks/{hash?}")]
        public ActionResult GetBlockhash(string hash)
        {
            var block = block_list.Chain
                .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => new BlockSummary()
                    {
                        Hash = block.Hash,
                        PreviousHash = block.PreviousHash,
                        TimeStamp = block.TimeStamp
                    }
                    )
                    .First());
            }

            return NotFound();
        }

        [HttpGet("/blocks/{hash?}/payloads")]
        public ActionResult GetBlockPayload(string hash)
        {
            var block = block_list.Chain
                        .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => block.Data
                    )
                    .First());
            }

            return NotFound();
        }

    }
}
