using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Helpers;
using Domain.Entities;
using Domain.Specifications.EventSpec;

namespace Application.Services.EventServices
{
    public interface IEventServices
    {
        Task<Event?> GetEventByIDAsync(Guid eventId);
        Task<Pagination<EventResponseDTO>> GetEventsAsync(EventSpecParams eventSpecParams, bool isUser = true);

        Task<bool> CreateEventAsync(Event newEvent);
        Task<bool> UpdateEventAsync(Event updatedEvent);
        Task<bool> DeleteEventAsync(Guid eventId);
        Task<bool> AddEventToWishlist(Guid eventId, Guid userId);
        Task<bool> RemoveEventFromWishlist(Guid eventId, Guid userId);
    }
}
