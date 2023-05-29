using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public interface IDoctorRepository
    {
        Task<List<DoctorRegistration>> GetAllDoctors();
        Task<DoctorRegistration> GetDoctorByName(string DocEmail);
        Task<int> AddDoctor(DoctorRegistration doctor);
        Task DeleteDoctor(int id);
    }
}
