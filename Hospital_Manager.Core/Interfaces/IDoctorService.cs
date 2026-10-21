using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorListAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task<Doctor?> GetDoctorDetailsAsync(int id);
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }
}
