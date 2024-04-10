using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dignos.Entities;

namespace Dignos.Controllers
{

    public class ClientController : Controller
    {
        private readonly DignosUtangananContext _context;
        public ClientController(DignosUtangananContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   
            ViewData["types"] = _context.UserTypes.ToList();
            var client = _context.ClientInfos.ToList();
            return View(client);
        }

         [HttpGet]

        public IActionResult Create()
        {
            var Usertype = _context.UserTypes.ToList();
            ViewData["Usertype"] = Usertype;

            return View();
        }

        [HttpPost]

        public IActionResult Create(ClientInfo b)
        {
            _context.ClientInfos.Add(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var Usertype = _context.UserTypes.ToList();
            var clientinfo = _context.ClientInfos.FirstOrDefault(q => q.Id == id);
            ViewData["Usertype"] = Usertype;
            return View(clientinfo);
        }

        [HttpPost]

        public IActionResult Update(ClientInfo b)
        {
            _context.ClientInfos.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var clientinfo = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(clientinfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


       
    }
}