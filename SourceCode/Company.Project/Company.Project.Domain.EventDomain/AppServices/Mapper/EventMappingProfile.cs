using AutoMapper;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.AppServices.Mapper
{
    
    public class EventMappingProfile : Profile
    {
            public EventMappingProfile() : base("EventMappingProfile")
            {

                CreateMap<EventDTO, Event>().ReverseMap();
            _ =CreateMap<IEventUnitOfWorks, EventUnitOfWorks>().ReverseMap();
                CreateMap<IEventRepository, EventRepository>().ReverseMap();
            }

        
    }

}
