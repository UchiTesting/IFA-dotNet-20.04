using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ExoLINQ4
{
    public class Employee
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Post{ get; set; } // Should be a separate class or enum in next version
        public SeniorityEnum Seniority{ get; set; } // Might be an enum later.

         public Employee(int id, string name, string post, SeniorityEnum seniority)
         {
             Id = id;
             Name = name;
             Post = post;
             Seniority = seniority;
         }

         public override bool Equals(object obj)
         {
             if (!obj.GetType().Equals(typeof(Employee)))
                 return false;
             
             Employee emp = ((Employee) obj);

             if (emp.Id == Id) return true;
             else return false;
         }

         public override string ToString()
         {
             return $"Employee {Id} {Name} {Post} {Seniority}";
         }
    }
}