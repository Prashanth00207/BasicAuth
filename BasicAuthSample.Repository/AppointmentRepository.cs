using BasicAuthSample.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuthSample.Repository
{
    public class AppointmentRepository
    {
        public static List<Appointment> GetAppointments()
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            return db.Appointments.Include(a=>a.User).Include(a=>a.Doctor).Include(a=>a.CreatedByNavigation).Include(a=>a.ModifiedByNavigation).ToList();
        }
        public static Appointment Create(Appointment appointment)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return appointment;
        }
        public static List<Appointment> GetAppointmentsByDoctorId(int id)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            return db.Appointments.Include(a => a.User).Include(a => a.Doctor).Include(a => a.CreatedByNavigation).Include(a => a.ModifiedByNavigation).Where(a=>a.DoctorId==id).ToList();
        }
        public static List<Appointment> GetAppointmentsByPatientId(int id)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            return db.Appointments.Include(a => a.User).Include(a => a.Doctor).Include(a => a.CreatedByNavigation).Include(a => a.ModifiedByNavigation).Where(a=>a.UserId==id).ToList();
        }
    }
}
