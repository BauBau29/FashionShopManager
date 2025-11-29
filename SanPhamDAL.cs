using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FashionShopManager.DTO;

namespace FashionShopManager.DAL
{
    public class SanPhamDAL
    {
        // Lấy tất cả sản phẩm
        public List<SanPham> GetAll()
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT * FROM SanPham WHERE TrangThai = 1";

            DataTable data = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    GiaBan = Convert.ToDecimal(row["GiaBan"]),
                    SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                    Size = row["Size"].ToString(),
                    MauSac = row["MauSac"].ToString()
                };
                list.Add(sp);
            }
            return list;
        }

        // Thêm sản phẩm
        public bool Insert(SanPham sp)
        {
            string query = "INSERT INTO SanPham (TenSP, MoTa, GiaBan, SoLuongTon, Size, MauSac, MaLoai, NgayNhap, TrangThai) " +
                          "VALUES (@TenSP, @MoTa, @GiaBan, @SoLuongTon, @Size, @MauSac, @MaLoai, @NgayNhap, @TrangThai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenSP", sp.TenSP),
                new SqlParameter("@MoTa", sp.MoTa),
                new SqlParameter("@GiaBan", sp.GiaBan),
                new SqlParameter("@SoLuongTon", sp.SoLuongTon),
                new SqlParameter("@Size", sp.Size),
                new SqlParameter("@MauSac", sp.MauSac),
                new SqlParameter("@MaLoai", sp.MaLoai),
                new SqlParameter("@NgayNhap", DateTime.Now),
                new SqlParameter("@TrangThai", true)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật sản phẩm
        public bool Update(SanPham sp)
        {
            string query = "UPDATE SanPham SET TenSP = @TenSP, MoTa = @MoTa, GiaBan = @GiaBan, " +
                          "SoLuongTon = @SoLuongTon, Size = @Size, MauSac = @MauSac WHERE MaSP = @MaSP";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", sp.MaSP),
                new SqlParameter("@TenSP", sp.TenSP),
                new SqlParameter("@MoTa", sp.MoTa),
                new SqlParameter("@GiaBan", sp.GiaBan),
                new SqlParameter("@SoLuongTon", sp.SoLuongTon),
                new SqlParameter("@Size", sp.Size),
                new SqlParameter("@MauSac", sp.MauSac)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa sản phẩm (xóa mềm)
        public bool Delete(int maSP)
        {
            string query = "UPDATE SanPham SET TrangThai = 0 WHERE MaSP = @MaSP";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", maSP)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // Tìm kiếm sản phẩm
        public List<SanPham> Search(string keyword)
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT * FROM SanPham WHERE TrangThai = 1 AND (TenSP LIKE @Keyword OR MoTa LIKE @Keyword)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            DataTable data = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                SanPham sp = new SanPham
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    GiaBan = Convert.ToDecimal(row["GiaBan"]),
                    SoLuongTon = Convert.ToInt32(row["SoLuongTon"])
                };
                list.Add(sp);
            }
            return list;
        }
    }
}