using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement_WebAPI.Models
{
    public class LoginDetails
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
        
    }
}
