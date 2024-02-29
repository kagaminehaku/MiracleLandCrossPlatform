using DAL;
using System.Text.RegularExpressions;

namespace BUS
{
    public class BUSuser_account
    {

        public string RegisterUser(string usn, string pwd, string tp, string em, string pe, string add)
        {
            pwd = BUSPWDHashing.EncryptData(pwd);
            var daluseraccount = new DALuser_account();
            string username = daluseraccount.RegisterUser(usn, pwd, tp, em, pe, add);
            return username;
        }

        public bool UpdatePassword(string usn, string newpwd)
        {
            newpwd = BUSPWDHashing.EncryptData(newpwd);
            var daluseraccount = new DALuser_account();
            return daluseraccount.UpdatePassword(usn, newpwd);
        }

        public bool IsPasswordVaild(string password)
        {
            string pattern = @"^.{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
    }
}
