using Api.Commons;
using Application.DTOs;
using Application.Services.EventServices;
using Application.Services.ImageServices;
using AutoMapper;
using Domain.Enums;
using Domain.Specifications.EventSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AdminAPI
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class EventController : ControllerBase
    {
        #region vars
        private readonly ILogger<EventController> _logger;
        private readonly IEventServices _eventServices;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public EventController(ILogger<EventController> logger, IEventServices eventServices, IMapper mapper)
        {
            _logger = logger;
            _eventServices = eventServices;
            _mapper = mapper;
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var eventEntity = await _eventServices.GetEventByIDAsync(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<EventResponseDTO>(eventEntity);
            return Ok(eventDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] EventSpecParams eventSpecParams)
        {
            var events = await _eventServices.GetEventsAsync(eventSpecParams, isUser: false);
            return Ok(events);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromForm] EventRequestDTO updatedEventRequest)
        {
            if (updatedEventRequest.Id == null)
            {
                return BadRequest(new ApiResponse(400, "No event id provided"));
            }

            var matchingEvent = await _eventServices.GetEventByIDAsync((Guid)updatedEventRequest.Id);
            matchingEvent.Status = (EventStatus)updatedEventRequest.Status;
            // Vouchers ?

            // TODO: Implement Picture Service to upload to cloud and retrieve image URL

            var result = await _eventServices.UpdateEventAsync(matchingEvent);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Failed to update event"));
            }

            return Ok();
        }
    }
}
