using System;
using System.Windows.Forms;

namespace FashionShopManager.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng đăng nhập
            // Load menu theo quyền
        }

        // Menu items - sẽ thêm sau
        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            // Mở form quản lý sản phẩm
        }

        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            // Mở form bán hàng
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {
            // Mở form báo cáo
        }
    }
}