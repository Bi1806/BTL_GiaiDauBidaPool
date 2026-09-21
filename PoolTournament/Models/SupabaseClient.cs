using System.Threading.Tasks;
using Supabase;

namespace PoolTournament.Models
{
    public static class SupabaseClient
    {
        private static Client _instance;

        // Điền URL và Anon Key chính xác của bạn
        private static readonly string SupabaseUrl = "https://abpwlufkjwtjwnprjqyz.supabase.co";
        private static readonly string SupabaseKey = "sb_publishable__Tw61xGfIiQt8e9efZ9tAQ_q64ba_58";

        public static Client Instance => _instance;

        // Hàm khởi tạo không gây Deadlock
        public static async Task InitializeAsync()
        {
            if (_instance == null)
            {
                var options = new SupabaseOptions
                {
                    AutoConnectRealtime = true
                };

                _instance = new Client(SupabaseUrl, SupabaseKey, options);
                await _instance.InitializeAsync();
            }
        }
    }
}