using BusinessLogic;
using Data;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ServerApp.Controllers
{
    public class UserController : Controller
    {
        IUserRepository users = new UserRepository();

        // GET: User
        public ActionResult Index()
        {
            var generalList = users.GetAll();
            List<UserListViewModel> UsersList = new List<UserListViewModel>();

            foreach (var element in generalList)
            {
                UserListViewModel ModelUser = new UserListViewModel();
                ModelUser.City = element.City;
                ModelUser.Description = element.Description;
                ModelUser.Email = element.Email;
                ModelUser.Street = element.Street;
                ModelUser.UserName = element.UserName;
                UsersList.Add(ModelUser);

            }

            return View(UsersList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(UserAddViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", user);
            }
            var generalList = users.GetAll();
            if (user.Id!= null && user.Id != 0) //edit
            {
                var existingUser = generalList.Find(x => x.Id == user.Id);
                existingUser.Description = user.Description;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
                existingUser.Street = user.Street;
            }
            else //aici e add
            {
                IUserRepository users = new UserRepository();
                User user1 = new User();
                user1.City = user.City;
                user1.Description = user.Description;
                user1.Email = user.Email;
                user1.Street = user.Street;
                user1.UserName = user.UserName;

                users.AddUser(user1);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Users = users.GetAll();
            var model = Users.FirstOrDefault(x => x.Id == id);

            return View("Add", model);
        }

        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var generalList = users.GetAll();
            List<UserDeleteViewModel> UsersList = new List<UserDeleteViewModel>();

            foreach (var element in generalList)
            {
                UserDeleteViewModel ModelUser = new UserDeleteViewModel();
                ModelUser.City = element.City;
                ModelUser.Description = element.Description;
                ModelUser.Email = element.Email;
                ModelUser.Street = element.Street;
                ModelUser.UserName = element.UserName;
                UsersList.Add(ModelUser);

            }
            UserDeleteViewModel personalDetail= UsersList.FirstOrDefault(x => x.Id == id);

            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var generalList = users.GetAll();
            List<UserDeleteViewModel> UsersList = new List<UserDeleteViewModel>();

            foreach (var element in generalList)
            {
                UserDeleteViewModel ModelUser = new UserDeleteViewModel();
                ModelUser.City = element.City;
                ModelUser.Description = element.Description;
                ModelUser.Email = element.Email;
                ModelUser.Street = element.Street;
                ModelUser.UserName = element.UserName;
                UsersList.Add(ModelUser);

            }
            UserDeleteViewModel personalDetail = UsersList.FirstOrDefault(x => x.Id == id);
            UsersList.Remove(personalDetail);
            
            return RedirectToAction("Index");
        }
    }
}