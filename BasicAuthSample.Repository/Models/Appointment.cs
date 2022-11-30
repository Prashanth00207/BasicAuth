using System;
using System.Collections.Generic;

#nullable disable

namespace BasicAuthSample.Repository.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Login CreatedByNavigation { get; set; }
        public virtual Login Doctor { get; set; }
        public virtual Login ModifiedByNavigation { get; set; }
        public virtual Login User { get; set; }
    }
}
