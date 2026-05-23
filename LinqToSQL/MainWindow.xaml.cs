using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LinqToDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();


            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.LinqDBConnectionString"].ConnectionString;

            dataContext = new LinqToDataClassesDataContext(connectionString);


            // 1. Clear everything in the correct order (Children first)
            dataContext.ExecuteCommand("DELETE FROM StudentLecture");
            dataContext.ExecuteCommand("DELETE FROM Student");
            dataContext.ExecuteCommand("DELETE FROM Lecture");
            dataContext.ExecuteCommand("DELETE FROM University");
           

            InsertUniversities();
            InsertStudents();
            InsertLectures();
            InsertStudentLectureAssociations();
            GetUniversityOfTony();
            GetTonysLecture();
            GetAllStudentsFromYale();
            GetAllUniversitiesWithFemales();
            GetYaleLectures();
            UpdateTony();
            DeletePam();

        }


        public void InsertUniversities()
        {

            dataContext.ExecuteCommand("DELETE FROM University");


            // We add this class by dragging university in linq to data classes dbml
            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University harvard = new University();
            harvard.Name = "Harvard";
            dataContext.Universities.InsertOnSubmit(harvard);


            // submit changes
            dataContext.SubmitChanges();

            //MainDataGrid.ItemsSource = dataContext.Universities;
        }


        public void InsertStudents()

        {

            try
            {
                // 1. Clear Students FIRST if you need to clear the database
                dataContext.Students.DeleteAllOnSubmit(dataContext.Students);
                dataContext.SubmitChanges();

                // 2. Ensure your Universities exist before searching for them
                var yale = dataContext.Universities.FirstOrDefault(un => un.Name == "Yale");
                var harvard = dataContext.Universities.FirstOrDefault(un => un.Name == "Harvard");

                if (yale == null || harvard == null)
                {
                    throw new Exception("Universities not found in database.");
                }

                // 3. Create the list
                List<Student> newStudents = new List<Student>
        {
            new Student { Name = "Tony", Gender = "Male", University = yale },
            new Student { Name = "Leon", Gender = "Male", University = harvard },
            new Student { Name = "Ralf", Gender = "Male", University = yale },
            new Student { Name = "Pam", Gender = "Female", University = harvard }
        };

                dataContext.Students.InsertAllOnSubmit(newStudents);
                dataContext.SubmitChanges();

                // 4. Update the UI
                //MainDataGrid.ItemsSource = dataContext.Students;
            }
            catch (Exception ex)
            {
                // Use a MessageBox or Debugger to see why it's failing
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
        }



        public void InsertLectures()
        {
            try
            {
                var dataStucture = new Lecture();

                List<Lecture> lectures = new List<Lecture> 
                {
                    new Lecture { Name = "Data Structure" },
                    new Lecture { Name = "Data Science" },
                    
                };

                dataContext.Lectures.InsertAllOnSubmit(lectures);
                dataContext.SubmitChanges();

                

                //MainDataGrid.ItemsSource = dataContext.Lectures;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: ", ex.Message);
            }
        }



        public void InsertStudentLectureAssociations()
        {
            try
            {
                Student tonny = dataContext.Students.FirstOrDefault(stu => stu.Name == "Tony");
                Student leon = dataContext.Students.FirstOrDefault(stu => stu.Name == "Leon");
                Student ralf = dataContext.Students.FirstOrDefault(stu => stu.Name == "Ralf");
                Student pam = dataContext.Students.FirstOrDefault(stu => stu.Name == "Pam");


                Lecture DSA = dataContext.Lectures.FirstOrDefault(lec => lec.Name == "Data Structure");
                Lecture DSI = dataContext.Lectures.FirstOrDefault(lec => lec.Name == "Data Science");

                dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = tonny, Lecture = DSA });
                dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = leon, Lecture = DSA });
                dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = pam, Lecture = DSI });


                // Other way
                StudentLecture slToney = new StudentLecture();
                slToney.Student = tonny;
                slToney.Lecture = DSI;
                dataContext.StudentLectures.InsertOnSubmit(slToney);

                dataContext.SubmitChanges();

                //MainDataGrid.ItemsSource = dataContext.StudentLectures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }



        public void GetUniversityOfTony()
        {
            Student tony = dataContext.Students.First(st => st.Name.Equals("Tony"));

            University tonysUni = tony.University;

            List<University> universities = new List<University> { tonysUni };


            //MainDataGrid.ItemsSource = tonysUni; this wont work because items source needs an IEnumarable

            //MainDataGrid.ItemsSource = universities;
        }

        public void GetTonysLecture()
        {
            Student tony = dataContext.Students.First(st => st.Name.Equals("Tony"));

            var tonysLectures = from sl in tony.StudentLectures select sl.Lecture;


            //MainDataGrid.ItemsSource = tonysLectures;

        }


        public void GetAllStudentsFromYale()
        {
            var studentsFromYale = from student in dataContext.Students
                                   where student.University.Name == "Yale"
                                   select student;


            //MainDataGrid.ItemsSource = studentsFromYale;

        }


        public void GetAllUniversitiesWithFemales()
        {
            //var unisWithFemales = from student in dataContext.Students
            //                      where student.Gender == "Female"
            //                      select student.University;

            var unisWithFemales = from student in dataContext.Students
                                  join university in dataContext.Universities
                                  on student.University equals university
                                  where student.Gender == "Female"
                                  select university;



            //MainDataGrid.ItemsSource = unisWithFemales;
        }


        public void GetYaleLectures()
        {
            var yaleLectures = from sl in dataContext.StudentLectures
                               join student in dataContext.Students on sl.StudentId equals student.Id
                               where student.University.Name == "Yale"
                               select sl.Lecture;


            //MainDataGrid.ItemsSource = yaleLectures;

        }


        public void UpdateTony()
        {
            Student tony = dataContext.Students.FirstOrDefault(st => st.Name.Equals("Tony"));

            tony.Name = "Antony";

            dataContext.SubmitChanges();


            //MainDataGrid.ItemsSource = dataContext.Students;


        }

        public void DeletePam()
        {
            Student pam = dataContext.Students.FirstOrDefault(ST => ST.Name == "Pam");

            dataContext.Students.DeleteOnSubmit(pam);

            dataContext.SubmitChanges();


            MainDataGrid.ItemsSource = dataContext.Students;
        }

    }
}
