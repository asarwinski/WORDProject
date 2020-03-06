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

        public void AddExam(Exam exam)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.DoesExamineeExist @Pesel";
                int? examinee_id = connection.Query<int?>(sql, new { Pesel = exam.Examinee.Pesel }).FirstOrDefault();
                if (examinee_id == null)
                {
                    sql = "dbo.AddAddress @City, @State, @Country, @Zipcode";
                    int address_id = connection.Query<int>(sql, exam.Examinee.Address).Single();
                    sql = "dbo.AddExaminee @Name, @Surname, @Pesel, @BirthDate, @Address_Id";
                    var p = new { Name = exam.Examinee.Name, Surname = exam.Examinee.Surname, Pesel = exam.Examinee.Pesel, BirthDate = exam.Examinee.BirthDate, address_id };
                    examinee_id = connection.Query<int?>(sql, p).Single();
                }
                sql = "dbo.AddExam @Examinee_Id, @Examiner_Id, @Category, @Date";
                var e = new { Examinee_id = examinee_id, Examiner_Id = exam.Examiner.Id, Category = exam.Category, Date = exam.Date };
                connection.Execute(sql, e);
            }
        }

        public void AddExaminer(Examiner examiner)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.AddAddress @City, @State, @Country, @Zipcode";
                int address_id = connection.Query<int>(sql, examiner.Address).Single();

                sql = "dbo.AddExaminer @Name, @Surname, @Pesel, @BirthDate, @Address_Id";
                var e = new { Name = examiner.Name, Surname = examiner.Surname, Pesel = examiner.Pesel, BirthDate = examiner.BirthDate, Address_Id = address_id };
                int examiner_id = connection.Query<int>(sql, e).Single();
                foreach (string category in examiner.Permissions)
                {
                    sql = "dbo.AddCategory @Examiner_Id, @Category";
                    var p = new { Examiner_Id = examiner_id, Category = category };
                    connection.Execute(sql, p);
                }
            }
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
                string sql = "dbo.GetExamineeById @Id";
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

        public async Task<List<Exam>> GetFinishedExams(Examiner examiner = null, Examinee examinee = null, string category = null, DateTime? date = null, bool? result = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetFinishedExams @Examiner_Id, @Examinee_Id, @Category, @Date, @Result";
                int? examiner_id = examiner == null ? null : (int?)examiner.Id;
                int? examinee_id = examinee == null ? null : (int?)examinee.Id;
                var p = new { Examiner_Id = examiner_id, Examinee_Id = examinee_id, Category = category, Date = date, Result = result };
                var exams = await connection.QueryAsync<Exam, int, int, Exam>(sql,
                    (exam, ee_id, er_id) =>
                    {
                        var x = GetExamineeById(ee_id);
                        var y = GetExaminerById(er_id);
                        exam.Examinee = x;
                        exam.Examiner = y;
                        return exam;
                    },
                    param: p,
                    splitOn: "Examinee_Id, Examiner_Id");
                return exams.ToList();
            }
        }

        public async Task<List<Exam>> GetFutureExams(Examiner examiner = null, Examinee examinee = null, string category = null, DateTime? date = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.GetFutureExams @Examiner_Id, @Examinee_Id, @Category, @Date";
                int? examiner_id = examiner == null ? null : (int?)examiner.Id;
                int? examinee_id = examinee == null ? null : (int?)examinee.Id;
                var p = new { Examiner_Id = examiner_id, Examinee_Id = examinee_id, Category = category, Date = date };
                var exams = await connection.QueryAsync<Exam, int, int, Exam>(sql,
                    (exam, ee_id, er_id) =>
                    {
                        var x = GetExamineeById(ee_id);
                        var y = GetExaminerById(er_id);
                        exam.Examinee = x;
                        exam.Examiner = y;
                        return exam;
                    }, 
                    param: p,
                    splitOn: "Examinee_Id, Examiner_Id");
                return exams.ToList();
            }
        }

        public bool CheckPassword(string login, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                string sql = "dbo.CheckPassword @Login, @Password";
                var p = new { Login = login, Password = password };
                return connection.Query<int>(sql, p).Single() > 0;
            }
        }
    }
}
