using Model.Dao;
using Model.EF;
using OnlineStore.Areas.Admin.Controllers;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineStore.Controllers
{
    public class CartController : BaseController
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart!= null)
            {
                list = (List < CartItem >) cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long productId,int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.Product.MaSach== productId))
                {
                    foreach(var item in list)
                    {
                        if(item.Product.MaSach== productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // tao moi doi tuong cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                // Gan vao session
                Session[CartSession] = list;
            }
            else
            {
                // tao moi doi tuong cart item
                var item= new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.MaSach == item.Product.MaSach);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.MaSach == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status=true
            });
        }
        
        public ActionResult UpdateItem(long productId, int quantity)
        {
            var cart = Session[CartSession];
            var list = (List<CartItem>)cart;
            if (quantity == 0)
            {
                DeleteItem(productId);
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.Product.MaSach == productId)
                    {
                        item.Quantity = quantity;
                    }
                }
            }
            Session[CartSession] = list;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteItem(long productId)
        {
            var cart = Session[CartSession];
            var list = (List<CartItem>)cart;
            if (cart != null)
            {
                foreach (var item in list)
                {
                    if (item.Product.MaSach == productId)
                    {
                        list.Remove(item);
                        break;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string note)
        {
            //var id = new OrderDao().Insert(order);
            try
            {

                UserDao user = new UserDao();
                long iduser = user.getIdUser();
                User user1 = user.ViewDetail(iduser);
                DonHang order = new DonHang();
                order.IdUser = iduser;
                order.NgayTao = DateTime.Now;
                order.DiaChiNhan = user1.DiaChi;
                order.SDTNguoiNhan = user1.DienThoai;
                order.TenNguoiNhan = user1.HoTen;
                order.Email = user1.Email;
                order.GhiChu = note;
                order.TongTien = 0;
                order.TrangThai = "Chưa xác nhận";
                
                OrderDao od = new OrderDao();
                var id = od.Insert(order);

                var cart = (List<CartItem>)Session[CartSession];

                foreach (var item in cart)
                {
                    OrderDetailDao detailDao = new OrderDetailDao();
                    var orderDetail = new ChiTietDonHang();
                    orderDetail.MaSach = item.Product.MaSach;
                    orderDetail.DonGia = item.Product.DonGia;
                    orderDetail.SoLuong = item.Quantity;
                    orderDetail.ThanhTien = orderDetail.SoLuong * orderDetail.DonGia;
                    new ProductDao().UpdateSoLuong(item.Quantity, item.Product.MaSach);
                    order.TongTien += orderDetail.ThanhTien;
                    od.Update(order);
                    orderDetail.MaDonHang = id;
                    detailDao.Insert(orderDetail);
                }
                DeleteAll();
            }
            catch(Exception e)
            {
                return Redirect("/Cart/Fail");
            }
            return Redirect("/Cart/Success");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}