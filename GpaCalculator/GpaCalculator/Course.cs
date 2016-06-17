using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpaCalculator
{
    public class Course
    {
        /* Instance Variables */
        private String code; // CSC108H
        private int grade;
        private double weight;
        private float value;

        // Encapsulate
        public String Code
        {
            set
            {
                if (Code.Length != 7)
                {
                    throw new Exception();
                }
                this.code = Code;
            }
            get { return this.code; }
        }
        public double Weight
        {
            set { this.weight = Weight; }
            get { return this.weight; }
        }

        public int Grade
        {
            set { this.grade = Grade; }
            get { return this.grade; }
        }

        public float Value
        {
            set { this.value = Value; }
            get { return this.value; }
        }

        /* Constructor */
        public Course(String CourseCode, int CourseGrade)
        {
            this.Code = CourseCode;
            this.Grade = CourseGrade;
            this.Weight = getWeight();
            this.Value = calculateGPA();
        }

        /* Methods */

        // Return 0.5 or 1.0 depending on the course code
        public double getWeight()
        {
            char type = this.Code[this.Code.Length - 1];

            if (type != 'Y' || type != 'H')
            {
                throw new Exception();
            }

            switch (type){
                case 'Y':
                    return 1.0;
                case 'H':
                    return 0.5;                
            }
            return -1;
        }

        public float getValue()
        {
            return this.Value;
        }

        // Determine GPA value of this course based on grade
        public float calculateGPA()
        {
            if (this.Grade >= 85)
                return (float) 4.0;
            if (this.Grade >= 80)
                return (float) 3.7;
            if (this.Grade >= 77)
                return (float) 3.3;
            if (this.Grade >= 73)
                return (float) 3.0;
            if (this.Grade >= 70)
                return (float) 2.7;
            if (this.Grade >= 67)
                return (float) 2.3;
            if (this.Grade >= 63)
                return (float) 2.0;
            if (this.Grade >= 60)
                return (float) 1.7;
            if (this.Grade >= 57)
                return (float) 1.3;
            if (this.Grade >= 53)
                return (float) 1.0;
            if (this.Grade >= 50)
                return (float) 0.7;
            else
                return (float) 0.0;
        }
    }
}
