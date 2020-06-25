using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GradeBook.GradeBooks
{
   
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
        : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            List<Student> slist = Students.OrderBy(x => x.AverageGrade).ToList();
            int t = slist.FindIndex(x => x.AverageGrade == averageGrade);
            t++;
            double per = Convert.ToDouble(decimal.Divide(t , Students.Count));
            if (per > .8) { return 'A'; }
            if (per > .6) { return 'B'; }
            if (per > .4) { return 'C'; }
            if (per > .2) { return 'D'; }
            return 'F';
             
        }

    }
}
