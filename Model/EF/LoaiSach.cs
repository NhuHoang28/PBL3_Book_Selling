namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSach")]
    public partial class LoaiSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSach()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiSach { get; set; }

        [StringLength(250)]
        public string TenLoaiSach { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
