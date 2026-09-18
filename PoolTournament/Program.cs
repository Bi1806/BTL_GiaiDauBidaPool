using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolTournament
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Khởi tạo Supabase ngầm trước khi mở Form để tránh khóa luồng UI (Deadlock)
                Task.Run(async () =>
                {
                    await SupabaseClient.InitializeAsync();
                }).Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể kết nối ban đầu đến Supabase!\n\nLỗi: {ex.Message}",
                    "Cảnh báo kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            Application.Run(new LoginForm());
        }
    }
}