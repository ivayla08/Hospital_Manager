using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager.Core.Interfaces;
using Hospital_Manager.Core.Services;
using Hospital_Manager.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Manager.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;

        public PatientController(IPatientService pService, IDoctorService dService)
        {
            patientService = pService;
            doctorService = dService;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await patientService.GetAllPatientListAsync();

            var model = new List<PatientIndexViewModel>();

            foreach (var patient in patients)
            {
                model.Add(new PatientIndexViewModel
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,

                    DoctorName = string.Join(", ", patient.DoctorPatients
                    .Select(x => x.Doctor.FirstName + " " + x.Doctor.LastName))

                });

            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientDetailsViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,

                DoctorName = string.Join(", ", patient.DoctorPatients
                    .Select(x => x.Doctor.FirstName + " " + x.Doctor.LastName))
            };
            return View(model);
        }

        public async Task LoadDoctors(List<int> selectedDoctors = null)
        {
            var allDoctors = await doctorService.GetAllDoctorListAsync();
            var doctors = allDoctors
                .Select(x => new
                {
                    x.Id,
                    FullName = x.FirstName + " " + x.LastName
                });
                

            ViewBag.Doctors = new MultiSelectList(doctors, "Id", "FullName", selectedDoctors);
        }

        public async Task<IActionResult> Create()
        {
            await LoadDoctors();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                foreach (var doctorId in model.DoctorIds)
                {
                    patient.DoctorPatients.Add(new DoctorPatient
                    {
                        DoctorId = doctorId
                    });
                }
               await patientService.AddPatientAsync(patient);
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctors(model.DoctorIds);
            return View(model);
        }

        //get
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientEditViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                DoctorIds = patient.DoctorPatients.Select(x => x.DoctorId).ToList()
            };
            await LoadDoctors(model.DoctorIds);
            return View(model);
        }
        //post
        [HttpPost]

        public async Task<IActionResult> Edit(int id, PatientEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var patient = await patientService.GetPatientByIdAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }

                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.Email = model.Email;
                patient.PhoneNumber = model.PhoneNumber;

                patient.DoctorPatients.Clear();

                foreach (var doctorId in model.DoctorIds)
                {
                    patient.DoctorPatients.Add(new DoctorPatient
                    {
                        DoctorId = doctorId,
                        PatientId = patient.Id
                    });
                }

                await patientService.UpdatePatientAsync(patient,model.DoctorIds);
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctors(model.DoctorIds);
            return View(model);
        }

        //get

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientDeleteViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,

            };
            return View(model);
        }

        //post
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
