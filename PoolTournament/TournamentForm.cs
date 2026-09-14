using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoolTournament
{
    public partial class TournamentForm : Form
    {
        public TournamentForm()
        {
            InitializeComponent();
        }

        private void cboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            string tournamentName = txtTournamentName.Text;
            string location = txtLocation.Text;
            string format = cboFormat.Text;
            DateTime date = dtpDate.Value;

            if (tournamentName == "" || location == "" || format == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            MessageBox.Show(
                "Tạo giải đấu thành công!\n\n" +
                "Tên giải: " + tournamentName + "\n" +
                "Địa điểm: " + location + "\n" +
                "Thể thức: " + format + "\n" +
                "Ngày: " + date.ToString("dd/MM/yyyy"),
                "Thông báo"

            );
            dgvTournaments.Rows.Add(
    tournamentName,
    location,
    format,
    date.ToString("dd/MM/yyyy")
);
        }
    }
}
