using AutoMapper;
using BookWeb.Controllers;
using Castle.Core.Logging;
using Company.Project.Core.Data.DataAccess;
using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.Mapper;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BookWebTest
{
    public class Tests
    {
        private IMapper _mapper;
        private IEventRepository _repository;

        [SetUp]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EventMappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
            _repository = new EventRepository(new EventDomainDbContext());
            // _controller = new EventController(mapper, new EventRepository(new EventDomainDbContext()));
        }

        [Test]
        public void getMyPastEvents_Test1()
        {

            var eventAppService = new EventAppService(_repository, _mapper);
            var result = eventAppService.getMyPastEvents("sbu@gmail.com");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void getMyUpcomingEvents_Test()
        {
            var eventAppService = new EventAppService(_repository, _mapper);
            var result = eventAppService.getMyUpcomingEvents("sbu@gmail.com");
            Assert.That(result, Is.Not.Null);
        }

        [Test]

        public void getUpcomingPublicEvents_Test()
        {
            var eventAppService = new EventAppService(_repository, _mapper);
            var result = eventAppService.getUpcomingPublicEvents();
            Assert.That(result, Is.Not.Null);
        }

        [Test]

        public void getAllEventsTest()
        {
            var eventAppService = new EventAppService(_repository, _mapper);
            var result = eventAppService.getAllEvents();
            Assert.That(result, Is.Not.Null);
        }

        [Test]

        public void getPastPublicEvents_test()
        {
            var eventAppService = new EventAppService(_repository, _mapper);
            var result = eventAppService.getPastPublicEvents();
            Assert.That(result, Is.Not.Null);
        }
    }
}