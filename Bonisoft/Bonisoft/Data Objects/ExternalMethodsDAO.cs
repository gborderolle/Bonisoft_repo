using Bonisoft.Extras;
using Bonisoft.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bonisoft.Data_Objects
{
    internal class ExternalsMethodDAO : Data_Generic.DataAccessObject
    {
        public ExternalsMethodDAO()
        {
        }

        public string CheckLogin(string username, string password, bool isPasswordInput_hashed, bool isTokenLogin = false)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Usuario user = new Usuario("", username);
                if (user != null && !string.IsNullOrWhiteSpace(user.id) && user.deleted != 1 && user.disabled != 1)
                {
                    if (!isTokenLogin)
                    {
                        // If is hashed in DB, then get my input password hashed
                        string password_hash = password;
                        if (!isPasswordInput_hashed)
                        {
                            password_hash = BCrypt.HashPassword(password, user.password);
                        }

                        if (user.password.Equals(password_hash))
                        {
                            result = user.id;
                        }
                    }
                    else
                    {
                        result = user.id;
                    }
                }
            }
            return result;
        }

    }
}