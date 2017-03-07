using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using DocDesckApp.Models;
using System.Data.Entity;


namespace DocDesckApp.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        DocDeskContext db = new DocDeskContext();
       
        [HttpGet]

        public ActionResult Create()
        {
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            if(user != null)
            {
                var cabs = from cab in db.Activs
                           where cab.DepartmentId == user.DepartmentId
                           select cab;

                ViewBag.Organizations = new SelectList(db.Organizations, "Id", "ShortName");

                ViewBag.Cabs = new SelectList(cabs, "Id", "CabNumber");

                ViewBag.Categorys = new SelectList(db.Categorys, "Id", "Name");

                return View();
            }

            return RedirectToAction("LogOff", "Account");
        }
        //Создаем новые заявки
        [HttpPost]
        public ActionResult Create(Document document, HttpPostedFileBase error)
        {
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            if(user == null)
            {
                return RedirectToAction("LogOff", "Account");
            }

            if (ModelState.IsValid)
            {
                //Указываем статус открыта у заявки
                document.Status = (int)DocumentStatus.Open;
                //получаем время открытия
                DateTime current = DateTime.Now;

                //Создаем запись о жизненном цикле
                Lifecycle newLifecircle = new Lifecycle() { Opened = current };
                document.Lifecycle = newLifecircle;

                //Добавляем новый жизненный цикл документа
                newLifecircle.Id = Guid.NewGuid();
                db.Lifecircles.Add(newLifecircle);

                //Указываем пользователя документа
                document.UserId = user.Id;
                if(error != null)
                {
                    //получаем расширение
                    string ext = error.FileName.Substring(error.FileName.LastIndexOf('.'));
                    //сохраняем файл по определнному пути на сервере
                    string path = current.ToString("dd/MM/yyyy h:mm:ss").Replace(":", "_").Replace("/", ".") + ext;
                    error.SaveAs(Server.MapPath("~/Files/" + path));
                    document.File = path;
                }
                document.Id = Guid.NewGuid();
                db.Documents.Add(document);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(document);
    }
        public ActionResult Index()
        {
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();

            var documents = db.Documents.Where(d => d.UserId == user.Id) //Получаем документы пользователя
                .Include(d => d.Category)// добавляем категории
                .Include(d => d.Lifecycle) //добавляем жизненный цикл
                .Include(d => d.User)//добавляем данные о пользователях
                .Include(d => d.Organization)//Добавляем данные об организации
                .OrderByDescending(d => d.Lifecycle.Opened);

            return View(documents.ToList());
        }

        public ActionResult Details(Guid id)
        {
            Document document = db.Documents.Find(id);

            if(document != null)
            {
                //получаем кабинет
                var activ = db.Activs.Where(m => m.Id == document.ActivId);

                // так как кабинет у нас может быть не указан, и набор может возвращать 0 значений
                if (activ.Count()>0)
                {
                    document.Activ = activ.First();

                }
                //Получаем категорию
                document.Category = db.Categorys.Where(m => m.Id == document.CategoryId).First();
                document.Organization = db.Organizations.Where(m => m.Id == document.OrganizationId).First();
                
                return PartialView("_Details", document);
            }
            return View("Index");
        }
    }
}