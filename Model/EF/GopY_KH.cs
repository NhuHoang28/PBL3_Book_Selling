namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GopY_KH
    {
        [Key]
        public long IdGopY { get; set; }

        public long? IdUser { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool? TrangThai { get; set; }

        public virtual User User { get; set; }
    }
}
