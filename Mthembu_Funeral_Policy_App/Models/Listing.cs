using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class Listing
    {
        [Key]
        public int listing { get; set; }
    }
}