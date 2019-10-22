using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp.Repository
{
    public class ReportOnPurchaseRepository
    {
        public DataTable Search(Purchase purchase)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-CR4IGJV; Database=SMS_RAMPAGE; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT Product.Name,Category.Name,
SUM(Purchase.Quantity) AS Quantity,
sum(Purchase.Quantity*Purchase.Unit_Price) AS CP,sum(Purchase.Quantity*Purchase.MRP) AS MRP,
(sum(Purchase.Quantity*Purchase.MRP)-sum(Purchase.Quantity*Purchase.Unit_Price)) AS Profit
FROM Product,Category,Purchase 
WHERE Product.Id=Purchase.Product_id AND Category.Id=Purchase.category_id AND Date1 >= '"+purchase.Date1+"' and Date1 <= '"+purchase.Date2+"' GROUP BY Product.Id,Product.Name,Purchase.category_id,Category.Name";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //With DataAdapter
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //With DataAdapter
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //List<Customer> customers = new List<Customer>();

            //while (sqlDataReader.Read())
            //{
            //    Customer customer = new Customer();
            //    //District district = new District();
            //    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
            //    customer.Code = sqlDataReader["Code"].ToString();
            //    customer.Name = sqlDataReader["Name"].ToString();
            //    customer.Address = sqlDataReader["Address"].ToString();
            //    customer.Contact = sqlDataReader["Contact"].ToString();
            //    customer.District_Id =Convert.ToInt32(sqlDataReader["District_Id"]);
            //    // district.Name = sqlDataReader["District_Name"].ToString();

            //    customers.Add(customer);
            //}
            //if (sqlDataReader.NextResult())
            //{
            //    while (sqlDataReader.Read())
            //    {
            //        District district = new District();
            //        district.Name = sqlDataReader["District_Name"].ToString();
            //        //customers.Add(district);       
            //    }
            //}

            //if (dataTable.Rows.Count > 0)
            //{

            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            //return dataTable;
            return dataTable;

        }
    }
}
