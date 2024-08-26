using AutoMapper;
using Company.Project.CommentDomain.AppServices.Mapper;
using Company.Project.CommentDomain.AppServices;
using Company.Project.CommentDomain.Data.DBContext;
using Company.Project.CommentDomain.Repository;
using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.AppServices.Mapper;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
//using Company.Project.ProductDomain.AppServices.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Company.Project.CommentDomain.Domain;
using Company.Project.CommentDomain.AppServices.DTOs;



namespace BookWeb.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        // GET: EventController


        private IEventAppService _eveAppService;
        private IEventUnitOfWorks _eventUnit;
        private IEventRepository _eventRepository;
        private IExceptionManager _exceptionManager;
        private IMapper _mapper;
        

        public EventController(IMapper mapper, IEventUnitOfWorks unitOfWork, IEventRepository eventRepository, IExceptionManager exceptionManager)
        {
            //_eventUnit = unitOfWork;
            _eventUnit = unitOfWork;
            _mapper = mapper;
            _exceptionManager = exceptionManager;
            _eventRepository = eventRepository;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invites()
        {
            return View();
        }

        public ActionResult MyEvents()
        { return View(); }


        /*public ActionResult MyComments(CommentDTO comment, Event _event) {

            comment.UserId = User.Identity?.Name;
            comment.EventId = _event.Id;
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommentMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            ICommentAppService commentAppService = new CommentAppService(mapper, new CommentRepository(new CommentDbContext()));

            commentAppService.Create(comment);
            return RedirectToAction(nameof(Details));


        }*/

        public ActionResult MyComments(CommentDTO _comment, int EventId, string comment)
        {

            _comment.UserId = User.Identity?.Name;
            _comment.EventId = EventId;
            _comment.comment = comment;
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommentMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            ICommentAppService commentAppService = new CommentAppService(mapper, new CommentRepository(new CommentDbContext()));

            commentAppService.Create(_comment);
            //return RedirectToAction(nameof(Details));
            return RedirectToAction(nameof(Index));


        }
        public ActionResult Comments(int EventId)
        {
            
            return View();
        }

        // GET: EventController/Details/5
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id) 
        {
            _eveAppService = new EventAppService(_eventUnit, _eventRepository, _mapper, _exceptionManager);
            Event _event = _eveAppService.getEventById(id).Data;
            return View(_event);
        }

        /*[HttpGet]
        public ActionResult Details(Event _event)
        {
            return View(_event);
        }*/

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(Event _event)
        {
            try
            {
                _event.UserEmailID = User.Identity?.Name!;

                EventDTO eventDTO = _mapper.Map<EventDTO>(_event);
                _eveAppService = new EventAppService(_eventUnit, _eventRepository, _mapper, _exceptionManager);
                _eveAppService.Create(eventDTO);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Details));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited(Event _event, int id)
        {
            _event.Id = id;
            _eveAppService = new EventAppService(_eventUnit, _eventRepository, _mapper, _exceptionManager);
            _eveAppService.Update(_event);
            return RedirectToAction("Index", "Home");

        }
        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {

            _eveAppService = new EventAppService(_eventUnit, _eventRepository, _mapper, _exceptionManager);
            
            return View(_eveAppService.getEventById(id).Data);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            _eveAppService = new EventAppService(_eventUnit, _eventRepository, _mapper, _exceptionManager);
            _eveAppService.deleteById(id);
            return RedirectToAction("Index","Home");
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
