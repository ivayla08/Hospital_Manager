using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                 new Doctor
                 {
                     Id = 1,
                     FirstName = "Niya",
                     LastName = "Ivanova",
                     Email = "niya@mail.bg",
                     PhoneNumber = "0888888888",
                     Specialty = "Cardiologist",
                     HospitalId = 3
                 },
                 new Doctor
                 {
                     Id = 2,
                     FirstName = "Dariya",
                     LastName = "Vulkova",
                     Email = "dariya@mail.bg",
                     PhoneNumber = "0888888888",
                     Specialty= "Neurologist",
                        HospitalId = 4
                 });

        }
    }
}
