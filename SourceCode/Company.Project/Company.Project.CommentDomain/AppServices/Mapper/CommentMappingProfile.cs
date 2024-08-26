using AutoMapper;
using Company.Project.CommentDomain.AppServices.DTOs;
using Company.Project.CommentDomain.Domain;
using Company.Project.CommentDomain.Repository;
using Company.Project.CommentDomain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.AppServices.Mapper
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile() : base("CommentMappingProfile")
        {

            CreateMap<CommentDTO, Comment>().ReverseMap();
            _ = CreateMap<ICommentUnitOfWork, CommentUnitOfWork>().ReverseMap();
            CreateMap<ICommentRepository, CommentRepository>().ReverseMap();
        }
        
    }
}
