using System;
using System.Collections.Generic;

#nullable disable

namespace BasicAuthSample.Repository.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
