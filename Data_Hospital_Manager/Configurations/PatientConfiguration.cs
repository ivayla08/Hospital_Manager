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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(new Patient
            {
                Id = 1,
                FirstName = "Ivayla",
                LastName = "Ivanova",
                Email = "ivayla@mail.bg",
                PhoneNumber = "0891234567"

            },
            new Patient
            {
                Id = 2,
                FirstName = "Petya",
                LastName = "Petrova",
                Email = "petya@mail.bg",
                PhoneNumber = "0891934567"

            });

        }
  
    }
}
