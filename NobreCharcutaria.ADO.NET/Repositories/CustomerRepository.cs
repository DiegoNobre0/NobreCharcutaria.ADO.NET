using NobreCharcutaria.ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class CustomerRepository
    {
        public List<Customer> Select(int? id, string? cliente)
        {
            List<Customer> customers;
            Customer customer;
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

                commandQuery = "SELECT Id, Client, Address, Neighborhood, City, CEP, identificationNumber, Telephone, Email, CustomerTypeId from Customers WHERE 1=1";

                if (id != 0)
                {
                    commandQuery = commandQuery + " and Id = " + id;
                }

                if (cliente != null)
                {
                    commandQuery = commandQuery + " and Cliente LIKE '%" + cliente + "%'";
                }

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);

                _sqlConnection.Open();

                _SqlDataReader = _sqlCommand.ExecuteReader();

                customers = new List<Customer>();

                while (_SqlDataReader.Read())
                {
                    customer = new Customer();
                    customer.Id = Convert.ToInt32(_SqlDataReader["Id"]);
                    customer.Client = _SqlDataReader["Client"].ToString();
                    customer.Address = _SqlDataReader["Address"].ToString();
                    customer.Neighborhood = _SqlDataReader["Neighborhood"].ToString();
                    customer.CEP = _SqlDataReader["CEP"].ToString();
                    customer.City = _SqlDataReader["City"].ToString();
                    customer.identificationNumber = _SqlDataReader["identificationNumber"].ToString();
                    customer.Telephone = _SqlDataReader["Telephone"].ToString();
                    customer.Email = _SqlDataReader["Email"].ToString();
                    customer.CustomerTypeId = Convert.ToInt32(_SqlDataReader["CustomerTypeId"]);
                    customers.Add(customer);
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customers;
        }

        public Customer Insert(Customer customer)
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

                commandQuery = "Insert into Customers (Client, Address, Neighborhood, City, CEP, identificationNumber, Telephone, Email, CustomerTypeId ) " +
                                "Values(@Client, @Address, @Neighborhood, @City, @CEP, @identificationNumber, @Telephone, @Email, @CustomerTypeId) SELECT SCOPE_IDENTITY()";

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.Parameters.AddWithValue("@Client", customer.Client);
                _sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                _sqlCommand.Parameters.AddWithValue("@Neighborhood", customer.Neighborhood);
                _sqlCommand.Parameters.AddWithValue("@City", customer.City);
                _sqlCommand.Parameters.AddWithValue("@CEP", customer.CEP);
                _sqlCommand.Parameters.AddWithValue("@identificationNumber", customer.identificationNumber);
                _sqlCommand.Parameters.AddWithValue("@Telephone", customer.Telephone);
                _sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                _sqlCommand.Parameters.AddWithValue("@CustomerTypeId", customer.CustomerTypeId);


                userID = _sqlCommand.ExecuteScalar();

                customer.Id = Convert.ToInt32(userID);

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customer;
        }

        public Customer Update(Customer customer)
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

                commandQuery = "Update Customers set Client = @Client, Address = @Address, Neighborhood = @Neighborhood, City = @City, CEP = @CEP, identificationNumber = @identificationNumber, Telephone = @Telephone, Email = @Email, CustomerTypeId = @CustomerTypeId where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.Parameters.AddWithValue("@Id", customer.Id);
                _sqlCommand.Parameters.AddWithValue("@Client", customer.Client);
                _sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                _sqlCommand.Parameters.AddWithValue("@Neighborhood", customer.Neighborhood);
                _sqlCommand.Parameters.AddWithValue("@City", customer.City);
                _sqlCommand.Parameters.AddWithValue("@CEP", customer.CEP);
                _sqlCommand.Parameters.AddWithValue("@identificationNumber", customer.identificationNumber);
                _sqlCommand.Parameters.AddWithValue("@Telephone", customer.Telephone);
                _sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                _sqlCommand.Parameters.AddWithValue("@CustomerTypeId", customer.CustomerTypeId);

                var retiunoUpdate = _sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customer;
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

                commandQuery = "Delete from Customers where Id = @Id";

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
