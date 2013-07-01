using CacheMainfestOfflineStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheMainfestOfflineStorage.Controllers
{
    public class ContactController : Controller
    {
        DataContext DB = new DataContext();

        public JsonResult GetAll()
        {
            var contacts = DB.Contacts.ToList();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(string name)
        {
            var contact = new Contact()
            {
                Name = name
            };

            DB.Contacts.Add(contact);
            DB.SaveChanges();

            return Json(contact);
        }

        [HttpPost]
        public JsonResult Delete(string name)
        {
            var contact = DB.Contacts.Single(x => x.Name == name);

            DB.Contacts.Remove(contact);
            DB.SaveChanges();

            return Json(true);
        }
    }
}
