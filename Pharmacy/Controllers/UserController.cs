using Pharmacy.DB;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class UserController : BaseController
    {

        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(UserValidation user)
        {
            User obj = new User();

            obj.FirstName = user.FirstName;
            obj.LastName = user.LastName;
            obj.Email = user.Email;
            obj.PhoneNo = user.PhoneNo;
            obj.MobileNo = user.MobileNo;
            obj.DateOfBirth = user.DOB;
            obj.Gender = user.Gender;
            obj.Weight = user.Weight;
            obj.Height = user.Height;
            obj.ReasonForSeeingDoctor = user.ReasonForSeeingDoctor;
            obj.Comments = user.Comments;

            context.Users.Add(obj);
            context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public ActionResult AllUsers()
        {

            return View();
        }



        #region DDL population

        public JsonResult ddlItemType()
        {
            IGenericRepo<Location> repo = new GenericRepo<Location>();
            var obj = repo.GetAll();
            List<Location> locations = new List<Location>();
            foreach (var o in obj)
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

        public JsonResult ddlRoleType()
        {
            var itemTypeList = context.Roles.Select(x => new { ID = x.Id, Name = x.RoleName }).ToList();
            return Json(itemTypeList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult ddlCountry()
        //{
        //    var countryList = context.Locations.Where(x => x.Type == "country").Select(x => new { ID = x.Id, Name = x.Name }).ToList();
        //    return Json(countryList, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult ddlState()
        {
            var stateList = context.Locations.Where(x => x.Type == "state").Select(x => new { ID = x.Id, Name = x.Name }).ToList();

            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ddlCity(int stateId)
        {
            var cityList = context.Locations.Where(x => x.Type == "city" && x.ParentId == stateId).Select(x => new { ID = x.Id, Name = x.Name }).ToList();

            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}