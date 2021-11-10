namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLOTHING")]
    public partial class CLOTHING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLOTHING()
        {
            BILLINFOes = new HashSet<BILLINFO>();
            CLOTHINGINFOes = new HashSet<CLOTHINGINFO>();
        }

        [Key]
        [StringLength(10)]
        public string MAQUANAO { get; set; }

        [Required]
        [StringLength(30)]
        public string TENQUANAO { get; set; }

        [StringLength(10)]
        public string MALOAICLOTHING { get; set; }

        [Column(TypeName = "image")]
        public byte[] Hinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINFO> BILLINFOes { get; set; }

        public virtual CLOTHINGCATEGORY CLOTHINGCATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLOTHINGINFO> CLOTHINGINFOes { get; set; }
    }
}
