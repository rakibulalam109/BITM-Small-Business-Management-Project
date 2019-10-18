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
using  SmallBusinessManagementApp.BLL;

namespace SmallBusinessManagementApp
{
    public partial class PurchaseUi : Form
    {
        PurchaseManager _purchaseManager =new PurchaseManager();
        private Product product;
        public PurchaseUi()
        {
            InitializeComponent();
            product = new Product();
        }

        private void PurchaseUi_Load(object sender, EventArgs e)
        {
            //companyComboBox.DataSource = _stockManager.LoadCompany();
            //companyComboBox.Text = "-Select-";

            //categoryComboBox.DataSource = _stockManager.LoadCategory();
            //categoryComboBox.Text = "-Select-";
            categoryComboBox.DataSource = _purchaseManager.LoadCatagory();
            categoryComboBox.Text = "-select-";
            productsComboBox.DataSource = _purchaseManager.LoadProducts();
            productsComboBox.Text = "-select-";
            supplierComboBox.DataSource = _purchaseManager.LoadSupplier();
            //supplierComboBox.Text = "-select-";
            //codeTextBox.Text = "<View>";
            //codeTextBox.Text = _purchaseManager.LoadProductCode(product);
            codeTextBox.Text = "";

        }
        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadReorder();
            
        }
        private void LoadReorder()
        {
            //stock.ItemName = itemComboBox.Text;
            //reorderLevelTextBox.Text = _stockManager.LoadReorder(stock);
            product.Name = productsComboBox.Text;
            codeTextBox.Text = _purchaseManager.LoadProductCode(product);
        }

       
    }
}
