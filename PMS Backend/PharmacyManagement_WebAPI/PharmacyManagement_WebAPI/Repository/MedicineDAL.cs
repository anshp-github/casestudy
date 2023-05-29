using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public class MedicineDAL:IMedicineRepository
    {
       
            private readonly PharmacyDbContext _context;

            public MedicineDAL(PharmacyDbContext context)
            {
                _context = context;
            }
        #region Get medicine list
        public async Task<List<Medicine>> GetAllMedicines()
            {
            try
            {
                var records = await _context.Medicines.Select(x => new Medicine()
                {
                    MedicineId = x.MedicineId,
                    MedName = x.MedName,
                    MedExpDate = x.MedExpDate,
                    MedPrice = x.MedPrice,
                    MedStock = x.MedStock,
                    MedImage = x.MedImage,

                }).ToListAsync();
                return records;
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
                var records = await _context.Medicines.Where(x => x.MedName == MedName).Select(x => new Medicine()
                {
                    MedicineId = x.MedicineId,
                    MedName = x.MedName,
                    MedExpDate = x.MedExpDate,
                    MedPrice = x.MedPrice,
                    MedStock = x.MedStock,
                    MedImage = x.MedImage,

                }).FirstOrDefaultAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Insert medicine
        public async Task<int> AddMedicine(Medicine medicine)
            {
            try
            {
                var med = new Medicine()
                {
                    MedExpDate = medicine.MedExpDate,
                    //MedicineId = medicine.MedicineId,
                    MedName = medicine.MedName,
                    MedPrice = medicine.MedPrice,
                    MedStock = medicine.MedStock,
                    MedImage = medicine.MedImage,

                };
                _context.Medicines.AddAsync(med);
                await _context.SaveChangesAsync();
                return med.MedicineId;
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
                var med = await _context.Medicines.FindAsync(id);
                if (med != null)
                {
                    med.MedStock = medicine.MedStock;
                    med.MedPrice = medicine.MedPrice;
                    med.MedName = medicine.MedName;
                    med.MedExpDate = medicine.MedExpDate;
                    med.MedImage = medicine.MedImage;
                };

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        //public async Task UpdateMedicineByStock(int id, JsonPatchDocument medicine)
        //{
        //    var med = await _context.Medicines.FindAsync(id);

        //    if (med != null)
        //    {
        //        medicine.ApplyTo(med);
        //        await _context.SaveChangesAsync();

        //    }

        //}
        #region Delete Medicine
        public async Task DeleteMedicine(int id)
            {
            try
            {
                var med = new Medicine() { MedicineId = id };
                _context.Medicines.Remove(med);
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
