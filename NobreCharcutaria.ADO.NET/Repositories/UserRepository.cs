using NobreCharcutaria.ADO.NET.Models;
using System.Data.SqlClient;
using System.Data;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class UserRepository
    {
        public List<User> Select(int? id, string? name)
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

                commandQuery = "SELECT Id, Name, Email, Password from Users WHERE 1=1";

                if (id != 0)
                {
                    commandQuery = commandQuery + " and Id = " + id;
                }

                if (name != null)
                {
                    commandQuery = commandQuery + " and Name LIKE '%" + name + "%'";
                }

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

        public User Insert(User user)
        {
            object userID = null;
            string commandQuery = string.Empty;
            SqlConnection _sqlConnection = null;
            SqlCommand _sqlCommand = null;
            string connectionString =
                "Server=DESKTOP-M2IBM2J\\SQLEXPRESS;" +
                "Database=Nobre.Charcutaria.ADO.NET.DB;" +
                "Trusted_Connection=True;";

            try
            {
                _sqlCommand = new SqlCommand();

                commandQuery = "Insert into Users (Name, Email, Password) " +
                                "Values(@Name, @Email, @Password) SELECT SCOPE_IDENTITY()";

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                _sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                _sqlCommand.Parameters.AddWithValue("@Password", user.Password);


                userID = _sqlCommand.ExecuteScalar();

                user.Id = Convert.ToInt32(userID);

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return user;
        }

        public User Update(User user)
        {
            SqlCommand _sqlCommand = null;
            string commandQuery = string.Empty;
            SqlConnection _sqlConnection = null;
            string connectionString =
                "Server=DESKTOP-M2IBM2J\\SQLEXPRESS;" +
                "Database=Nobre.Charcutaria.ADO.NET.DB;" +
                "Trusted_Connection=True;";

            try
            {
                _sqlCommand = new SqlCommand();

                commandQuery = "Update Users set Name = @Name, Email = @Email, Password = @Password where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                _sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                _sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                _sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                var retiunoUpdate = _sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return user;
        }

        public bool Delete(int? id)
        {
            string commandQuery = string.Empty;
            SqlCommand _sqlCommand = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            int rowsCommand;
            bool isDeleted = true;
            string connectionString =
                "Server=DESKTOP-M2IBM2J\\SQLEXPRESS;" +
                "Database=Nobre.Charcutaria.ADO.NET.DB;" +
                "Trusted_Connection=True;";

            try
            {
                _sqlCommand = new SqlCommand();

                commandQuery = "Delete from Users where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                sqlCommand = new SqlCommand(commandQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", id);

                rowsCommand = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                sqlConnection.Dispose();

                if (rowsCommand == 0)
                {
                    throw new Exception("Erro - nenhum registro foi deletado para o id informado: " + id);
                }
                else
                {
                    isDeleted = true;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
