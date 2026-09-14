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
        public MainForm()
        {
            InitializeComponent();
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
