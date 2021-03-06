﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WORDProjectClassLib.Models;

namespace WORDProjectClassLib.DB
{
    public interface IDataAccess
    {
        Task<List<Exam>> GetFutureExams(Examiner examiner = null, Examinee examinee = null, string category = null,
                            DateTime? date = null);
        Task<List<Exam>> GetFinishedExams(Examiner examiner = null, Examinee examinee = null, string category = null,
                            DateTime? date = null, bool? result = null);
        Task<List<Examinee>> GetExaminees(string name = null, string surname = null, string category = null,
                                    string city = null, DateTime? birthDate = null);
        Task<List<Examiner>> GetExaminers(string name = null, string surname = null, string category = null,
                                    string city = null, DateTime? birthDate = null);
        void AddExaminer(Examiner examiner);
        void AddExam(Exam exam);

        bool CheckPassword(string login, string password);
    }
}