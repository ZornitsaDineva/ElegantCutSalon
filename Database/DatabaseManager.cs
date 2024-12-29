using Microsoft.Data.SqlClient;

namespace ElegantCutSalon.Database
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connection_string) {
            _connectionString = connection_string;
        }

        public void InsertStaff(string name, string title, 
            string description, string role, string email, 
            string password, bool isAdmin)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Staff (Name, Title, Description, Role, Email, Password, IsAdmin) VALUES (@Name, @Title, @Description, @Role, @Email, @Password, @IsAdmin);";
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
