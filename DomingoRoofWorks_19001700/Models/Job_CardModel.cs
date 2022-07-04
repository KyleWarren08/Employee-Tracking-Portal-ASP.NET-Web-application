using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks_19001700.Models
{
    public class Job_CardModel
    {
        [Display(Name = "Job_Card")]
        [Required(ErrorMessage = "Job Card is required.")]
        public string Job_Card { get; set; }

        [Required(ErrorMessage = "Job Type is required.")]
        public string Job_Type_ID { get; set; }

        [Required(ErrorMessage = "Days for job is required.")]
        public int Days_For_Job { get; set; }
    }
}