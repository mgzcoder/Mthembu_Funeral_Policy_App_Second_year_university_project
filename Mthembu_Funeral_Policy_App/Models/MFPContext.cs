using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Mthembu_Funeral_Policy_App.Models;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class MFPContext:DbContext
    {
        public MFPContext() : base("DefaultConnection")
        {

        }

        public virtual DbSet<tlbClaim> tlbClaims { get; set; }
    }
}