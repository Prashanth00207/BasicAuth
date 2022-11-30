using BasicAuthSample.Repository;
using BasicAuthSample.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicAuthSample.Controllers
{
    public class AppointmentController : Controller
    {
        // [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            List<Appointment> appointments = null;
            Login login = LoginRepository.GetUserByUserName(User.Identity.Name);
            if (login.UserRoles.ToList().Where(ur => ur.Role.Name == "Admin").Count() > 0)
            {
                appointments = AppointmentRepository.GetAppointments();

            }
            //is a Patient
            else
            {
                appointments = AppointmentRepository.GetAppointmentsByPatientId(login.Id);

            }
            //Get appointment from db
            return View(appointments);
        }
        
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.Patients = LoginRepository.GetUsers(UserTypeEnum.PATIENT);
            ViewBag.Doctors = LoginRepository.GetUsers(UserTypeEnum.DOCTOR);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            Login login = LoginRepository.GetUserByUserName(User.Identity.Name);
            appointment.CreatedBy = login.Id;
            appointment.CreatedDate = DateTime.Now;
            appointment.ModifiedBy = login.Id;
            appointment.ModifiedDate = DateTime.Now;
            appointment = AppointmentRepository.Create(appointment);
            return RedirectToAction("List");
        }
    }
}
