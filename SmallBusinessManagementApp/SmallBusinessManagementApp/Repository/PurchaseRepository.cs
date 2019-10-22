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
        public string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";

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

        string availableQuantity;
        public string LoadQuantity(Purchase purchase)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"select Purchase.Quantity from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = '"+purchase.ProductName+"'";
            sqlCommand=new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                availableQuantity = (reader["Quantity"]).ToString();
            }

            sqlConnection.Close();

            return availableQuantity;
        }

        string previousPrice;
        public string LoadPreviousPrice(Purchase purchase)
        {
            sqlConnection= new SqlConnection(connectionString);
            commandString = @"select Purchase.Unit_Price from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand=new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                previousPrice = (reader["Unit_Price"]).ToString();
            }

            sqlConnection.Close();

            return previousPrice;
        }

        private string previousMrp;

        public string LoadPreviousMrp(Purchase purchase)
        {
            sqlConnection =new SqlConnection(connectionString);
            commandString = @"select Purchase.MRP from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = '" + purchase.ProductName + "'";
            sqlCommand =new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                previousMrp = (reader["MRP"]).ToString();
            }

            return previousMrp;
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

        public DataTable ProductLoad(int Category_Id)
        {
            commandString = @"SELECT Product.Id,Product.Name FROM (Product LEFT JOIN Category ON Product.Category_Id = Category.Id)  WHERE Category.Id = "+Category_Id+" ";
            sqlCommand = new SqlCommand(commandString,sqlConnection);

            if (sqlConnection.State== ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable= new DataTable();
            sqlConnection.Close();
            dataAdapter.Fill(dataTable);
            
            return dataTable;

        }

        public int PurchaseAdd(Purchase purchase)
        {
            sqlConnection=new SqlConnection(connectionString);
            commandString =
                @"INSERT Purchase ( Date1, InvoiceNo, Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,Unit_Price,MRP,Remarks) VALUES ( '" +
                purchase.Date1 + "' , '" + purchase.InvoiceNo + "' , " + purchase.Supplier_id + " , " +
                purchase.category_id + " , " + purchase.Product_id + " , '" + purchase.Manufacture_Date + "'  , '" +
                purchase.Expire_Date + "'  ," + purchase.Quantity + ", " + purchase.Unit_Price + " , " + purchase.MRP +
                " ,'" + purchase.Remarks + "' )";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            int isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;
        }
    }
}
