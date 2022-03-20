using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public int DepartmentId { get; set; }
        public string Title { get; set; }

        
        public EmployeeExperience Experience 
        {
            get
            {
                var expericence = (LeaveDate.Value - HireDate.Value).TotalDays / 365.25;
                if (HireDate==null)
                {
                    return EmployeeExperience.None;
                }
                else if (expericence<=2)
                {
                    return EmployeeExperience.Junior;
                }
                else if (expericence>2 && expericence<=5)
                {
                    return EmployeeExperience.Middle;
                }
                else if (expericence>5&& expericence<=10)
                {
                    return EmployeeExperience.Senior;
                }
                else
                {
                    return EmployeeExperience.Principal_Architect;
                }
              
            }
                
        
        
        
        }
        private DateTime? _hireDate;
        public DateTime? HireDate {
            get { return _hireDate; }
            set
            {
                _hireDate = value;

                if (_hireDate==null)
                {
                    _hireDate = null;
                }             
            } 
        }
        private DateTime? _leaveDate;
        public DateTime? LeaveDate {
            get { return _leaveDate; }
            set
            {
                if (HireDate==null)
                {
                    _leaveDate = null;
                }
                _leaveDate = value;
            }
        }
        public Department Department { get; set; }
    }
}
