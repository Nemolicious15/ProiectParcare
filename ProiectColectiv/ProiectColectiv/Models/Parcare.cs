//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProiectColectiv.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parcare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parcare()
        {
            this.LocParcare = new HashSet<LocParcare>();
        }
    
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Locatie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocParcare> LocParcare { get; set; }
    }
}
