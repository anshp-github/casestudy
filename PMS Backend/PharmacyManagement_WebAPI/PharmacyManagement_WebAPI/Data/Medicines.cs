namespace PharmacyManagement_WebAPI.Data
{
    public class Medicines
    {
        public int MedicineId { get; set; }
        public string MedName { get; set; }
        public int MedPrice { get; set; }
        public DateTime MedExpDate { get; set; }
        public int MedStock { get; set; }
    }
}
