using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentListView
{
    internal class Student
    {
        //Fields
        String name;
        double grade1;
        double grade2;
        double averageGrade;

        //Constructors
        public Student(string name, double grade1, double grade2)
        {
            this.name = name;
            this.grade1 = grade1;
            this.grade2 = grade2;
            this.averageGrade = GetAverageGrade();
        }

        //Properties
        public string Name { get => name; set => name = value; }
        public double Grade1 { get => grade1; set => grade1 = value; }
        public double Grade2 { get => grade2; set => grade2 = value; }
        public double AverageGrade { get => averageGrade; set => averageGrade = value; }

        //Methods
        public double GetAverageGrade()
        {
            //Gets the average of grade1 and grade 2
            return (this.grade1 + this.grade2) / 2;
        }
        public override string ToString()
        {
            return $"Student Name: {this.name} Grade 1: {this.grade1} Grade 2: {this.grade2} Average: {this.averageGrade}";
        }
    }
}
