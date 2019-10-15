using Microsoft.AspNetCore.Mvc;
using Parcel.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parcel.Models
{
    public class CategoriesController : Controller
    {
        private readonly ParcelContext _db;
            public CategoriesController(ParcelContext db)
            {
                _db = db;
            }
            [HttpGet("/categories")]
            public ActionResult Index()
            {
                List<Category> model = _db.Categories.ToList();
                return View(model);
            }
            [HttpGet("/categories/new")]
             public ActionResult Create()
                {
                return View();
                }
            [HttpPost("/categories/new")]
            public ActionResult Create(Category category)
            {
             _db.Categories.Add(category);
             _db.SaveChanges();
            return RedirectToAction("Index");
            }
         }
}