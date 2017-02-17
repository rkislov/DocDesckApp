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
    
    [HttpGet]
    public ActionResult Activ()
    {
            ViewBag.Activs = db.Activs.Include(s=>s.Department);
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View();
    }
    //добавление отдела с последующим отображением
    [HttpPost]
    public ActionResult Activ(Activ activ)
    {
        if (ModelState.IsValid)
        {
            activ.Id = Guid.NewGuid();
            db.Activs.Add(activ);
            db.SaveChanges();
        }
            ViewBag.Activs = db.Activs.Include(s => s.Department);
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View(activ);
    }

    //удаление отдела по id
    public ActionResult DeleteActiv(Guid id)
    {
        Activ activ = db.Activs.Find(id);
        db.Activs.Remove(activ);
        db.SaveChanges();
        return RedirectToAction("Activ");
    }

        [HttpGet]
        public ActionResult Categorys()
        {
            ViewBag.Categorys = db.Categorys;
            return View();
        }
        //добавление отдела с последующим отображением
        [HttpPost]
        public ActionResult Categorys(Category cat)
        {
            if (ModelState.IsValid)
            {
                cat.Id = Guid.NewGuid();
                db.Categorys.Add(cat);
                db.SaveChanges();
            }
            ViewBag.Categorys  = db.Categorys;
            return View(cat);
        }

        //удаление отдела по id
        public ActionResult DeleteCategory(Guid id)
        {
            Category cat = db.Categorys.Find(id);
            db.Categorys.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Categorys");
        }
    }
}