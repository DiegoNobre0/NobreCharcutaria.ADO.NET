using NobreCharcutaria.ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace NobreCharcutaria.ADO.NET.Repositories
{
    public class ProductRepository
    {
        public List<Product> Select(int? id, string? name)
        {
            List<Product> products;
            Product product;
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

                commandQuery = "SELECT Id, Name, Weight, Description from Products WHERE 1=1";

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

                products = new List<Product>();

                while (_SqlDataReader.Read())
                {
                    product = new Product();
                    product.Id = Convert.ToInt32(_SqlDataReader["Id"]);
                    product.Name = _SqlDataReader["Name"].ToString();
                    product.Weight = Convert.ToDecimal(_SqlDataReader["Weight"]);
                    product.Description = _SqlDataReader["Description"].ToString();
                    products.Add(product);
                }

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return products;
        }

        public Product Insert(Product product)
        {
            object productID = null;
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

                commandQuery = "Insert into Products (Name, Weight, Description) " +
                                "Values(@Name, @Weight, @Description) SELECT SCOPE_IDENTITY()";

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                _sqlCommand.Parameters.AddWithValue("@Weight", product.Weight);
                _sqlCommand.Parameters.AddWithValue("@Description", product.Description);


                productID = _sqlCommand.ExecuteScalar();

                product.Id = Convert.ToInt32(productID);

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return product;
        }

        public Product Update(Product product)
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

                commandQuery = "Update Products set Name = @Name, Weight = @Weight, Description = @Description where Id = @Id";

                _sqlCommand.CommandText = commandQuery;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand(commandQuery, _sqlConnection);
                _sqlCommand.Parameters.AddWithValue("@Id", product.Id);
                _sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                _sqlCommand.Parameters.AddWithValue("@Weight", product.Weight);
                _sqlCommand.Parameters.AddWithValue("@Description", product.Description);

                var retiunoUpdate = _sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return product;
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

                commandQuery = "Delete from Products where Id = @Id";

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
