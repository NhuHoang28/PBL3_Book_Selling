namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public long MaSach { get; set; }

        [StringLength(10)]
        public string MaTacGia { get; set; }

        [StringLength(10)]
        public string MaLoaiSach { get; set; }

        public string TenSach { get; set; }

        public string NoiDung { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool TrangThai { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
