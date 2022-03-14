using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class ParentCoverQoutation
    {
        [Required]
        [Display(Name ="Benefit Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Number of people")]
        public int NumMember { get; set; }
        [Required]
        [Display(Name = "Monthly Premium")]
        public Double TotalPrice { get; set; }
        
        public double ParentQouteCalc()
        {
            Double Total=0;
            if (Type=="Bronze")
            {
                Total = NumMember * 150 * 0.05 + 150;
                    
            }
            else if (Type=="Silver")
            {
                Total = NumMember * 200 * 0.05 + 200;
            }
            else
            {
                Total = NumMember * 300 * 0.05 + 300;
            }
            return Total;
        }
    }
}