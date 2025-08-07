using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper.Extensions;

namespace basicapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private static List<string> accounts = new List<string>();

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAccounts()
        {
            return Ok(accounts);
        }

        [HttpPost]
        public ActionResult CreateAccount([FromBody] string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                return BadRequest("Account name cannot be empty.");
            }

            accounts.Add(accountName);
            return CreatedAtAction(nameof(GetAccounts), new { name = accountName }, accountName);
        }
    }
}