using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Bonisoft_2.Global_Objects
{
    public static class Logs
    {
        public static void AddErrorLog(string message, int lineNumber, string className, string methodName, string obj)
        {
            try
            {
                string Path_Data = @"C:\inConcert\Repository\";
                if (ConfigurationManager.AppSettings != null)
                {
                    Path_Data = ConfigurationManager.AppSettings["Path_Data"].ToString();
                }

                string File_ErrorLog = "error_log.txt";
                if (ConfigurationManager.AppSettings != null)
                {
                    File_ErrorLog = ConfigurationManager.AppSettings["File_ErrorLog"].ToString();
                }

                if (!Directory.Exists(Path.GetDirectoryName(Path_Data)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Path_Data));
                }
                using (StreamWriter writer = new StreamWriter(Path_Data + File_ErrorLog, true))
                {
                    string text = DateTime.Now.ToString() + ": [ln:" + lineNumber +"] " + className + ": " + methodName + "() - " + message + " " + obj + ".";
                    writer.WriteLine(text);
                }
            }
            catch (Exception) { }
        }

        public static void AddUserLog(string message, string object_ID, string userID_str, string username)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                log new_log = new log();
                new_log.Fecha = DateTime.Now;
                new_log.Usuario = username;
                new_log.Descripcion = message;
                new_log.Dato = object_ID;

                int userID = 0;
                if (!int.TryParse(userID_str, out userID))
                {
                    userID = 0;
                    AddErrorLog("Excepcion. Convirtiendo int. ERROR:", lineNumber, className, methodName, userID_str);
                }

                new_log.Usuario_ID = userID;
                context.logs.Add(new_log);
                context.SaveChanges();
            }
        }

    }
}
    