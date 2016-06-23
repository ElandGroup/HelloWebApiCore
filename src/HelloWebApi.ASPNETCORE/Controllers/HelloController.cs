using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWebApi.ASPNETCORE.Models;
using HelloWebApi.ASPNETCORE.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebApi.ASPNETCORE.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        public IContactsService ContactsRepo { get; set; }

        public HelloController(IContactsService _repo)
        {
            ContactsRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Contacts> GetAll()
        {
            return ContactsRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(string id)
        {
            var item = ContactsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ContactsRepo.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ContactsRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ContactsRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ContactsRepo.Remove(id);
        }
    }
}
