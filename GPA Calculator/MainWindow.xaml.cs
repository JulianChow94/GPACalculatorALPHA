using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;


namespace GPA_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // Variable Declarations
        Dictionary<string, int> Data = new Dictionary<string, int>();
        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");

        string codeTemp;
        int gradeTemp;
        double courseGPA;
        double courseWeight;
        double weightTotal;
        double finalGPA;
        double Total;


        public MainWindow()
        {
            InitializeComponent();
        }

        // Function used to calculate GPA
        // Takes in a 2 digit integer, returns a double
        public double calcGPA(int percentage)
        {
            if (percentage >= 85)
                return 4.0;
            if (percentage >= 80)
                return 3.7;
            if (percentage >= 77)
                return 3.3;
            if (percentage >= 73)
                return 3.0;
            if (percentage >= 70)
                return 2.7;
            if (percentage >= 67)
                return 2.3;
            if (percentage >= 63)
                return 2.0;
            if (percentage >= 60)
                return 1.7;
            if (percentage >= 57)
                return 1.3;
            if (percentage >= 53)
                return 1.0;
            if (percentage >= 50)
                return 0.7;
            else
                return 0.0;

            
        }


        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            // Case for nothing entered
            // Result: Error Mesage
            if (string.IsNullOrWhiteSpace(CourseCodeBox.Text) || string.IsNullOrWhiteSpace(percent.Text))
            {
                simpleSound.Play();
                MessageBox.Show("Please complete the fields!", "Error", MessageBoxButton.OK);
            }

            // Case for both fields not null
            // Result: proceed as intended
            if (!string.IsNullOrWhiteSpace(CourseCodeBox.Text) & !string.IsNullOrWhiteSpace(percent.Text))
            {
                codeTemp = CourseCodeBox.Text;
                gradeTemp = int.Parse(percent.Text);

                // Case for duplicate courses
                // Result: Error Message and do nothing
                if (Data.ContainsKey(codeTemp))
                {
                    simpleSound.Play();
                    MessageBox.Show("That Course is already in the database!", "Error", MessageBoxButton.OK);
                }

                // Case for incorrect Course Code Length
                // Result: Error Message and Data not updated
                if (codeTemp.Length != 7)
                {
                    simpleSound.Play();
                    MessageBox.Show("Incorrect Format for Course Code!\n Ex.CSC108H", "Error", MessageBoxButton.OK);
                }

                // Case for invalid %
                // Result: Error Message and Data not updated
                if (gradeTemp > 100 || gradeTemp < 0)
                {
                    simpleSound.Play();
                    MessageBox.Show("Grade has to be 0% - 100%!", "Error", MessageBoxButton.OK);
                }

                // Correct Case
                // Result: Add Course + Grade into Data and increment Weight Total 
                if ((codeTemp.Length == 7) & (gradeTemp < 100 & gradeTemp > 0) & !Data.ContainsKey(codeTemp))
                {
                    // Determine Weight of Course added and add it to weightTotal
                    if (codeTemp[codeTemp.Length - 1] == 'H')
                    {
                        courseWeight = 0.5;
                        weightTotal = weightTotal + courseWeight;
                    }
                    if (codeTemp[codeTemp.Length - 1] == 'Y')
                    {
                        courseWeight = 1.0;
                        weightTotal = weightTotal + courseWeight;
                    }

                    // Convert the grade % to GPA
                    courseGPA = calcGPA(gradeTemp);

                    // Add GPA of course to Total
                    Total = Total + (courseWeight * courseGPA);

                    // Add Course to dictionary
                    Data.Add(codeTemp, gradeTemp);
                    MessageBox.Show(CourseCodeBox.Text + " with grade " + gradeTemp + " added to database!", "Success!", MessageBoxButton.OK);

                }
            }
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Case for Dictionary Empty
            // Result: Error Message and do nothing
            if (Data.Count == 0)
            {
                simpleSound.Play();
                MessageBox.Show("Database is already empty!", "Failed!");
            }

            // Case for not emtpy Dicitonary
            // Result: Clear the Dictionary and show Message
            else
            {
                if (MessageBox.Show("Are you sure you wanted clear your courses from the database?", "Alert", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Data.Clear();
                    MessageBox.Show("Database cleared!", "Success!", MessageBoxButton.OK);
                    Total = 0.0;
                    weightTotal = 0.0;   
                }     
            }
        }


        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // If There is only one course, use it's GPA
            if (Data.Count == 1)
            {
                MessageBox.Show("Your CGPA is " + courseGPA.ToString("F"));
            }
            // If there are no courses, show message and do nothing
            if (Data.Count == 0)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
                MessageBox.Show("You have not added any courses!", "Failed!", MessageBoxButton.OK);
                
            }
            // Standard Case: Calculates finalGPA
            if (Data.Count > 1)
            {
                // Divide Total by weightTotal
                finalGPA = Total / weightTotal;
                MessageBox.Show("Your CGPA is " + finalGPA.ToString("F"));
            }
        }
    }
}
