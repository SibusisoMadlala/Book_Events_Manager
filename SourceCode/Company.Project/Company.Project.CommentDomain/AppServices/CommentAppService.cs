using AutoMapper;
using Company.Project.CommentDomain.AppServices.DTOs;
using Company.Project.CommentDomain.Repository;
using Company.Project.CommentDomain.UoW;
using Company.Project.Core.AppServices;
using Company.Project.Core.Domain.Repository;
using Company.Project.Core.ExceptionManagement;
using Company.Project.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.AppServices
{
    public class CommentAppService : AppService, ICommentAppService
    {
        private IMapper mapper;
        private ICommentRepository repository;

        public CommentAppService(IMapper mapper, ICommentRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public CommentAppService(ICommentUnitOfWork unitOfWork, ICommentRepository repository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public IEnumerable<CommentDTO> getCommentsByEventId(int eventId)
        {
            IEnumerable<CommentDTO> comments = repository.Get(com => com.EventId == eventId);

            return comments;
        }

        public CommentDTO Create(CommentDTO eventDTO)
        {

            eventDTO.CreatedOnDate = DateTime.Now;

            OperationResult operationResult;

            repository.Create(eventDTO);

            return eventDTO;

        }


    }
}
