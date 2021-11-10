namespace ClothingSellManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLINFO")]
    public partial class BILLINFO
    {
        [Key]
        public int IDBILLINFO { get; set; }

        public int SOLUONG { get; set; }

        [StringLength(10)]
        public string MABILL { get; set; }

        [StringLength(10)]
        public string MAQUANAO { get; set; }

        public int? IDSIZE { get; set; }

        public virtual BILL BILL { get; set; }

        public virtual CLOTHINGINFO CLOTHINGINFO { get; set; }

        public virtual CLOTHING CLOTHING { get; set; }
    }
}
