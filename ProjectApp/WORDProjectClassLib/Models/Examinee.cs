using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORDProjectClassLib.Models
{
    public class Examinee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public string CategoriesDisplay 
        { 
            get
            {
                return string.Join(" ", Categories);
            }
        }
    }
}
