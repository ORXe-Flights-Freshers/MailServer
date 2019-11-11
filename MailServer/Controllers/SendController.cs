using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Cors;
using MailServer.Services;
using MailServer.Models;
using System;

namespace MailServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class SendController : ControllerBase
    {
        private SendService _sendService;

        public SendController(SendService sendService)
        {
            this._sendService= sendService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EMailMessage emailMessage)
        {
            try
            {
                await _sendService.Send(emailMessage);
            }
            catch(Exception e)
            {
                return BadRequest("Some problem occured at our side");
            }
            
            return Ok(new {message="Message Sent Successfully" });
        }
    }
}
