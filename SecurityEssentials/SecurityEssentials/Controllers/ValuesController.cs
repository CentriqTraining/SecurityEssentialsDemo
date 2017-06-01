using SecurityEssentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecurityEssentials.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        private List<Employee> _Emps = null;
        public ValuesController()
        {
            _Emps = new List<Employee>()
            {
                new Employee() { FirstName = "Scooby", LastName = "Doo", ID = 1 },
                new Employee() { FirstName = "Scrappy", LastName = "Doo", ID = 2 },
                new Employee() { FirstName = "Shaggy", LastName = "Rogers", ID = 3 },
                new Employee() { FirstName = "Fred", LastName = "Jones", ID = 4 },
                new Employee() { FirstName = "Daphne", LastName = "Blake",ID = 5 },
                new Employee() { FirstName = "Velma", LastName = "Dinkley",ID = 6 },
            };
        }
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                Employees = _Emps,
                Identity = new
                {
                    Name = User.Identity.Name,
                    Type = User.Identity.AuthenticationType
                }
            });
        }
    }
}
