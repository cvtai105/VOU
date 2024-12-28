using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventResponseDTO>()
            .ForMember(m => m.Id, o => o.MapFrom(s => s.Id))
            .ForMember(m => m.Name, o => o.MapFrom(s => s.Name))
            .ForMember(m => m.ImageUrl, o => o.MapFrom(s => s.ImageUrl))
            .ForMember(m => m.StartAt, o => o.MapFrom(s => s.StartAt))
            .ForMember(m => m.EndAt, o => o.MapFrom(s => s.EndAt))
                .ForMember(m => m.Status, o => o.MapFrom(s => (int)s.Status))
                .ForMember(m => m.Brand, o => o.MapFrom(s => s.Brand));

            CreateMap<Brand, BrandResponseDTO>()
                .ForMember(m => m.Id, o => o.MapFrom(s => s.Id))
                .ForMember(m => m.Name, o => o.MapFrom(s => s.Name))
                .ForMember(m => m.ImageUrl, o => o.MapFrom(s => s.ImageUrl))
                .ForMember(m => m.Field, o => o.MapFrom(s => s.Field))
                .ForMember(m => m.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(m => m.Email, o => o.MapFrom(s => s.Email))
                .ForMember(m => m.Latitude, o => o.MapFrom(s => s.Latitude))
                .ForMember(m => m.Longitude, o => o.MapFrom(s => s.Longitude));
        }
    }
}
