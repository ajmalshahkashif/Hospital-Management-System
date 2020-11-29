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

        public string FirstName { get; set; }


        [Required(ErrorMessage = "provide BarCode")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string MobileNo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public DateTime DOB { get; set; }



    }
}