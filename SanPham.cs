using System;

namespace FashionShopManager.DTO
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string Size { get; set; }
        public string MauSac { get; set; }
        public int MaLoai { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool TrangThai { get; set; }

        public SanPham() { }

        public SanPham(int maSP, string tenSP, decimal giaBan, int soLuongTon)
        {
            MaSP = maSP;
            TenSP = tenSP;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }
    }
}