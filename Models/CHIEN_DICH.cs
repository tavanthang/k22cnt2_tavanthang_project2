//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace k22cnt3_tavanthang_project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHIEN_DICH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHIEN_DICH()
        {
            this.SAN_PHAM = new HashSet<SAN_PHAM>();
        }
    
        public int CHIEN_DICH_ID { get; set; }
        public string TEN_CHIEN_DICH { get; set; }
        public string MO_TA { get; set; }
        public System.DateTime THOI_GIAN_BAT_DAU { get; set; }
        public System.DateTime THOI_GIAN_KET_THUC { get; set; }
        public string DIEN_TICH { get; set; }
        public Nullable<int> MAX_THAM_GIA { get; set; }
        public Nullable<int> SO_NGUOI_DA_DANG_KY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SAN_PHAM> SAN_PHAM { get; set; }
    }
}
