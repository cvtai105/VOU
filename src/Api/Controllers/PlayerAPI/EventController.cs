﻿using Api.Commons;
using Application.DTOs;
using Application.Services.EventServices;
using AutoMapper;
using Domain.Specifications.EventSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers.PlayerAPI
{
    [Route("api/player/[controller]")]
    [ApiController]
    [Authorize(Roles = "player")]
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

        [HttpGet("wishlist")]
        public async Task<IActionResult> GetWishlistEvents()
        {
            Guid userId = Guid.Parse(User.FindFirstValue("userId"));
            var events = await _eventServices.GetWishlistEventsAsync(userId);
            return Ok(events);
        }

        [HttpPost("wishlist/{eventId}")]
        public async Task<IActionResult> AddEventToWishlist(Guid eventId)
        {
            Guid userId = Guid.Parse(User.FindFirstValue("userId"));
            var success = await _eventServices.AddEventToWishlist(eventId, userId);
            if (!success)
            {
                return BadRequest(new ApiResponse(400, "Failed to add event to wishlist."));
            }

            return Ok();
        }

        [HttpDelete("wishlist/{eventId}")]
        public async Task<IActionResult> RemoveEventFromWishlist(Guid eventId)
        {
            Guid userId = Guid.Parse(User.FindFirstValue("userId"));
            var success = await _eventServices.RemoveEventFromWishlist(eventId, userId);
            if (!success)
            {
                return BadRequest(new ApiResponse(400, "Failed to remove event from wishlist."));
            }

            return Ok();
        }
    }
}
