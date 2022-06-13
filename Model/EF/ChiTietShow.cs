using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("ChiTietShow")]
    public partial class ChiTietShow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaDonHang { get; set; }
        public long? MaSach { get; set; }
        public string TenSach { get; set; }
        public string HinhAnh { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }
        public int? ThanhTien { get; set; }
    }
}
