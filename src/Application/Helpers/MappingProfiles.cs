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
                .ForMember(m => m.Brand, o => o.MapFrom(s => s.Brand))
                .ForMember(m => m.Game, o => o.MapFrom(s => s.Game));
        }
    }
}
