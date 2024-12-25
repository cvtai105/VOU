using Api.Commons;
using Application.DTOs;
using Application.Services.EventServices;
using Application.Services.ImageServices;
using AutoMapper;
using Domain.Specifications.EventSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandAPI
{
    [Route("api/Brand/[controller]")]
    [ApiController]
    [Authorize(Roles = "brand")]
    public class EventController : ControllerBase
    {
        #region vars
        private readonly ILogger<EventController> _logger;
        private readonly IEventServices _eventServices;
        private readonly IImageServices _imageServices;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public EventController(ILogger<EventController> logger, IEventServices eventServices, IImageServices imageServices, IMapper mapper)
        {
            _logger = logger;
            _eventServices = eventServices;
            _imageServices = imageServices;
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

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] EventRequestDTO newEventRequest)
        {
            var newEvent = new Domain.Entities.Event()
            {
                Id = Guid.NewGuid(),
                Name = newEventRequest.Name,
                BrandId = newEventRequest.BrandId,
                StartAt = newEventRequest.StartAt,
                EndAt = newEventRequest.EndAt,
            };
            // Vouchers ?
            // TODO: Implement Picture Service to upload to cloud and retrieve image URL
            if (newEventRequest.Picture != null)
            {
                string fileName = newEvent.Id + "_" + Guid.NewGuid().ToString();
                string folderName = "events";
                string imageUrl = await _imageServices.UploadImageAsync(newEventRequest.Picture, fileName, folderName);
                newEvent.ImageUrl = imageUrl;
            }

            var success = await _eventServices.CreateEventAsync(newEvent);
            if (!success)
            {
                return BadRequest(new ApiResponse(400, "Failed to create event"));
            }

            return Ok(newEvent);
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
            matchingEvent.StartAt = updatedEventRequest.StartAt;
            matchingEvent.EndAt = updatedEventRequest.EndAt;
            // Vouchers ?

            // TODO: Implement Picture Service to upload to cloud and retrieve image URL
            if (updatedEventRequest.Picture != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string folderName = "events";
                string imageUrl = await _imageServices.UploadImageAsync(updatedEventRequest.Picture, fileName, folderName);
                matchingEvent.ImageUrl = imageUrl;
            }

            var result = await _eventServices.UpdateEventAsync(matchingEvent);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Failed to update event"));
            }

            var updatedEvent = await _eventServices.GetEventByIDAsync(matchingEvent.Id);

            return Ok(updatedEvent);
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
