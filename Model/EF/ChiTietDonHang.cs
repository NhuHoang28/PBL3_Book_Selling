namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaDonHang { get; set; }

        public long? MaSach { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? ThanhTien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
