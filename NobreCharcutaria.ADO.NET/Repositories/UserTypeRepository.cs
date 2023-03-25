using NobreCharcutaria.ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class UserTypeRepository
    {
        public List<UserType> Select(int? id, string? type)
        {
            List<UserType> userTypes;
            UserType userType;
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

                commandQuery = "SELECT Id, Type from UserTypes WHERE 1=1";

                if (id != 0)
                {
                    commandQuery = commandQuery + " and Id = " + id;
                }

                if (type != null)
                {
                    commandQuery = commandQuery + " and Name LIKE '%" + type + "%'";
                }

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);

                _sqlConnection.Open();

                _SqlDataReader = _sqlCommand.ExecuteReader();

                userTypes = new List<UserType>();

                while (_SqlDataReader.Read())
                {
                    userType = new UserType();
                    userType.Id = Convert.ToInt32(_SqlDataReader["Id"]);
                    userType.Type = _SqlDataReader["Type"].ToString();
                    userTypes.Add(userType);
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return userTypes;
        }

        public UserType Insert(UserType userType)
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

                commandQuery = "Insert into UserTypes (Type) " +
                                "Values(@Type) SELECT SCOPE_IDENTITY()";

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.Parameters.AddWithValue("@Type", userType.Type);

                userID = _sqlCommand.ExecuteScalar();

                userType.Id = Convert.ToInt32(userID);

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return userType;
        }

        public UserType Update(UserType userType)
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

                commandQuery = "Update UserTypes set Type = @Type where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.Parameters.AddWithValue("@Id", userType.Id);
                _sqlCommand.Parameters.AddWithValue("@Type", userType.Type);

                var retiunoUpdate = _sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return userType;
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

                commandQuery = "Delete from UserTypes where Id = @Id";

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
