//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BranchOffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchOffice()
        {
            this.Sales = new HashSet<Sale>();
            this.Staffs = new HashSet<Staff>();
        }
    
        public byte OfficeID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }

        public bool OfficeIDEquals(byte pIdNumber)
        {
            throw new NotImplementedException();
        }
    }
}
