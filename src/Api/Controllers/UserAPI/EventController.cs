using Application.DTOs;
using Application.Services.EventServices;
using AutoMapper;
using Domain.Constants;
using Domain.Specifications.EventSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Player")]
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
    }
}
