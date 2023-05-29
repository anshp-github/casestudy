using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class MedicineServices 
    {
        IMedicineRepository _medicine;
        public MedicineServices(IMedicineRepository medicine)
        {
            try
            {
                _medicine = medicine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get medicine list
        public async Task<List<Medicine>> GetAllMedicines()
        {
            try
            {
                return await _medicine.GetAllMedicines();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get medicine by name
        public async Task<Medicine> GetMedicineByName(string MedName)
        {
            try
            {
                return await _medicine.GetMedicineByName(MedName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert Medicine
        public async Task<int> AddMedicine(Medicine medicine)
        {
            try
            {
                return await _medicine.AddMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update medicine
        public async Task UpdateMedicine(int id, Medicine medicine)
        {
            try
            {
                await _medicine.UpdateMedicine(id, medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Delete Medicine
        public async Task DeleteMedicine(int id)
        {
            try
            {
                await _medicine.DeleteMedicine(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
