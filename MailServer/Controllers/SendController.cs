using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Cors;
using MailServer.Models;
using System;
using System.Linq;
using MailServer.Provider;
using MailServer.Response;

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
            _sendService = sendService;
        }
        // POST api/values
        [HttpPost]
        public  ActionResult Post([FromBody] EmailMessage emailMessage)
       {

            if (ModelState.IsValid)
            {

                var res =  _sendService.Send(emailMessage);
                if (res._success == Status.success)
                {
                    return Ok();

                }

                return StatusCode(500);
               
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return BadRequest(errors);
            }
        }
    }
}
