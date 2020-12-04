using Pharmacy.DB;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class PatientController : Controller
    {
        private IGenericRepo<User> repository = null;

        public PatientController()
        {
        }
        public PatientController(IGenericRepo<User> repository)
        {
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult AllPatients()
        {

            return View();
        }


        [HttpGet]
        public ActionResult AddPatients()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPatients(User obj)
        {
            repository.Insert(obj);
            return RedirectToAction("AddPatients");
        }


        #region DDL population

        public JsonResult ddlItemType()
        {
            IGenericRepo<Location> repo = new GenericRepo<Location>();
            var obj = repo.GetAll();
            List<Location> locations = new List<Location>();
            foreach(var o in obj)
            {
                Location l = new Location();
                l.Id = o.Id;
                l.Name = o.Name;
                locations.Add(l);
            }
            
            return Json(locations, JsonRequestBehavior.AllowGet);
            //var itemTypeList = context.ItemTypes.Select(x => new { ID = x.ID, Name = x.Name }).ToList();
            //return Json(itemTypeList, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}