using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Data
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPickedUp { get; set; } = false;
        public int Amount { get; set; }
        public int Count { get; set; }
        public int DoctorId { get; set; }
        public int AdminId { get; set; }
        public int MedicineId { get; set; }
        public DoctorRegistration Doctor { get; set; }
        public Admin Admin { get; set; }
        public Medicine Medicine { get; set; }
    }
}
