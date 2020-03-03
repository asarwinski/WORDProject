using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORDProjectUI.Utils
{
    public static class ConnectionStringHelper
    {
        private static Dictionary<DBType, string> dbNames = new Dictionary<DBType, string>()
        {
            {DBType.Local, "Local" },
            {DBType.Docker, "Docker" }
        };
        public static string GetConnectionString(DBType dbType)
        {
            string dbName = dbNames[dbType];
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }
    }

    public enum DBType
    {
        Local = 1,
        Docker = 2
    }
}
