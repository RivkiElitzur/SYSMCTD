using Microsoft.AspNetCore.Mvc;
using SYSMCTD.Interfaces;
using SYSMCTD.Models;

namespace SYSMCTD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contacts> _repository;
        public ContactController(IRepository<Contacts> contactRepository)
        {
            _repository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var contact = await _repository.Get();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contacts contact)
        {
            var newContact = await _repository.Create(contact);
            return Ok(newContact);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] Contacts contact)
        {
            var editedContacts = await _repository.Edit(contact);
            return Ok(editedContacts);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _repository.Delete(id);
            return Ok(contact);
        }
    }
}
