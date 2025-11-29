using System;

namespace FashionShopManager.DTO
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
        public decimal DiemTichLuy { get; set; }

        public KhachHang() { }

        public KhachHang(int maKH, string tenKH, string soDT)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SoDT = soDT;
        }
    }
}