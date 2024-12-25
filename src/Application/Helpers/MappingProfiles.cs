using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(m => m.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(m => m.Brand, o => o.MapFrom(s => s.Brand ?? null));
        }
    }
}
