using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Parcel.Models;

namespace Parcel.Controllers
{
    public class ParcelsController : Controller
    {
        [HttpGet("/parcels")]
        public ActionResult Index()
        {
            List<ParcelVariable> allParcels = ParcelVariable.GetAll();
            return View(allParcels);
        }

        [HttpGet("/parcels/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/parcels")]
        public ActionResult Create(int sideA, int sideB, int sideC, int weight, string note)
        {
            if ( sideA > 0 && sideB > 0 && sideC >0 && weight > 0 && note.Length > 0)
            {
                ParcelVariable myParcel = new ParcelVariable(sideA, sideB, sideC, weight, note);
                 
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet("/parcels/{id}")]
        public ActionResult Show(int id)
        {
            ParcelVariable foundParcel = ParcelVariable.Find(id);
            return View(foundParcel);
        }

    }
}

