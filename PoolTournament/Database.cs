using MySql.Data.MySqlClient;

namespace PoolTournament
{
    public static class Database
    {
        private static string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=pooltournament;" +
            "Uid=root;" +
            "Pwd=bideptrai123";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}