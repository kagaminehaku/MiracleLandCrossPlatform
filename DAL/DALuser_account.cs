using DTOCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class DALuser_account
    {
        public List<UserAccount> GetAllUser()
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.UserAccounts.AsNoTracking().ToList();
            }
        }

        public UserAccount GetUserByUsername(string usn)
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.UserAccounts.FirstOrDefault(u => u.Username == usn);
            }
        }

        public string RegisterUser(string usn, string pwd, string tp, string em, string pe, string add)
        {

            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var existingUser = GetUserByUsername(usn);
                    if (existingUser != null)
                    {
                        return "Duplicate";
                    }

                    var user = new UserAccount
                    {
                        Username = usn,
                        Password = pwd,
                        Type = tp,
                        Email = em,
                        Phone = pe,
                        Address = add,
                    };

                    dbContext.UserAccounts.Add(user);
                    dbContext.SaveChanges();
                    return user.Username;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return "An error occurred: " + ex.Message;
            }
        }

        public bool UpdatePassword(string usn, string newPassword)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var user = dbContext.UserAccounts.FirstOrDefault(u => u.Username == usn);
                    if (user == null) return false;

                    user.Password = newPassword;

                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }

    }
}
