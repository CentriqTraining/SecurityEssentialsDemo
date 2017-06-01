using SecurityEssentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecurityEssentials.Controllers
{
    public class ValidationController : ApiController
    {
        // POST: api/Validation
        [Route("GeoPoint")]
        public IHttpActionResult Post(GeoPoint point)
        {
            if (point == null)
            {
                return BadRequest("Nothing to process");
            }
            if (ModelState.IsValid)
            {
                return Ok(point);
            }
            else
                return BadRequest(ModelState);
        }
    }
}
