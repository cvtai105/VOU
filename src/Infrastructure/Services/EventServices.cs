using Application.DTOs;
using Application.Helpers;
using Application.Services.EventServices;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Domain.Specifications.EventSpec;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventServices : IEventServices
    {
        #region vars
        private readonly IGenericRepository<Event> _eventRepo;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public EventServices(IGenericRepository<Event> eventRepo)
        {
            _eventRepo = eventRepo;
        }
        #endregion

        public async Task<Event?> GetEventByIDAsync(Guid eventId)
        {
            return await _eventRepo.GetByIdAsync(eventId);
        }

        public async Task<Pagination<EventResponseDTO>> GetEventsAsync(EventSpecParams eventSpecParams)
        {
            var spec = new EventSpecification(eventSpecParams);
            var countSpec = new EventCountSpecification(eventSpecParams);

            List<Event> events = await _eventRepo.ListAsync(spec);
            int numMatchingEvents = await _eventRepo.CountAsync(countSpec);

            var eventResponses = _mapper.Map<List<Event>, List<EventResponseDTO>>(events);

            return new Pagination<EventResponseDTO>(
                eventSpecParams.PageIndex, 
                eventSpecParams.PageSize, 
                events.Count, 
                eventResponses
            );
        }

        public async Task<bool> CreateEventAsync(Event newEvent)
        {
            _eventRepo.Add(newEvent);

            return await _eventRepo.SaveAsync() > 0;
        }

        public async Task<bool> UpdateEventAsync(Event updatedEvent)
        {
            _eventRepo.Update(updatedEvent);

            return await _eventRepo.SaveAsync() > 0;
        }

        public async Task<bool> DeleteEventAsync(Guid eventId)
        {
            Event? eventToDelete = await _eventRepo.GetByIdAsync(eventId);

            if (eventToDelete == null)
            {
                return false;
            }

            _eventRepo.Delete(eventToDelete);

            return await _eventRepo.SaveAsync() > 0;
        }
    }
}
