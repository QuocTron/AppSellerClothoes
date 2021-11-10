namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENT")]
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            BILLs = new HashSet<BILL>();
        }

        [Key]
        public int STT { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string HOTENKH { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILLs { get; set; }
    }
}
