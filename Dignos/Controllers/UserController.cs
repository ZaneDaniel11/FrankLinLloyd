using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dignos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dignos.Controllers
{
    public class UserController : Controller
    {

     

         private readonly DignosUtangananContext _context;
        public UserController(DignosUtangananContext context) 
        {
             _context = context;
        }

         public IActionResult Index()
        {
            var model = _context.UserTypes.ToList();
            return View(model);
        }

        [HttpGet]

         public IActionResult Create()
         {
            var UserType = _context.UserTypes.ToList();
            
            ViewData["Usertype"] = UserType;

            return View();
         }

         [HttpPost]
         public IActionResult Create(UserType b)
         {
             _context.UserTypes.Add(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
         }

         [HttpGet]

        public IActionResult Update(int id)

        {
            var UserType = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            return View(UserType);
        }

        [HttpPost]
        public IActionResult Update(UserType b)
        {
            _context.UserTypes.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var UserType = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            _context.UserTypes.Remove(UserType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}