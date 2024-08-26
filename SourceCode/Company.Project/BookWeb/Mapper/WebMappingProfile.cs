using AutoMapper;
using BookWeb.Models;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;

namespace BookWeb.Mapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() : base("WebMappingProfile") 
        {
            CreateMap<EventViewModel, EventDTO>().ReverseMap();
            
        }
    }
}
