﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USM.DAL.Models;

namespace USM.DAL
{
    public class USMDatabaseDataInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<USMContext>
    {
        public void SeedData(USMContext context)
        {
            Seed(context);
        }
        protected override void Seed(USMContext context)
        {
            

            /*var students = new List<Student>
                {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="MFM",LastName="MFM",EnrollmentDate=DateTime.Parse("2005-09-01")}
                };

            students.ForEach(s => context.Students.Add(s));*/
            context.SaveChanges();
        }
    }
}
