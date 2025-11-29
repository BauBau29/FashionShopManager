using System;

namespace FashionShopManager.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public decimal Luong { get; set; }
        public DateTime NgayVaoLam { get; set; }

        public NhanVien() { }
    }
}