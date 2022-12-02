using Assesment6DotNET.Models;
using Assesment6DotNET.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment6DotNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;
        private readonly OportunityRepository _oportunityRepository;
        private readonly TypeRepository _typeRepository;

        public DataController(ContactRepository contactRepository, OportunityRepository oportunityRepository, TypeRepository typeRepository)
        {
            _contactRepository = contactRepository;
            _oportunityRepository = oportunityRepository;
            _typeRepository = typeRepository;
        }


        [HttpGet]
        [Route("Contact")]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _contactRepository.GetAllContacts());
        }

        [HttpGet]
        [Route("Contact/{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            return Ok(await _contactRepository.GetContactById(id));
        }

        [HttpPost]
        [Route("Contact")]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _contactRepository.AddContact(contact);

            return CreatedAtAction(nameof(GetContactById), new { id = created.id }, created);
        }

        [HttpPut]
        [Route("Contact")]

        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contactRepository.UpdateContact(contact);

            return NoContent();
        }

        [HttpDelete("Contact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _contactRepository.DeleteContact(id);

            return NoContent();
        }

        [HttpGet("Oportunity")]

        public async Task<IActionResult> Oportunity()
        {
            return Ok(await _contactRepository.GetAllContacts());
        }

        [HttpGet("Oportunity/{id}")]
        public async Task<IActionResult> GetOportunityById(int id)
        {
            return Ok(await _oportunityRepository.GetOportunitiesById(id));
        }

        [HttpPost("Oportunity")]

        public async Task<IActionResult> AddOportunity([FromBody] Oportunity oportunity)
        {
            if (oportunity == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _oportunityRepository.AddOportunity(oportunity);

            return CreatedAtAction(nameof(GetOportunityById), new { id = created.id }, created);
        }

        [HttpPut("Oportunity")]

        public async Task<IActionResult> UpdateOportunity([FromBody] Oportunity oportunity)
        {
            if (oportunity == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _oportunityRepository.UpdateOportunity(oportunity);

            return NoContent();
        }

        [HttpDelete("Oportunity/{id}")]

        public async Task<IActionResult> DeleteOportunity(int id)
        {
            var oportunity = await _oportunityRepository.GetOportunitiesById(id);
            if (oportunity == null)
            {
                return NotFound();
            }
            await _oportunityRepository.DeleteOportunity(id);

            return NoContent();
        }

        [HttpGet("Type")]

        public async Task<IActionResult> Type()
        {
            return Ok(await _typeRepository.GetAllTypes());
        }

        [HttpGet("Type/{id}")]

        public async Task<IActionResult> GetTypeById(int id)
        {
            return Ok(await _typeRepository.GetTypesById(id));
        }

        [HttpPost("Type")]

        public async Task<IActionResult> AddType([FromBody] TypeData type)
        {
            if (type == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _typeRepository.AddTypes(type);

            return CreatedAtAction(nameof(GetTypeById), new { id = created.idType }, created);
        }

        [HttpPut("Type")]

        public async Task<IActionResult> UpdateType([FromBody] TypeData type)
        {
            if (type == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _typeRepository.UpdateTypes(type);

            return NoContent();
        }

        [HttpDelete("Type/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await _typeRepository.GetTypesById(id);
            if (type == null)
            {
                return NotFound();
            }
            await _typeRepository.DeleteTypes(id);

            return NoContent();
        }

    }
}
