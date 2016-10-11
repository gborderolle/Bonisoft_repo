using Bonisoft_2.Data_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonisoft_2.Global_Objects
{
    public class GlobalMethods
    {
        public static string CheckLogin(string user, string password, bool isPasswordInput_hashed = false)
        {
            ExternalsMethodDAO obj = new ExternalsMethodDAO();
            return obj.CheckLogin(user, password, isPasswordInput_hashed);
        }
    }
}