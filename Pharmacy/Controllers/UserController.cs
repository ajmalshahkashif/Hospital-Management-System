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
            Person obj = new Person();

            obj.FirstName = user.FirstName;
            obj.LastName = user.LastName;
            obj.Email = user.Email;
            obj.PhoneNo = user.PhoneNo;
            obj.MobileNo = user.MobileNo;
            obj.LocationId = user.ID;
            obj.Age = user.Age;
            obj.Gender = user.Gender;
            obj.Weight = user.Weight;
            obj.Height = user.Height;
            obj.RoleId = user.RoleTypeID;
            obj.ReasonForSeeingDoctor = user.ReasonForSeeingDoctor;
            obj.Comments = user.Comments;

            context.People.Add(obj);
            context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public ActionResult AllUsers()
        {

            return View();
        }



        #region DDL population

        //Replace all ddl with the below. Below is just a sample with no usage
        //public JsonResult ddlItemType()
        //{
        //    IGenericRepo<Location> repo = new GenericRepo<Location>();
        //    var obj = repo.GetAll();
        //    List<Location> locations = new List<Location>();
        //    foreach (var o in obj)
        //    {
        //        Location l = new Location();
        //        l.Id = o.Id;
        //        l.Name = o.Name;
        //        locations.Add(l);
        //    }

        //    return Json(locations, JsonRequestBehavior.AllowGet);
        //    //var itemTypeList = context.ItemTypes.Select(x => new { ID = x.ID, Name = x.Name }).ToList();
        //    //return Json(itemTypeList, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ddlRoleType()
        //{
        //    var itemTypeList = context.Roles.Select(x => new { ID = x.Id, Name = x.RoleName }).ToList();
        //    return Json(itemTypeList, JsonRequestBehavior.AllowGet);
        //}

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

        public JsonResult ddlDoctor(int userId)
        {
            //Below is retreiving a list of docs successfully
            //var docList = context.People.GroupJoin(context.Roles, a => a.RoleId, b => b.Id, (x, y)
            //    => new { tableA = x, tableB = y })
            //    .SelectMany(x => x.tableB.DefaultIfEmpty(), (x, y) => new { TableA = x.tableA, TableB = y }).
            //    Select(p => new { ID = p.TableA.ID, Name = p.TableA.LastName });


            var role = context.Roles.Where(x => x.Id == userId).Select(y => y.RoleName).FirstOrDefault();

            if (role == "Patient")
            {
                var docList = context.People.GroupJoin(context.Roles, a => a.RoleId, b => b.Id, (x, y) => new { tableA = x, tableB = y })
                .SelectMany(x => x.tableB.DefaultIfEmpty(), (x, y) => new { TableA = x.tableA, TableB = y }).Select(p => new { ID = p.TableA.ID, Name = p.TableA.LastName });
                return Json(docList, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult ddlRoles()
        {
            var rolesList = context.Roles.Select(x => new { ID = x.Id, Name = x.RoleName }).ToList();

            return Json(rolesList, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}