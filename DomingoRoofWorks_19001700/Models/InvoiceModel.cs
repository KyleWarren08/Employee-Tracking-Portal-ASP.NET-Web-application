using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomingoRoofWorks_19001700.Models
{
    public class InvoiceModel
    {
        [Display(Name = "Invoice_ID")]
        [Required(ErrorMessage = "Invoice ID is required.")]
        public string Invoice_ID { get; set; }

        [Required(ErrorMessage = "Invoice Material ID is required.")]
        public string Invoice_Material_ID { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public string Customer_ID { get; set; }

        [Required(ErrorMessage = "Invoice Job Card is required.")]
        public string Job_Card { get; set; }

    }
}