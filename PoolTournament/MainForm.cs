using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoolTournament
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        // Constructor mặc định (dùng cho WinForms Designer)
        public MainForm()
        {
            InitializeComponent();
        }

        // Constructor nhận dữ liệu User đăng nhập từ LoginForm
        public MainForm(User currentUser) : this()
        {
            _currentUser = currentUser;

            if (_currentUser != null)
            {
                this.Text = $"QUẢN LÝ GIẢI ĐẤU BIDA - Xin chào: {_currentUser.FullName} ({_currentUser.Role?.ToUpper()})";
            }
        }

        private void btnTournament_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang Quản lý giải đấu!");
            TournamentForm tournamentForm = new TournamentForm();
            tournamentForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
