using Application.Commands;
using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Contacts;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateContacts(AddContactsRequest request)
        {
            await _mediator.Send(new UpdateContactsCommand
            {
                SanatoriumId = request.SanatoriumId,
                TourAgencyId = request.TourAgencyId,
                Contacts = request.Contacts.Select(c => new Application.Models.ContactDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                }).ToList()
            });

            return Ok();
        }

        [HttpGet("by-sanatorium/{sanatoriumId}")]
        public async Task<ActionResult<List<ContactDto>>> GetSanatoriumContacts(Guid sanatoriumId)
        {
            var contacts = await _mediator.Send(new GetSanatoriumContactsQuery
            {
                SanatoriumId = sanatoriumId
            });

            return Ok(contacts);
        }

        [HttpGet("by-tour-agency/{id}")]
        public async Task<ActionResult<List<ContactDto>>> GetTourAgencyContacts(Guid id)
        {
            var contacts = await _mediator.Send(new GetTourAgencyContactsQuery
            {
                TourAgencyId = id
            });

            return Ok(contacts);
        }
    }
}
