namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        public long MaDonHang { get; set; }

        public long? IdUser { get; set; }

        [StringLength(50)]
        public string TenNguoiNhan { get; set; }

        [StringLength(11)]
        public string SDTNguoiNhan { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string DiaChiNhan { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual ChiTietDonHang ChiTietDonHang { get; set; }

        public virtual User User { get; set; }
    }
}
