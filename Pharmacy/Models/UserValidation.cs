using Pharmacy.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.Models
{
    public class UserValidation
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Provide Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please Provide Mobile No")]
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        public Nullable<int> City { get; set; }

        public string State { get; set; }

        public Nullable<int> Country { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Invalid Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Provide Gender")]
        public string Gender { get; set; }

        [Display(Name = "Weight(Kg)")]
        public Nullable<int> Weight { get; set; }

        [Display(Name = "Height(inches)")]
        public Nullable<int> Height { get; set; }


        [Display(Name = "Doctor Name")]
        [Required(ErrorMessage = "Please Provide Doctor Name")]
        public string DoctorName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Comments(if any)")]
        public string Comments { get; set; }

        [Display(Name = "Reason for Seeing Doctor")]
        public string ReasonForSeeingDoctor { get; set; }


        [Display(Name = "Role Type")]
        [Required(ErrorMessage = "provide Item Type")]
        public Nullable<int> RoleTypeID { get; set; }



    }
}

