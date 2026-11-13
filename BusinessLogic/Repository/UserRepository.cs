
using Microsoft.Data.SqlClient;
using Model;

namespace BusinessLogic.Repository
{
    internal class UserRepository
    {
        private readonly string CONNECTIONSTRING =
            @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        public UserModel? ValidateUser(string Username, string Password)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(CONNECTIONSTRING))
                {
                    connect.Open();

                    string query = @"SELECT * FROM dbo.Users
                                     WHERE Username = @username
                                     AND Password = @password";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@username", Username);
                        command.Parameters.AddWithValue("@password", Password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserModel
                                {
                                    Id = (int)reader["UserID"],
                                    Username = reader["Username"]?.ToString() ?? string.Empty,
                                    Password = reader["Password"]?.ToString() ?? string.Empty,
                                    Role = reader["Role"]?.ToString() ?? string.Empty
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public UserModel getUserByUserId(string UserIdParam)
        {
            using (SqlConnection myConnection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT * FROM dbo.Users WHERE UserID = @userId";

                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@userId", UserIdParam);

                    myConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserModel
                            {
                                Id = (int)reader["UserID"],
                                Username = reader["Username"]?.ToString() ?? string.Empty,
                                Password = reader["Password"]?.ToString() ?? string.Empty,
                                Role = reader["Role"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }

            throw new Exception("User does not exist");
        }
    }
}
