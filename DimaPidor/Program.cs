using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DimaPidor
{
    class Program
    {
        static void Main(string[] args)
        {
            MyValid mv = new MyValid();
            Console.WriteLine(mv.IsEmailValid("qwertymail.com"));
        }
    }

    public abstract class Validator
    {
        public abstract bool IsPasswordValid(string password);
        public abstract string HashPassword(string password);
        public abstract bool IsUserExists(string login, string password);
        public abstract bool IsEmailValid(string email);
        public abstract bool IsPhoneValid(string phone);
        public abstract bool IsWebPageAvailable(string url);
        public abstract bool IsDatabaseAccessible(string connectionString);
        public abstract bool IsDateValid(string date);
        public abstract bool IsUserRoot();
        public abstract void Log();
    }

    public class MyValid : Validator
    {
        public override string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        
        }

        public override bool IsDatabaseAccessible(string connectionString)
        {
            throw new NotImplementedException();
        }

        public override bool IsDateValid(string date)
        {
            DateTime dDate;
            if (DateTime.TryParse(date, out dDate))
            {
                return true;
            }
            return false;
        }

        public override bool IsEmailValid(string email)
        {
            const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            var mail = email.Trim().ToLowerInvariant();

            if (Regex.Match(email, pattern).Success)
            {
                return true;
            }
            return false;
        }

        public override bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }

        public override bool IsPhoneValid(string phone)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserExists(string login, string password)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserRoot()
        {
            throw new NotImplementedException();
        }

        public override bool IsWebPageAvailable(string url)
        {
            throw new NotImplementedException();
        }

        public override void Log()
        {
            throw new NotImplementedException();
        }
    }
}
