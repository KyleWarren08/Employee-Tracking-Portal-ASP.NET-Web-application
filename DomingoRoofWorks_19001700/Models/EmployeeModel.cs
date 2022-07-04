using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks_19001700.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee_ID")]
        [Required(ErrorMessage = "Employee ID is required.")]
        public string Employee_ID { get; set; }

        [Required(ErrorMessage = "Employee full name is required.")]
        public string Employee_Name { get; set; }     
    }
}