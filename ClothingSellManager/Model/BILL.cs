namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILL")]
    public partial class BILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILL()
        {
            BILLINFOes = new HashSet<BILLINFO>();
        }

        [Key]
        [StringLength(10)]
        public string MABILL { get; set; }

        public DateTime? GIORA { get; set; }

        public int TRANGTHAI { get; set; }

        public double DISCOUNT { get; set; }

        public double TOTALPRICE { get; set; }

        public int? STT { get; set; }

        [StringLength(10)]
        public string MANHAVIEN { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINFO> BILLINFOes { get; set; }
    }
}
