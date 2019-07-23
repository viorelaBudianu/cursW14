using BusinessLogic;
using Data;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IUserRepository users = new UserRepository();

            return View(users.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Add",user);
            }
            IUserRepository users = new UserRepository();

            users.AddUser(user);


            return RedirectToAction("Index");

        }
    }
}