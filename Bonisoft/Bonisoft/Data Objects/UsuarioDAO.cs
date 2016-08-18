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
    internal class UsuarioDAO : Data_Generic.DataAccessObject
    {
        public UsuarioDAO()
        {
        }

        internal static void Fill(Usuario user)
        {
            string query = "SELECT userName,groupName,password,passwordDate,deleted,disabled,dateCreated,dateDeleted,dateDisabled FROM incuser WHERE id = @id";
            Hashtable param = new Hashtable();
            param.Add("@id", user.id);

            using (DataTable dt = ExecuteDataTableQuery(query, param))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    user.id = user.id;
                    user.userName = (row["userName"] != DBNull.Value) ? row["userName"].ToString() : string.Empty;
                    user.groupName = (row["groupName"] != DBNull.Value) ? row["groupName"].ToString() : string.Empty;
                    user.password = (row["password"] != DBNull.Value) ? row["password"].ToString() : string.Empty;
                    user.passwordDate = (row["passwordDate"] != DBNull.Value) ? DateTime.Parse(row["passwordDate"].ToString()) : DateTime.Now;
                    user.deleted = (row["deleted"] != DBNull.Value) ? int.Parse(row["deleted"].ToString()) : 0;
                    user.disabled = (row["disabled"] != DBNull.Value) ? int.Parse(row["disabled"].ToString()) : 0;
                    user.dateCreated = (row["dateCreated"] != DBNull.Value) ? DateTime.Parse(row["dateCreated"].ToString()) : DateTime.Now;
                    user.dateDeleted = (row["dateDeleted"] != DBNull.Value) ? DateTime.Parse(row["dateDeleted"].ToString()) : DateTime.Now;
                    user.dateDisabled = (row["dateDisabled"] != DBNull.Value) ? DateTime.Parse(row["dateDisabled"].ToString()) : DateTime.Now;
                }
            }
        }

        internal static void FillByUserName(Usuario user)
        {
            string query = "SELECT id, groupName,password,passwordDate,deleted,disabled,dateCreated,dateDeleted,dateDisabled FROM incuser WHERE userName = @userName";
            Hashtable param = new Hashtable();
            param.Add("@userName", user.userName);

            using (DataTable dt = ExecuteDataTableQuery(query, param))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    user.userName = user.userName;
                    user.id = (row["id"] != DBNull.Value) ? row["id"].ToString() : string.Empty;
                    user.groupName = (row["groupName"] != DBNull.Value) ? row["groupName"].ToString() : string.Empty;
                    user.password = (row["password"] != DBNull.Value) ? row["password"].ToString() : string.Empty;
                    user.passwordDate = (row["passwordDate"] != DBNull.Value) ? DateTime.Parse(row["passwordDate"].ToString()) : DateTime.Now;
                    user.deleted = (row["deleted"] != DBNull.Value) ? int.Parse(row["deleted"].ToString()) : 0;
                    user.disabled = (row["disabled"] != DBNull.Value) ? int.Parse(row["disabled"].ToString()) : 0;
                    user.dateCreated = (row["dateCreated"] != DBNull.Value) ? DateTime.Parse(row["dateCreated"].ToString()) : DateTime.Now;
                    user.dateDeleted = (row["dateDeleted"] != DBNull.Value) ? DateTime.Parse(row["dateDeleted"].ToString()) : DateTime.Now;
                    user.dateDisabled = (row["dateDisabled"] != DBNull.Value) ? DateTime.Parse(row["dateDisabled"].ToString()) : DateTime.Now;
                }
            }
        }

        #region Static Methods

        /// <summary>
        /// Retrieve role groups from DB
        /// </summary>
        /// <returns></returns>
        internal static List<Tuple<int, string>> GetUserGroups()
        {
            // #1- Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            List<Tuple<int, string>> result = new List<Tuple<int, string>>();
            Hashtable param = new Hashtable();
            string query = "SELECT id,groupName FROM orkgroup WHERE securityGroup = 0";

            using (DataTable dt = ExecuteDataTableQuery(query, param))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Tuple<int, string> tupla = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tupla = new Tuple<int, string>(int.Parse(dr["id"].ToString()), dr["groupName"].ToString());
                        result.Add(tupla);
                    }
                }
            }
            return result;
        }

        #endregion Static Methods
    }
}