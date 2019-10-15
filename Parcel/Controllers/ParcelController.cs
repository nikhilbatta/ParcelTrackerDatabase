using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Parcel.Models;
using System.Linq;
using System;

namespace Parcel.Controllers
{
    public class ParcelsController : Controller
    {
        private readonly ParcelContext _db;

        public ParcelsController(ParcelContext db)
        {
            _db = db;
        }

        [HttpGet("/parcels")]
        public ActionResult Index()
        {
            List<ParcelVariable> model = _db.Parcels.ToList();
            return View(model);
        }

        [HttpGet("/parcels/new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/parcels/new")]
        public ActionResult Create(ParcelVariable newParcel)
        {
            if (newParcel.SideA > 0 && newParcel.SideB > 0 && newParcel.SideC >0 && newParcel.Weight > 0 && newParcel.Note.Length > 0)
            {
                Console.WriteLine(newParcel);
                _db.Parcels.Add(newParcel);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}

