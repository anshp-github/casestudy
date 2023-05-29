using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement_WebAPI.Data
{
    public class Doctors
    {
        [Key]
        public int DoctorId { get; set; }
        public string DocName { get; set; }
        public string DocEmail { get; set; }
        public double DocPhnNum { get; set; }
        public string DocPassword { get; set; }
        public string DocAddress { get; set; }
    }
}
