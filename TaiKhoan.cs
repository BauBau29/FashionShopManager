namespace FashionShopManager.DTO
{
    public class TaiKhoan
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Quyen { get; set; } // Admin, NhanVien
        public int MaNV { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(string username, string password, string quyen)
        {
            Username = username;
            Password = password;
            Quyen = quyen;
        }
    }
}