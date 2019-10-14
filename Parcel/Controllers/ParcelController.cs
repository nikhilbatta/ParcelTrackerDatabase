using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Parcel.Models;
using System.Linq;

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
            // List<ParcelVariable> allParcels = ParcelVariable.GetAll();
            return View();
        }

        [HttpGet("/parcels/new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/parcels/new")]
        public ActionResult Create(ParcelVariable newParcel)
        {
            if ( newParcel.SideA > 0 && newParcel.SideB > 0 && newParcel.SideC >0 && newParcel.Weight > 0 && newParcel.Note.Length > 0)
            {
                _db.Parcels.Add(newParcel);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}

