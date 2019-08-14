using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;



namespace HairSalon.Controllers
{
    public class ClientController : Controller {

        private readonly HairSalonContext _db;

        public ClientController(HairSalonContext db){
            _db = db;
        }

        public ActionResult Create(int id)
        {
            Stylist s =_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id));
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
} 