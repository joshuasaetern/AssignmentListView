using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentListView
{
    //Joshua Saetern
    //06.03.2024
    //Computer Programming II
    //Assignment - ListView (and all other skills)

    public partial class MainWindow : Window
    {
        //List to hold Students
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            //Create 5 Students
            students.Add(new Student("Joshua Saetern", 85.00, 99.00));
            students.Add(new Student("Leo Ragual", 95.00, 100.00));
            students.Add(new Student("Paydon Jee", 70.00, 100.00));
            students.Add(new Student("Leo Ingram", 77.00, 66.00));
            students.Add(new Student("Michael Stampton", 70.00, 15.00));

            //Set ListView source
            listViewStudents.ItemsSource = students;
        }
        
        public Boolean AddStudent()
        {
            //Creating User inputted grades
            double userGrade1 = 0;
            double userGrade2 = 0;

            //Checks if boxes are filled
            if (String.IsNullOrWhiteSpace(txtBoxStudentName.Text))
            {
                MessageBox.Show("Please enter a Student Name");
                return false;   
            }
            if (String.IsNullOrWhiteSpace(txtBoxGrade1.Text))
            {
                MessageBox.Show("Please enter a value for Grade 1");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtBoxGrade2.Text))
            {
                MessageBox.Show("Please enter a value for Grade 2");
                return false;
            }
            //Checks if Grade 1 and Grade 2 are numbers
            //Grade 1
            try
            {
                userGrade1 = double.Parse(txtBoxGrade1.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid number for Grade 1");
                return false;
            }
            //Grade 2
            try
            {
                userGrade2 = double.Parse(txtBoxGrade2.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid number for Grade 2");
                return false;
            }
            students.Add(new Student(txtBoxStudentName.Text, userGrade1, userGrade2));
            MessageBox.Show("Student Added");
            return true;
        }
        public Boolean DeleteStudent()
        {
            //Checks if there is an Item currently selected
            if (listViewStudents.SelectedIndex == -1)
            { 
                MessageBox.Show("No Student is selected");
                return false;
            }
            //Gets the students name before being removed
            String removeStudent = students[listViewStudents.SelectedIndex].Name;

            //Removes student
            students.RemoveAt(listViewStudents.SelectedIndex);

            //Shows user which student was removed
            MessageBox.Show("Removed " + removeStudent);
            return true;
        }
        public Boolean EditStudent()
        {
            //Checks if there is an Item currently selected
            if (listViewStudents.SelectedIndex == -1)
            {
                MessageBox.Show("No Student is selected");
                return false;
            }

            //Values to hold userInput
            double userGrade1 = -1;
            double userGrade2 = -1;

            //Value to hold old grade
            double oldGrade1 = students[listViewStudents.SelectedIndex].Grade1;
            double oldGrade2 = students[listViewStudents.SelectedIndex].Grade2;

            if (!String.IsNullOrWhiteSpace(txtBoxNewGrade1.Text))
            {
                try
                {
                    //Parse Grade 1
                    userGrade1 = double.Parse(txtBoxNewGrade1.Text);
                    //Changes current selected student Grade 1 to new value
                    students[listViewStudents.SelectedIndex].Grade1 = userGrade1;
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number for Grade 1");
                }
            }
            if (!String.IsNullOrWhiteSpace(txtBoxNewGrade2.Text))
            {
                try
                {
                    //Parse Grade 2
                    userGrade2 = double.Parse(txtBoxNewGrade2.Text);
                    //Changes current selected student Grade 2 to new value
                    students[listViewStudents.SelectedIndex].Grade2 = userGrade2;
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number for Grade 2");
                }
            }

            //Values for new grades so we can compare
            double newGrade1 = students[listViewStudents.SelectedIndex].Grade1;
            double newGrade2 = students[listViewStudents.SelectedIndex].Grade2;

            //Find out if any values were changed
            if (newGrade1 == oldGrade1 && newGrade2 == oldGrade2) 
            {
                MessageBox.Show("No Grades were changed");
                return false;
            } 
            //Find which Message Box to show
            if (newGrade1 != oldGrade1 && newGrade2 != oldGrade2)
            {
                MessageBox.Show("Changed Grade 1 and Grade 2");
            }
            else if (newGrade1 != oldGrade1)
            {
                MessageBox.Show("Changed Grade 1");
            }
            else
            {
                MessageBox.Show("Changed Grade 2");
            }
            return true;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent();
            listViewStudents.Items.Refresh();
        }

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            EditStudent();
            listViewStudents.Items.Refresh();
        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent();
            listViewStudents.Items.Refresh();
        }
    }
}