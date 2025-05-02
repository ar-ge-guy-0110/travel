using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace YolculukDesktop
{
    class class_dbconnections
    {
        //
        //Database Connections
        //

        //if project has finished, use this below.
        public static SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["YolculukDesktop.Properties.Settings.yolculukd_databaseConnectionString"].ConnectionString);
        //public static SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\yolculukd_database.mdf;Integrated Security = True");
        //public static SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\CyberWarrior\source\repos\YolculukDesktop\YolculukDesktop\yolculukd_database.mdf;Integrated Security = True");
    }
}
