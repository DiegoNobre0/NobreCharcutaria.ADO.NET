using NobreCharcutaria.ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class LoginRepository
    {
        public List<User> Select(Login login)
        {
            List<User> users;
            User user;
            string commandQuery = string.Empty;
            SqlConnection _sqlConnection = null;
            SqlDataReader _SqlDataReader = null;
            SqlCommand _sqlCommand = null;
            string connectionString =
              "Server=DESKTOP-M2IBM2J\\SQLEXPRESS;" +
              "Database=Nobre.Charcutaria.ADO.NET.DB;" +
              "Trusted_Connection=True;";

            try
            {
                _sqlCommand = new SqlCommand();

                commandQuery = "SELECT Id, Name, Email, Password from Users WHERE Email = '" + login.Email + "' and Password = '" + login.Password + "'";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);

                _sqlConnection.Open();

                _SqlDataReader = _sqlCommand.ExecuteReader();

                users = new List<User>();

                while (_SqlDataReader.Read())
                {
                    user = new User();
                    user.Id = Convert.ToInt32(_SqlDataReader["Id"]);
                    user.Name = _SqlDataReader["Name"].ToString();
                    user.Email = _SqlDataReader["Email"].ToString();
                    user.Password = _SqlDataReader["Password"].ToString();
                    users.Add(user);
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return users;
        }
    }
}
