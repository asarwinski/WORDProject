﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORDProjectClassLib.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public Examinee Examinee { get; set; }
        public Examiner Examiner { get; set; }

    }
}