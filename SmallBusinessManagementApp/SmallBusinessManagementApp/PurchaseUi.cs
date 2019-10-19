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
        private Purchase purchase;
        public PurchaseUi()
        {
            InitializeComponent();
            product = new Product();
            purchase=new Purchase();
            
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                //availableQuantity = 0;
                int quantity = Convert.ToInt32(quantityTextBox.Text);
                //int totalPrice = Convert.ToInt32(totalPriceTextBox.Text);
                double unitPrice = Convert.ToDouble(unitPriceTextBox.Text);
                //int previousUnitPrice = Convert.ToInt32(previousUnitPriceTextBox.Text);
                //int previousMrpPrice = Convert.ToInt32(previousMRPTextBox.Text);
                purchase.Supplier_id = Convert.ToInt32(supplierComboBox.SelectedValue);
                purchase.category_id = Convert.ToInt32(categoryComboBox.SelectedValue);
                //purchase.Product_id = Convert.ToInt32(productsComboBox.SelectedValue);
                purchase.Product_id=Convert.ToInt32( productsComboBox.SelectedValue);
                purchase.InvoiceNo = invoiceNoTextBox.Text;
                purchase.Date1=DateTime.Now;
                purchase.Manufacture_Date = manufactureDateTimePicker.Value;
                purchase.Expire_Date = ExpireDateTimePicker.Value;
                purchase.MRP = Convert.ToDouble(mrpTextBox.Text);
                purchase.Remarks = remarksTextBox.Text;



                purchase.Quantity = availableQuantity + quantity;
                purchase.TotalPrice = quantity * unitPrice;
                purchase.Date1 = DateTime.Now;
                

                //stock.Quantity = availableQuantity + stockInQuantity;
                //stock.Date = DateTime.Now;
                //stock.Status = "Stock In";

                try
                {
                    

                    int isExecuted = _purchaseManager.PurchaseAdd(purchase);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Save Successful.");

                        //Reset();
                        //DisplayStock();
                    }
                    else
                    {
                        MessageBox.Show("Save Failed!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


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
            supplierComboBox.Text = "-select-";
            //codeTextBox.Text = _purchaseManager.LoadProductCode(product);
            codeTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            totalPriceTextBox.Text = "<View>";
            previousUnitPriceTextBox.Text = "<View>";
            previousMRPTextBox.Text = "<View>";


        }
        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadReorder();
            LoadQuantity();
            LoadPreviousPrice();
            LoadPreviousMrp();


        }
        private void LoadReorder()
        {
            //stock.ItemName = itemComboBox.Text;
            //reorderLevelTextBox.Text = _stockManager.LoadReorder(stock);
            product.Name = productsComboBox.Text;
            codeTextBox.Text = _purchaseManager.LoadProductCode(product);
        }
        private void LoadQuantity()
        {
            purchase.ProductName = productsComboBox.Text;
            availableQuantityTextBox.Text = "0";
            availableQuantityTextBox.Text = _purchaseManager.LoadQuantity(purchase);
        }

        private void LoadPreviousPrice()
        {
            purchase.ProductName = productsComboBox.Text;
            previousUnitPriceTextBox.Text = "0";
            previousUnitPriceTextBox.Text = _purchaseManager.LoadPreviousPrice(purchase);
        }

        private void LoadPreviousMrp()
        {
            purchase.ProductName = productsComboBox.Text;
            previousMRPTextBox.Text = "0";
            previousMRPTextBox.Text = _purchaseManager.LoadPreviousMrp(purchase);


        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsComboBox.DataSource = _purchaseManager.ProductLoad(Convert.ToInt32(categoryComboBox.SelectedValue));
            productsComboBox.Text = "-select-";

        }
        private bool IsFormValid()
        {
            //messageLabel.Text = "";

            if (supplierComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select company";
                return false;
            }

            if (categoryComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select category";
                return false;
            }

            if (productsComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select item";
                return false;
            }

            if (quantityTextBox.Text=="")
            {
                return false;
            }

            if (unitPriceTextBox.Text=="")
            {
                return false;
            }

            if (String.IsNullOrEmpty(mrpTextBox.Text)) 
            {
                return false;
            }

            if (remarksTextBox.Text=="")
            {
                return false;
            }

            

            return true;
        }

        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            //totalPriceTextBox.Data
            double unitPrice = Convert.ToDouble(unitPriceTextBox.Text);
            int quantity = Convert.ToInt32(quantityTextBox.Text);
            totalPriceTextBox.Text = (unitPrice * quantity).ToString();
        }

       


    }
}
