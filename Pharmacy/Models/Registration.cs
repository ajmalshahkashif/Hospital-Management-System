using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.Models
{
    public class Registration
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
        public string MobileNo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Provide Gender")]
        public string Gender { get; set; }
        
        public string Weight { get; set; }
        
        public string Height { get; set; }


        [Display(Name = "Doctor Name")]
        [Required(ErrorMessage = "Please Provide Doctor Name")]
        public string DoctorName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Reason for Seeing Doctor")]
        public string ReasonForSeeingDoctor { get; set; }


    }
}

