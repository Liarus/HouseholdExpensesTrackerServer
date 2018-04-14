using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Web.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IUserManager _userManager;

        public ValuesController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var user = _userManager.Validate("Email", "admin@example.com", "admin");
            if (user != null)
            {
                _userManager.SignIn(this.HttpContext, user, false);
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var current = _userManager.GetCurrentUser(this.HttpContext).Name;
            return current;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
