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
                string sql = "dbo.GetExaminees @Name, @Surname, @Category, @City, @BirthDate";
                var p = new { Name = name, Surname = surname, Category = category, City = city, BirthDate = birthDate };
                var result = await connection.QueryAsync<Examinee, Address, string, Examinee>(sql,
                    (examinee, address, c) =>
                    {
                        examinee.Address = address;
                        examinee.Categories.Add(c);
                        return examinee;
                    },
                    param: p,
                    splitOn: "Id, Category");
                var examinees = result.GroupBy(x => x.Id).Select(x =>
                {
                    var e = x.First();
                    e.Categories = x.Select(z => z.Categories.Single()).ToList();
                    return e;
                }).ToList();
                return examinees;
            }
        }

        public async Task<List<Examiner>> GetExaminers(string name = null, string surname = null, string category = null, string city = null, DateTime? birthDate = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetExaminers @Name, @Surname, @Category, @City, @BirthDate";
                var p = new { Name = name, Surname = surname, Category = category, City = city, BirthDate = birthDate };
                var result = await connection.QueryAsync<Examiner, Address, string, Examiner>(sql,
                    (examiner, address, c) =>
                    {
                        examiner.Address = address;
                        examiner.Permissions.Add(c);
                        return examiner;
                    },
                    param: p,
                    splitOn: "Id, Category");
                var examiners = result.GroupBy(x => x.Id).Select(x =>
                {
                    var e = x.First();
                    e.Permissions = x.Select(z => z.Permissions.Single()).ToList();
                    return e;
                }).ToList();
                return examiners;
            }
        }

        private Examiner GetExaminerById(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetExaminerById @Id";
                var p = new { Id = id };
                var reslut = connection.Query<Examiner, Address, string, Examiner>(sql,
                    (e, address, c) =>
                    {
                        e.Address = address;
                        e.Permissions.Add(c);
                        return e;
                    },
                    param: p,
                    splitOn: "Id, Category");
                var examiner = reslut.GroupBy(x => x.Id).Select(x =>
                {
                    var e = x.First();
                    e.Permissions = x.Select(z => z.Permissions.Single()).ToList();
                    return e;
                }).Single();
                return examiner;
            }
        }

        private Examinee GetExamineeById(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetExaminerById @Id";
                var p = new { Id = id };
                var reslut = connection.Query<Examinee, Address, string, Examinee>(sql,
                    (e, address, c) =>
                    {
                        e.Address = address;
                        e.Categories.Add(c);
                        return e;
                    },
                    param: p,
                    splitOn: "Id, Category");
                var examinee = reslut.GroupBy(x => x.Id).Select(x =>
                {
                    var e = x.First();
                    e.Categories = x.Select(z => z.Categories.Single()).ToList();
                    return e;
                }).Single();
                return examinee;
            }
        }

        public async Task<List<Exam>> GetExams(Examiner examiner = null, Examinee examinee = null, string category = null, DateTime? date = null, bool? result = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetExams @Examiner_Id, @Examinee_Id, @Category, @Date, @Result";
                var p = new { Examiner_Id = examiner.Id, Examinee_Id = examinee.Id, Category = category, Date = date, Result = result };
                var exams = await connection.QueryAsync<Exam, int, int, Exam>(sql,
                    (exam, examinee_id, examiner_id) =>
                    {
                        var x = GetExamineeById(examinee_id);
                        var y = GetExaminerById(examiner_id);
                        exam.Examinee = x;
                        exam.Examiner = y;
                        return exam;
                    });
                return exams.ToList();
            }
        }
    }
}
