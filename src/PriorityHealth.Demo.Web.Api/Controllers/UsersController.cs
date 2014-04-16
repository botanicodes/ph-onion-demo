using Ninject;
using PriorityHealth.Core.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PriorityHealth.Demo.Web.Api.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        [Inject]
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            //ViewBag.Data = new User() { Name = "Jared Dickson", Email = "jared.dickson@spectrumhealth.org" };
            ViewBag.Data = _userRepository.GetAll();
            return View();
        }

    }
}
