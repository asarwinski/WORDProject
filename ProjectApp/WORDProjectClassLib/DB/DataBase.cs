using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectClassLib.Models;
using Dapper;

namespace WORDProjectClassLib.DB
{
    public class DataBase : IDataAccess
    {
        public string ConnectionString { get; private set; }
        public DataBase(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void AddExaminee(Examinee examinee)
        {
            throw new NotImplementedException();
        }

        public void AddExaminer(Examiner examiner)
        {
            throw new NotImplementedException();
        }

        public List<Examinee> GetExaminees(string name = null, string surname = null, string category = null, string city = null, DateTime? birthDate = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                //string sql = "SELECT";
                //connection.QueryAsync<Examinee, Address, Examinee>()
                throw new NotImplementedException();
            }
        }

        public List<Examiner> GetExaminers(string name = null, string surname = null, string category = null, string city = null, DateTime? birthDate = null)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetExams(Examiner examiner = null, Examinee examinee = null, string category = null, DateTime? date = null, bool? result = null)
        {
            throw new NotImplementedException();
        }
    }
}
