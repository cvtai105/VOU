using Api.Commons;
using Application.DTOs;
using Application.Services.EventServices;
using AutoMapper;
using Domain.Specifications.EventSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandAPI
{
    [Route("api/Brand/[controller]")]
    [ApiController]
    [Authorize(Roles = "Brand")]
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
            var events = await _eventServices.GetEventsAsync(eventSpecParams);
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] EventRequestDTO newEventRequest)
        {
            var newEvent = new Domain.Entities.Event()
            {
                Name = newEventRequest.Name,
                BrandId = newEventRequest.BrandId,
                GameId = newEventRequest.GameId,
                StartAt = newEventRequest.StartAt,
                EndAt = newEventRequest.EndAt,
            };
            // Vouchers ?
            // TODO: Implement Picture Service to upload to cloud and retrieve image URL
            var success = await _eventServices.CreateEventAsync(newEvent);
            if (!success)
            {
                return BadRequest(new ApiResponse(400, "Failed to create event"));
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromForm] EventRequestDTO updatedEventRequest)
        {
            if (updatedEventRequest.Id == null)
            {
                return BadRequest(new ApiResponse(400, "No event id provided"));
            }

            var matchingEvent = await _eventServices.GetEventByIDAsync((Guid)updatedEventRequest.Id);
            matchingEvent.Name = updatedEventRequest.Name;
            matchingEvent.GameId = updatedEventRequest.GameId;
            matchingEvent.StartAt = updatedEventRequest.StartAt;
            matchingEvent.EndAt = updatedEventRequest.EndAt;
            // Vouchers ?

            // TODO: Implement Picture Service to upload to cloud and retrieve image URL

            var result = await _eventServices.UpdateEventAsync(matchingEvent);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Failed to update event"));
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var success = await _eventServices.DeleteEventAsync(id);
            if (!success)
            {
                return BadRequest(new ApiResponse(400, "Failed to delete event"));
            }

            return Ok();
        }
    }
}
