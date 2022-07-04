using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks_19001700.Models
{
    public class Job_TypeModel
    {

        [Display(Name = "Job_Type_ID")]
        [Required(ErrorMessage = "Job_Jype_ID is required.")]
        public string Job_Type_ID { get; set; }

        [Required(ErrorMessage = "Daily rate is required.")]
        public double Daily_Rate { get; set; }

    }
}