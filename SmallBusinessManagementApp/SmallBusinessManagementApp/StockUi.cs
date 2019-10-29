using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.BLL;


namespace SmallBusinessManagementApp
{
    public partial class StockUi : Form
    {
        StockReportManager _stockReportManager = new StockReportManager();
        public StockUi()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (reorderCheckBox.Checked == false)
                {
                    Purchase purchase = new Purchase();
                    purchase.Date1 = startDateTimePicker.Value;
                    purchase.Date2 = endDateTimePicker.Value;
                    Product product = new Product();
                    if (String.IsNullOrEmpty(categoryTextBox.Text) && String.IsNullOrEmpty(productTextBox.Text))
                    {
                        MessageBox.Show("Please Enter at least one field to search");
                        return;
                    }

                    product.Name = productTextBox.Text;
                    Category category = new Category();
                    category.Name = categoryTextBox.Text;

                    showDataGridView.DataSource = _stockReportManager.Search(purchase, product, category);
                }
                else
                {
                    showDataGridView.DataSource = _stockReportManager.SearchByReorderLevel();
                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
