using Application.DTOs;
using Application.Helpers;
using Application.Services.EventServices;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Domain.Specifications.EventSpec;
using Domain.Specifications.WishlistSpec;
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
        private readonly IGenericRepository<WishList> _wishlistRepo;
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

        public async Task<Pagination<EventResponseDTO>> GetEventsAsync(EventSpecParams eventSpecParams, bool isUser = true)
        {
            var spec = isUser == true ? new EventSpecification(eventSpecParams, user: isUser) : new EventSpecification(eventSpecParams);
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

        public async Task<IEnumerable<WishList>> GetWishlistEventsAsync(Guid userId)
        {
            return await _wishlistRepo.ListAsync(new WishlistSpecification(userId));
        }

        public async Task<bool> AddEventToWishlist(Guid eventId, Guid userId)
        {
            var wishlist = new WishList()
            {
                EventId = eventId,
                UserId = userId
            };

            _wishlistRepo.Add(wishlist);

            return await _wishlistRepo.SaveAsync() > 0;
        }

        public async Task<bool> RemoveEventFromWishlist(Guid eventId, Guid userId)
        {
            var wishlist = await _wishlistRepo.GetEntityWithSpec(new WishlistSpecification(eventId, userId));

            if (wishlist == null)
            {
                return false;
            }

            _wishlistRepo.Delete(wishlist);

            return await _wishlistRepo.SaveAsync() > 0;
        }
    }
}
