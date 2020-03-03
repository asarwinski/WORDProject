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

        public async Task<List<Examinee>> GetExaminees(string name = null, string surname = null, string category = null, string city = null, DateTime? birthDate = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = @"SELECT * 
                               FROM [dbo].[Examinees] e
                               INNER JOIN [dbo].[Addresses] a on e.Address_Id = a.Id";
                var examinees = await connection.QueryAsync<Examinee, Address, Examinee>(sql,
                (examinee, address) =>
                {
                    examinee.Address = address;
                    return examinee;
                },
                splitOn: "Id");

                return examinees.ToList();
            }
        }

        public Task<List<Examiner>> GetExaminers(string name = null, string surname = null, string category = null, string city = null, DateTime? birthDate = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exam>> GetExams(Examiner examiner = null, Examinee examinee = null, string category = null, DateTime? date = null, bool? result = null)
        {
            throw new NotImplementedException();
        }
    }
}
