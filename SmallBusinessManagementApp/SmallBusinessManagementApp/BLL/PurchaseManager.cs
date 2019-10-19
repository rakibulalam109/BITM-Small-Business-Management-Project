using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.Repository;

namespace SmallBusinessManagementApp.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public DataTable LoadCatagory()
        {
            return _purchaseRepository.LoadCatagory();
        }

        public DataTable LoadProducts()
        {
            return _purchaseRepository.LoadProducts();
        }

        public DataTable LoadSupplier()
        {
            return _purchaseRepository.LoadSupplier();
        }

        public string LoadProductCode(Product product)
        {
            return _purchaseRepository.LoadProductCode(product);
        }

        public DataTable ProductLoad(int Category_Id)
        {
            return _purchaseRepository.ProductLoad(Category_Id);
        }

        public string LoadQuantity(Purchase purchase)
        {
            return _purchaseRepository.LoadQuantity(purchase);
        }

        public int PurchaseAdd(Purchase purchase)
        {
            return _purchaseRepository.PurchaseAdd(purchase);
        }

        public string LoadPreviousPrice(Purchase purchase)
        {
            return _purchaseRepository.LoadPreviousPrice(purchase);
        }

        public string LoadPreviousMrp(Purchase purchase)
        {
            return _purchaseRepository.LoadPreviousMrp(purchase);
        }

    }
}
