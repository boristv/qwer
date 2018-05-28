using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AncApi.Models;

namespace AncApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        MessagesContext db;
        public MessagesController(MessagesContext context)
        {
            this.db = context;
        }

        [HttpGet("{id1}/{id2}")]
        public IEnumerable<Message> Get(string id1, string id2)
        {
            var messages = db.MessagesNew.Where(i => (i.nameSender == id1 && i.nameGetter == id2) || (i.nameGetter == id1 && i.nameSender == id2)).ToList();
            return messages.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Message message = db.MessagesNew.FirstOrDefault(x => x.Id == id);
            if (message == null)
                return NotFound();
            return new ObjectResult(message);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            db.MessagesNew.Add(message);
            db.SaveChanges();
            return Ok(message);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            if (!db.MessagesNew.Any(x => x.Id == message.Id))
            {
                return NotFound();
            }

            db.Update(message);
            db.SaveChanges();
            return Ok(message);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Message message = db.MessagesNew.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            db.MessagesNew.Remove(message);
            db.SaveChanges();
            return Ok(message);
        }
    }
}
