using NobreCharcutaria.ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class CustomerTypeRepository
    {
        public List<CustomerType> Select(int? id, string? type)
        {
            List<CustomerType> customerTypes;
            CustomerType customerType;
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

                commandQuery = "SELECT Id, IdentificationType from CustomerTypes WHERE 1=1";

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

                customerTypes = new List<CustomerType>();

                while (_SqlDataReader.Read())
                {
                    customerType = new CustomerType();
                    customerType.Id = Convert.ToInt32(_SqlDataReader["Id"]);
                    customerType.IdentificationType = _SqlDataReader["IdentificationType"].ToString();
                    customerTypes.Add(customerType);
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customerTypes;
        }

        public CustomerType Insert(CustomerType customerType)
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

                commandQuery = "Insert into CustomerTypes (IdentificationType) " +
                                "Values(@IdentificationType) SELECT SCOPE_IDENTITY()";

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.Parameters.AddWithValue("@IdentificationType", customerType.IdentificationType);

                userID = _sqlCommand.ExecuteScalar();

                customerType.Id = Convert.ToInt32(userID);

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customerType;
        }

        public CustomerType Update(CustomerType customerType)
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

                commandQuery = "Update CustomerTypes set IdentificationType = @IdentificationType where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.Parameters.AddWithValue("@Id", customerType.Id);
                _sqlCommand.Parameters.AddWithValue("@IdentificationType", customerType.IdentificationType);

                var retiunoUpdate = _sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customerType;
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

                commandQuery = "Delete from CustomerTypes where Id = @Id";

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
