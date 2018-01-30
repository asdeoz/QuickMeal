using Microsoft.Data.Sqlite;

namespace QuickMeal.Library.DataAccess
{
    public class DataAccessBase
    {
        private const string CreateTableCommand = "CREATE TABLE IF NOT EXISTS Meals (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name NVARCHAR(2048) NULL, IsBreakfast BIT NULL, IsLunch BIT NULL, IsDinner BIT NULL, IsSnack BIT NULL);";

        protected static SqliteConnection GetConnection()
        {
            return new SqliteConnection("Filename=quickmeal.db");
        }

        protected static SqliteCommand GetCommand(string query, SqliteConnection connection)
        {
            return new SqliteCommand(query, connection);
        }

        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand(CreateTableCommand, connection);
                command.ExecuteReader();
            }
        }
    }
}