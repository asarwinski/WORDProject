using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORDProjectClassLib.Models
{
    public class Examiner : IEquatable<Examiner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
        public string PermissionsDisplay
        {
            get
            {
                return string.Join(" ", Permissions);
            }
        }

        public bool Equals(Examiner other)
        {
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
