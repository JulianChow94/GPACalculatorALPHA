using System;

namespace GpaCalculator.Core
{
    public class Course : ICourse
    { 
        public String Code { get; set; }



        public int Grade { get; set; }

        public double Weight { get; set; }

        public float Value { get; set; }

        /* Constructor */
        public Course(String CourseCode, int CourseGrade)
        {
            Code = CourseCode;
            Grade = CourseGrade;
            Weight = getWeight();
            Value = calculateGPA();
        }

        public Course() { }

        /* Methods */

        // Return 0.5 or 1.0 depending on the course code
        public double getWeight()
        {
            char type = Code[Code.Length - 1];

            if (type != 'Y' && type != 'H')
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
