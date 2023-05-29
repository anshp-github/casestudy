using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PharmacyManagement_WebAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement_WebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Date is requierd!")]
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }
        public bool IsPickedUp { get; set; } = false;
        [Required(ErrorMessage = "Amount is requierd!")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        public int Count { get; set; }
        public int DoctorId { get; set; }
       // public int AdminId { get; set; }
        public int MedicineId { get; set; }

        [ValidateNever]
        public DoctorRegistration Doctor { get; set; }
       // [ValidateNever]
       // public Admin Admin { get; set; }
        [ValidateNever]
        public Medicine Medicine { get; set; }
    }
}
