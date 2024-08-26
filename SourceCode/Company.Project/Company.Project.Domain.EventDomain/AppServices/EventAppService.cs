using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
//using Company.Project.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Company.Project.EventDomain.Domain.Type;

namespace Company.Project.EventDomain.AppServices
{
    public class EventAppService : AppService, IEventAppService
    {
        private IMapper mapper;

        private IEventRepository repository;

        public EventAppService(IEventRepository eventRepository, IMapper _mapper)
        {
            mapper = _mapper;
            repository = eventRepository;
        }
        public EventAppService(IEventUnitOfWorks unitOfWork,IEventRepository eventRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager) 
        {
            this.mapper = mapper;
            this.repository = eventRepository;
        }

        public OperationResult<Event> getEventById(int id)
        {
            Event _event = repository.Find(x => x.Id == id);
            OperationResult operationResult;
            operationResult = UnitOfWork.Commit();
            return new OperationResult<Event>(_event, operationResult.IsSuccess, operationResult.MainMessage, operationResult.AssociatedMessages.ToList<Message>());

        }

        public IEnumerable<Event> getMyUpcomingEvents(string id)
        {
            IEnumerable<Event> _event = repository.Get(evnt => evnt.UserEmailID == id && evnt.Date.CompareTo(DateTime.Now)>=0);
            //OperationResult operationResult;
            //operationResult = UnitOfWork.Commit();
            return _event;
        }

        public IEnumerable<Event> getMyPastEvents(string id)
        {
            IEnumerable<Event> _event = repository.Get(evnt => evnt.UserEmailID == id && evnt.Date.CompareTo(DateTime.Now)< 0);
            // OperationResult operationResult;
            //operationResult = UnitOfWork.Commit();
            return _event;
        }
        public OperationResult<EventDTO> Create(EventDTO eventDTO)
        {
            Event _event = mapper.Map<EventDTO, Event>(eventDTO);
            _event.IsActive = true;
            

            _event.CreatedOnDate = DateTime.Now;

            OperationResult operationResult;

            repository.Create(_event);

            operationResult = UnitOfWork.Commit();

            eventDTO.Id = _event.Id;

            return new OperationResult<EventDTO>(eventDTO, operationResult.IsSuccess, operationResult.MainMessage, operationResult.AssociatedMessages.ToList<Message>());
            
        }

        public OperationResult<IEnumerable<EventDTO>> getUpcomingPublicEvents()
        {
            IEnumerable<Event> events = repository.Get(eve => eve.Type.ToLower() == "public" && eve.Date.CompareTo(DateTime.Now)>=0);
            IList<EventDTO> eventDTOs = new List<EventDTO>();
            eventDTOs = mapper.Map<IEnumerable<Event>, IList<EventDTO>>(events);
            Message message = new Message(string.Empty, "Return Successfully");

            return new OperationResult<IEnumerable<EventDTO>>(eventDTOs, true, message);
        }

        public OperationResult<IEnumerable<EventDTO>> getPastPublicEvents()
        {
            IEnumerable<Event> events = repository.Get(eve => eve.Type.ToLower() == "public" && eve.Date.CompareTo(DateTime.Now)<0);
            IList<EventDTO> eventDTOs = new List<EventDTO>();
            eventDTOs = mapper.Map<IEnumerable<Event>, IList<EventDTO>>(events);
            Message message = new Message(string.Empty, "Return Successfully");

            return new OperationResult<IEnumerable<EventDTO>>(eventDTOs, true, message);
        }

        public OperationResult<IEnumerable<EventDTO>> getUpcomingPrivateEvents()
        {
            IEnumerable<Event> events = repository.Get(eve => eve.Type.ToLower() == "private" && eve.Date.CompareTo(DateTime.Now)>=0);
            IList<EventDTO> eventDTOs = new List<EventDTO>();
            eventDTOs = mapper.Map<IEnumerable<Event>, IList<EventDTO>>(events);
            Message message = new Message(string.Empty, "Return Successfully");

            return new OperationResult<IEnumerable<EventDTO>>(eventDTOs, true, message);
        }

        public OperationResult<IEnumerable<EventDTO>> getPastPrivateEvents()
        {
            IEnumerable<Event> events = repository.Get(eve => eve.Type.ToLower() == "private"&& eve.Date.CompareTo(DateTime.Now)<0);
            IList<EventDTO> eventDTOs = new List<EventDTO>();
            eventDTOs = mapper.Map<IEnumerable<Event>, IList<EventDTO>>(events);
            Message message = new Message(string.Empty, "Return Successfully");

            return new OperationResult<IEnumerable<EventDTO>>(eventDTOs, true, message);
        }

        public IEnumerable<Event> getAllEvents()
        {
            IEnumerable<Event> events = repository.All();

            return events;
        }

        public void Update(Event _event)
        {
            
            repository.Update(_event);
            
            

        }

        public void deleteById(int id)
        {
            repository.Delete(id);
        }
    }
}
