//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mthembu_Funeral_Policy_App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tlbPayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tlbPayment()
        {
            this.tlbPolicies = new HashSet<tlbPolicy>();
        }
        [Key]
        public int PaymentID { get; set; }
        public Nullable<long> tlbClient_ID2 { get; set; }
        public System.DateTime Payment_Date { get; set; }
        public decimal Due_Amount { get; set; }
    
        public virtual tlbClient tlbClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tlbPolicy> tlbPolicies { get; set; }
    }
}
