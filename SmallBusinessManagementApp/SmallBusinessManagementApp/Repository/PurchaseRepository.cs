using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp.Repository
{
    public class PurchaseRepository
    {
        public string connectionString = @"Server=DESKTOP-V33KTP1; Database=SMS_RAMPAGE; Integrated Security=True";

        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataReader reader;

        public DataTable LoadCatagory()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";
            sqlCommand =new SqlCommand(commandString, sqlConnection);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable LoadProducts()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Product";
            sqlCommand= new SqlCommand(commandString,sqlConnection);

            if (sqlConnection.State== ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable LoadSupplier()
        {
            sqlConnection= new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Supplier";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dataTable =new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        string productCode;
        public string LoadProductCode(Product product)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT Code FROM Product WHERE Name='"+product.Name+"' ";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                productCode = (reader[0]).ToString();
            }
            sqlConnection.Close();

            return productCode;
        }
    }
}
