using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface ITeacher
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Wage { get; set; }
        bool Married { get; set; }
        int NumberOfStudent { get; set; }

        School School { get; set; }
        int SchoolID { get; set; }
    }
}
