using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class tlbClaim
    {

      
        [Key]
        public long id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Policy Number")]
        public long Policy_Number { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("SA ID Number")]
        public long SA_ID_Number { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Cellphone Number")]
        public string Cellphone_Number { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Branch Name")]
        public string Branch_Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Branch Code")]
        public string Branch_Code { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Card Number")]
        public string Card_NO { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Account Number")]
        public string Account_NO { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Deceased SA ID Number")]
        public long Deceased_SA_ID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Deceased First Name")]
        public string Deceased_First_Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Deceased Last Name")]
        public string Deceased_Last_Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Cause of Death")]
        public string Death_Course { get; set; }
        public string Status { get; set; }

      
    }
}