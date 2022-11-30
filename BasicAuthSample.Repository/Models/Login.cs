using System;
using System.Collections.Generic;

#nullable disable

namespace BasicAuthSample.Repository.Models
{
    public partial class Login
    {
        public Login()
        {
            AppointmentCreatedByNavigations = new HashSet<Appointment>();
            AppointmentDoctors = new HashSet<Appointment>();
            AppointmentModifiedByNavigations = new HashSet<Appointment>();
            AppointmentUsers = new HashSet<Appointment>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string City { get; set; }
        public int UserTypeId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Appointment> AppointmentCreatedByNavigations { get; set; }
        public virtual ICollection<Appointment> AppointmentDoctors { get; set; }
        public virtual ICollection<Appointment> AppointmentModifiedByNavigations { get; set; }
        public virtual ICollection<Appointment> AppointmentUsers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
