using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext()
            : base("name=OnlineStoreDbContext")
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GopY_KH> GopY_KH { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDTNguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasOptional(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonHang);

            modelBuilder.Entity<LoaiSach>()
                .Property(e => e.MaLoaiSach)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaTacGia)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoaiSach)
                .IsFixedLength();

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTacGia)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
