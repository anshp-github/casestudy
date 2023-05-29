using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement_WebAPI.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Name")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Email Address is required!")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string SupplierEmail { get; set; }
        [Required(ErrorMessage = "Phone Number is required!")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Entered phone number format is not valid.")]
        public double SupplierPhnNum { get; set; }
        public int MedicineId { get; set; }
        [ValidateNever]
        public Medicine Medicine { get; set; }
    }
}
