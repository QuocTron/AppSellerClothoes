namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLOTHINGCATEGORY")]
    public partial class CLOTHINGCATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLOTHINGCATEGORY()
        {
            CLOTHINGs = new HashSet<CLOTHING>();
        }

        [Key]
        [StringLength(10)]
        public string MALOAI { get; set; }

        [Required]
        [StringLength(50)]
        public string TENLOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLOTHING> CLOTHINGs { get; set; }
    }
}
