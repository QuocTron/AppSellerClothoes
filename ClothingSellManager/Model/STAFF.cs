namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFF")]
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            BILLs = new HashSet<BILL>();
        }

        [Key]
        [StringLength(10)]
        public string IDNHANVIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string FULLNAME { get; set; }

        [StringLength(10)]
        public string MABOPHANSTAFF { get; set; }

        [StringLength(10)]
        public string PASSWORD { get; set; }

        [Column(TypeName = "image")]
        public byte[] AVATA { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILLs { get; set; }

        public virtual POSITION POSITION { get; set; }
    }
}
