using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.AppServices
{
    public interface IEventAppService : IAppService
    {
        OperationResult<EventDTO> Create(EventDTO eventDTO);
        IEnumerable<Event> getAllEvents();

        OperationResult<IEnumerable<EventDTO>> getUpcomingPublicEvents();

        OperationResult<IEnumerable<EventDTO>> getUpcomingPrivateEvents();
        OperationResult<IEnumerable<EventDTO>> getPastPublicEvents();

        OperationResult<IEnumerable<EventDTO>> getPastPrivateEvents();
        public OperationResult<Event> getEventById(int id);

        public IEnumerable<Event> getMyUpcomingEvents(string id);
        public IEnumerable<Event> getMyPastEvents(string id);
        public void deleteById(int id);
        public void Update(Event _event);
    }
}
