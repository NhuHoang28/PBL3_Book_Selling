using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineStoreDbContext db = null;
        public OrderDao()
        {
            db = new OnlineStoreDbContext();
        }
        public long Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.MaDonHang;
        }
        public DonHang ViewDetail(long id)
        {
            return db.DonHangs.Find(id);
        }
        public void Update(DonHang order) // update 
        {
            //db.DonHangs.SqlQuery("Update DonHang set Tongtien={0} where madonhang={1} ", order.TongTien,order.MaDonHang);
            db.DonHangs.SingleOrDefault(x => x.MaDonHang == order.MaDonHang).TongTien = order.TongTien;
            db.SaveChanges();
        }
        public bool Update1(DonHang order)
        {
            try
            {
                var ord = db.DonHangs.Find(order.MaDonHang);
                ord.IdUser = order.IdUser;
                ord.TenNguoiNhan = order.TenNguoiNhan;
                ord.SDTNguoiNhan = order.SDTNguoiNhan;
                ord.Email = order.Email;
                ord.DiaChiNhan = order.DiaChiNhan;
                ord.GhiChu = order.GhiChu;
                ord.NgayTao = order.NgayTao;
                ord.TongTien = order.TongTien;
                ord.TrangThai = order.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<DonHang> ListAllPaging(int page, int pageSize)
        {
            return db.DonHangs.OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
        }
        public IEnumerable<DonHang> ListOrderOfUser(long id,int page, int pageSize)
        {
            return db.DonHangs.Where(x=>x.IdUser==id).OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
        }
        public bool Delete(long id)
        {
            var list = from a in db.SanPhams
                       join b in db.ChiTietDonHangs
                       on a.MaSach equals b.MaSach
                       where b.MaDonHang == id
                       select new ChiTietShow()
                       {
                           MaSach = a.MaSach,
                           SoLuong = b.SoLuong,
                       };
            //list = list.ToList();
            try
            {
                var order = db.DonHangs.Find(id);
                foreach (var item in list)
                {
                    db.SanPhams.SingleOrDefault(x => x.MaSach == item.MaSach).SoLuong += item.SoLuong;
                }
                foreach (var item in db.ChiTietDonHangs)
                {
                    if (item.MaDonHang == id)
                    {
                        db.ChiTietDonHangs.Remove(item);
                    }
                }
                
                db.DonHangs.Remove(order);
                db.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int? Sum(DateTime a, DateTime b)
        {
            int? sum = 0;
            var list=db.DonHangs.Where(x => x.NgayTao > a && x.NgayTao < b &&x.TrangThai!="Chưa xác nhận").ToList();
            foreach(var item in list)
            {
                sum += item.TongTien;
            }
            return sum;
        }
        public int? Quantity(DateTime a, DateTime b)
        {
            int? quantity = 0;
            var list = db.DonHangs.Where(x => x.NgayTao > a && x.NgayTao < b && x.TrangThai != "Chưa xác nhận").ToList();
            foreach (var item in list)
            {
                quantity += 1;
            }
            return quantity;
        }
    }
}
