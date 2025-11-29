using System;
using System.Collections.Generic;
using FashionShopManager.DAL;
using FashionShopManager.DTO;

namespace FashionShopManager.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();

        // Lấy tất cả sản phẩm
        public List<SanPham> GetAll()
        {
            return sanPhamDAL.GetAll();
        }

        // Thêm sản phẩm với validation
        public bool Insert(SanPham sp)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(sp.TenSP))
                throw new Exception("Tên sản phẩm không được để trống!");

            if (sp.GiaBan <= 0)
                throw new Exception("Giá bán phải lớn hơn 0!");

            if (sp.SoLuongTon < 0)
                throw new Exception("Số lượng tồn không được âm!");

            return sanPhamDAL.Insert(sp);
        }

        // Cập nhật sản phẩm
        public bool Update(SanPham sp)
        {
            if (string.IsNullOrWhiteSpace(sp.TenSP))
                throw new Exception("Tên sản phẩm không được để trống!");

            if (sp.GiaBan <= 0)
                throw new Exception("Giá bán phải lớn hơn 0!");

            return sanPhamDAL.Update(sp);
        }

        // Xóa sản phẩm
        public bool Delete(int maSP)
        {
            if (maSP <= 0)
                throw new Exception("Mã sản phẩm không hợp lệ!");

            return sanPhamDAL.Delete(maSP);
        }

        // Tìm kiếm sản phẩm
        public List<SanPham> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return sanPhamDAL.Search(keyword);
        }

        // Kiểm tra tồn kho
        public bool CheckStock(int maSP, int soLuong)
        {
            List<SanPham> list = sanPhamDAL.GetAll();
            SanPham sp = list.Find(s => s.MaSP == maSP);

            if (sp == null)
                return false;

            return sp.SoLuongTon >= soLuong;
        }
    }
}