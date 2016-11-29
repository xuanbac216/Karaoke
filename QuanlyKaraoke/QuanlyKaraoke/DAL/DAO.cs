using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanlyKaraoke.DAL
{
    public class DAO
    {
        public static DbConnection dbConnection { get; set; }
        public DAO()
        {
            GetDbConnection();
        }
        public static void GetDbConnection()
        {
            //var dbfactory = DbProviderFactories.GetFactory("system.data.sqlclient");
            //var dbconnection = dbfactory.CreateConnection();
            //var servername = "localhost";
            //var dbname = "nhanviendb";
            //var connectionstring = string.Format("data source={0};initial catalog={1};integrated security=true;multipleactiveresultsets=true", servername, dbname);
            //dbconnection.ConnectionString = connectionstring;
            //return dbconnection;
            var dbfactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
            dbConnection = dbfactory.CreateConnection();
            var serverName = "localhost";
            var dbName = "karaoke";
            var userName = "root";
            var password = "";
            var charSet = "utf8";
            var connectionString = String.Format(@"server={0};userid={1};password={2};database={3}; CharSet={4}",
                serverName, userName, password, dbName, charSet);
            dbConnection.ConnectionString = connectionString;
        }
        public static void OpenConnection()
        {
            try
            {
                GetDbConnection();
                dbConnection.Open();

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }
        }

        public static void CloseConnection()
        {
            try
            {
                dbConnection.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public static DbParameter AddParam(DbCommand cmd, String paramName, DbType dbtype, Object value)
        {
            var p = cmd.CreateParameter();
            p.DbType = dbtype;
            p.ParameterName = paramName;
            p.Value = value;
            cmd.Parameters.Add(p);
            return p;
        }
    }
}
