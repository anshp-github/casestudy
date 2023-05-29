using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public class DoctorRegistrationDAL:IDoctorRepository
    {
        private readonly PharmacyDbContext _context;

        public DoctorRegistrationDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        #region Get doctor list
        public async Task<List<DoctorRegistration>> GetAllDoctors()
        {
            try
            {
                var records = await _context.Doctors.Select(x => new DoctorRegistration()
                {
                    DoctorId = x.DoctorId,
                    DocName = x.DocName,
                    DocEmail = x.DocEmail,
                    DocPhnNum = x.DocPhnNum,
                    DocPassword = x.DocPassword,
                    DocAddress = x.DocAddress,
                    Role = x.Role,

                }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get doctor by name
        public async Task<DoctorRegistration> GetDoctorByName(string DocEmail)
        {
            try
            {
                var records = await _context.Doctors.Where(x => x.DocEmail == DocEmail).Select(x => new DoctorRegistration()
                {
                    DoctorId = x.DoctorId,
                    DocName = x.DocName,
                    DocEmail = x.DocEmail,
                    DocPhnNum = x.DocPhnNum,
                    DocPassword = x.DocPassword,
                    DocAddress = x.DocAddress,
                    Role = x.Role,

                }).FirstOrDefaultAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Insert doctor
        public async Task<int> AddDoctor(DoctorRegistration doctor)
        {
            try
            {
                var doc = new DoctorRegistration()
                {
                    //DoctorId = doctor.DoctorId,
                    DocName = doctor.DocName,
                    DocEmail = doctor.DocEmail,
                    DocPhnNum = doctor.DocPhnNum,
                    DocPassword = doctor.DocPassword,
                    DocAddress = doctor.DocAddress,
                    Role = "Doctor",

                };
                _context.Doctors.AddAsync(doc);
                await _context.SaveChangesAsync();
                return doc.DoctorId;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region Delete doctor
        public async Task DeleteDoctor(int id)
        {
            try
            {
                var doc = new DoctorRegistration() { DoctorId = id };
                _context.Doctors.Remove(doc);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
