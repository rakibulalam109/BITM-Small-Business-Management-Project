using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.Repository;

namespace SmallBusinessManagementApp.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();
        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }
        public DataTable Display()
        {
            return _supplierRepository.Display();
        }
        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }
        public DataTable Search(Supplier supplier)
        {
            return _supplierRepository.Search(supplier);
        }
        public bool IsContactExists(Supplier supplier)
        {
            return _supplierRepository.IsContactExists(supplier);
        }
        public bool IsCodeExists(Supplier supplier)
        {
            return _supplierRepository.IsCodeExists(supplier);
        }
        public bool IsEmailExists(Supplier supplier)
        {
            return _supplierRepository.IsEmailExists(supplier);
        }

    }
}
