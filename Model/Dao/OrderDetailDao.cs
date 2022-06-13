using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        OnlineStoreDbContext db = null;
        public OrderDetailDao()
        {
            db = new OnlineStoreDbContext();
        }
        public bool Insert(ChiTietDonHang detail)
        {
            try
            {
                db.ChiTietDonHangs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<ChiTietShow> ViewDetail(long id)
        {
            //var list = db.ChiTietDonHangs.SqlQuery("SELECT * from ChiTietDonHang where MaDonHang = {0}", id).ToList();
            //return list;
            //List<ChiTietDonHang> list=new List<ChiTietDonHang>();
            //for (int i = 0; i <= db.ChiTietDonHangs.Count() - 1; ++i)
            //{
            //    if (db.ChiTietDonHangs..MaDonHang == id)
            //        list.Add(db.ChiTietDonHangs.ElementAt(i));
            //}
            //long? ma = 0;
            //foreach (var item in db.ChiTietDonHangs)
            //{
            //    if(item.MaDonHang==id)
            //    list.Add(item);
            //}
            //return list;
            var list = from a in db.SanPhams
                       join b in db.ChiTietDonHangs
                       on a.MaSach equals b.MaSach
                       where b.MaDonHang == id
                       select new ChiTietShow()
                       {
                           MaDonHang = b.MaDonHang,
                           MaSach = a.MaSach,
                           TenSach = a.TenSach,
                           HinhAnh = a.HinhAnh,
                           SoLuong = b.SoLuong,
                           DonGia = b.DonGia,
                           ThanhTien = b.ThanhTien,
                       };
            return list.ToList();
        }
    }
}
