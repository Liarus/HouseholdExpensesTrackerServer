using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Web.Helpers
{
    public class Md5Hasher
    {
        public static string ComputeHash(string data)
        {
            return BitConverter.ToString(
              MD5.Create().ComputeHash(
                Encoding.UTF8.GetBytes(data)
              )
            );
        }
    }
}
