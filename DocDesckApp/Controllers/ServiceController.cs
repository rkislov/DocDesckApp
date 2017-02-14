using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DocDesckApp.Models;

namespace DocDesckApp.Controllers
{
    [Authorize (Roles = "Администратор")]
    public class ServiceController : Controller
    {
        DocDeskContext db = new DocDeskContext();
        // GET: Service
       [HttpGet]
       public ActionResult Departments()
        {
            ViewBag.Departments = db.Departments;
            return View();
        }
        //добавление отдела с последующим отображением
        [HttpPost]
        public ActionResult Departments(Department depo)
        {
            if (ModelState.IsValid)
            {
                depo.Id = Guid.NewGuid();
                db.Departments.Add(depo);
                db.SaveChanges();
            }
            ViewBag.Departments = db.Departments;
            return View(depo);
        }

        //удаление отдела по id
        public ActionResult DeleteDepartment(Guid id)
        {
            Department depo = db.Departments.Find(id);
            db.Departments.Remove(depo);
            db.SaveChanges();
            return RedirectToAction("Departments");
        }
    }
}