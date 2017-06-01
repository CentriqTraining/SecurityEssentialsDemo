using SecurityEssentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace SecurityEssentials.Controllers
{
    public class ToonsController : ApiController
    {
        [Route("StdTypes")]
        [HttpPost]
        public IHttpActionResult PostStd(int val1, string val2)
        {
            if (val1 > 0 && val2 != null)
            {
                return Ok(new { val1, val2 });
            }
            else
                return BadRequest();
        }

        [Route("Toon")]
        [HttpPost]
        public IHttpActionResult PostToon(Toon item)
        {
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("Explicit")]
        [HttpPost]
        public IHttpActionResult PostExplicit(int val1, [FromBody]string val2)
        {
            if (val1 > 0 && val2 != null)
            {
                return Ok(new { val1, val2 });
            }
            else
                return BadRequest();
        }

        [Route("Both")]
        [HttpPost]
        public IHttpActionResult Post(int val1, string val2, Toon item)
        {
            if (item != null)
            {
                return Ok(new { Toon = item, val1, val2 });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DTO")]
        public IHttpActionResult PostDTO(Toon_DTO item)
        {
            if (item != null)
            {
                return Ok(  item);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
