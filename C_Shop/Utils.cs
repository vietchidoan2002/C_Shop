using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace C_Shop
{

    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sda;
        SqlDataReader sdr;
        DataTable dt;

        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        public static bool IsValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExension = { ".jpg", ".jpeg", ".png", ".gif" };
            foreach (string file in fileExension)
            {
                if (file.Contains(file))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
        public static string getUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

    }
}