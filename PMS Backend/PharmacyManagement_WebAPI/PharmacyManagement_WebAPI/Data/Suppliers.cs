using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Data
{
    public class Suppliers
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
        public double SupplierPhnNum { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
