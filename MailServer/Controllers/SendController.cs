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
             _sendService= sendService;
        }
      
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailMessage emailMessage)
        {
            try
            {
                await _sendService.Send(emailMessage);
            }
            catch(Exception e)
            {
                return BadRequest("Some problem occured at our side");
            }
            
            return Ok("Mail Sent Successfully");
        }
    }
}
