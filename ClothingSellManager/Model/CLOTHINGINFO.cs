namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLOTHINGINFO")]
    public partial class CLOTHINGINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLOTHINGINFO()
        {
            BILLINFOes = new HashSet<BILLINFO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        public string SIZE { get; set; }

        public double PRICE { get; set; }

        [StringLength(10)]
        public string MAQUANAOCLOTHINGINFO { get; set; }

        public int SOLUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINFO> BILLINFOes { get; set; }

        public virtual CLOTHING CLOTHING { get; set; }
    }
}
