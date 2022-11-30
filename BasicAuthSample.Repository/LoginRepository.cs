using BasicAuthSample.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuthSample.Repository
{
    public class LoginRepository
    {
        public static Login GetUserByUserName(string userName)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            return db.Logins.Include(l => l.UserRoles).ThenInclude(ur => ur.Role).Where(u => u.UserName == userName).FirstOrDefault();
        }
        public static List<Login> GetUsers(UserTypeEnum type)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            return db.Logins.Where(u => u.UserTypeId == (int)type).ToList();
        }
        public static Login Register(Login login)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            db.Logins.Add(login);
            db.SaveChanges();
            return login;

        }


        public static Login IsLoginValid(Login login)
        {
            HospitalMgmtContext db = new HospitalMgmtContext();
            // Login dbRecord = db.Logins.Where(loginRecord => (loginRecord.UserName == login.UserName) && (loginRecord.Password == login.Password)).FirstOrDefault();
            Login dbRecord = db.Logins.Include(l => l.UserRoles).ThenInclude(ur => ur.Role).Where(loginRecord => (loginRecord.UserName == login.UserName) && (loginRecord.Password == login.Password)).FirstOrDefault();

            if (dbRecord != null)
            {
                return dbRecord;
            }
            else
            {
                return null;
            }
        }
    }
}
