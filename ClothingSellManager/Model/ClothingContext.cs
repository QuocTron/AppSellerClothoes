using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClothingSellManager.Model
{
    public partial class ClothingContext : DbContext
    {
        public ClothingContext()
            : base("name=ClothingContext")
        {
        }

        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<BILLINFO> BILLINFOes { get; set; }
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<CLOTHING> CLOTHINGs { get; set; }
        public virtual DbSet<CLOTHINGCATEGORY> CLOTHINGCATEGORies { get; set; }
        public virtual DbSet<CLOTHINGINFO> CLOTHINGINFOes { get; set; }
        public virtual DbSet<POSITION> POSITIONs { get; set; }
        public virtual DbSet<STAFF> STAFFs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BILL>()
                .Property(e => e.MABILL)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.MANHAVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINFO>()
                .Property(e => e.MABILL)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINFO>()
                .Property(e => e.MAQUANAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHING>()
                .Property(e => e.MAQUANAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHING>()
                .Property(e => e.MALOAICLOTHING)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHING>()
                .HasMany(e => e.CLOTHINGINFOes)
                .WithOptional(e => e.CLOTHING)
                .HasForeignKey(e => e.MAQUANAOCLOTHINGINFO);

            modelBuilder.Entity<CLOTHINGCATEGORY>()
                .Property(e => e.MALOAI)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHINGCATEGORY>()
                .HasMany(e => e.CLOTHINGs)
                .WithOptional(e => e.CLOTHINGCATEGORY)
                .HasForeignKey(e => e.MALOAICLOTHING);

            modelBuilder.Entity<CLOTHINGINFO>()
                .Property(e => e.SIZE)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHINGINFO>()
                .Property(e => e.MAQUANAOCLOTHINGINFO)
                .IsUnicode(false);

            modelBuilder.Entity<CLOTHINGINFO>()
                .HasMany(e => e.BILLINFOes)
                .WithOptional(e => e.CLOTHINGINFO)
                .HasForeignKey(e => e.IDSIZE);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.MABOPHAN)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .HasMany(e => e.STAFFs)
                .WithOptional(e => e.POSITION)
                .HasForeignKey(e => e.MABOPHANSTAFF);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.IDNHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.MABOPHANSTAFF)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.BILLs)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.MANHAVIEN);
        }
    }
}
