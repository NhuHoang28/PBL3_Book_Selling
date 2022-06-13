using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineStoreDbContext db = null;
        public ProductDao()
        {
            db = new OnlineStoreDbContext();
        }
        public List<SanPham> ListNewProduct(int top)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayTao).Take(top).ToList();
        }
        public List<SanPham> ListFeatureProduct(int top)
        {
            return db.SanPhams.Where(x => x.TrangThai== true).OrderByDescending(x => x.NgayTao).Take(top).ToList();
        }
        public List<SanPham> ListRelatedProduct(long productID) // liet ke cac sach khac cung loai
        {
            var product = db.SanPhams.Find(productID);
            return db.SanPhams.Where(x => x.MaSach != productID && x.MaLoaiSach == product.MaLoaiSach.Trim()).ToList();  
        }
        public List<SanPham> ListAllProduct(ref int totalRecord,int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.SanPhams.Count();
            var model= db.SanPhams.OrderBy(x => x.NgayTao).Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            //var model = db.SanPhams.OrderBy(x=> x.NgayTao).ToList();
            return model;
        }
        public List<SanPham> ListCategoryProduct(string id)
        {
            return db.SanPhams.Where(x => x.MaLoaiSach == id).ToList();
        }
        public List<SanPham> ListAuthorProduct(string id)
        {
            return db.SanPhams.Where(x => x.MaTacGia == id).ToList();
        }
        public SanPham ViewDetail(long id)
        {
            return db.SanPhams.Find(id);
        }
        public long Insert(SanPham sp) 
        {
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return sp.MaSach;
            }
        }
        public bool Update(SanPham sp)
        {
            try
            {
                var product = db.SanPhams.Find(sp.MaSach);
                product.MaTacGia = sp.MaTacGia;
                product.MaLoaiSach = sp.MaLoaiSach;
                product.TenSach = sp.TenSach;
                product.NoiDung = sp.NoiDung;
                product.HinhAnh = sp.HinhAnh;
                product.DonGia = sp.DonGia;
                product.SoLuong = sp.SoLuong;
                product.TrangThai = sp.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void UpdateSoLuong(int soluong,long id)
        {
            db.SanPhams.SingleOrDefault(x => x.MaSach == id).SoLuong -= soluong;
            db.SaveChanges();
        }
        public IEnumerable<SanPham> ListAllPaging(int page, int pageSize)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
        }
        public List<SanPham> Search(string keyword)
        {
            if (keyword != null)
            {
                return db.SanPhams.Where(x => x.TenSach.Contains(keyword)).ToList();
            }
            else
            {
                return db.SanPhams.ToList();
            }
            
        }
        public bool Delete(long id)
        {
            try
            {
                var pro = db.SanPhams.Find(id);
                db.SanPhams.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
