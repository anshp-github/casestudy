using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement_WebAPI.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Required(ErrorMessage = "Name is requierd!")]
        [Display(Name = "Name")]
        public string MedName { get; set; }
        [Required(ErrorMessage = "Price is requierd!")]
        [Display(Name = "Price")]
        public int MedPrice { get; set; }
        [Required(ErrorMessage = "Expiry date is requierd!")]
        [Display(Name = "Expiry Date")]
        public DateTime MedExpDate { get; set; }
        [Required(ErrorMessage = "Stock is requierd!")]
        [Display(Name = "Stock")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int MedStock { get; set; }
        public string MedImage { get; set; }
    }
}
