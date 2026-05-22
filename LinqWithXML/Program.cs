using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXML
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // XML: stands for extendable markup language - it is a langugage to structure Data
            // We simply apply our Student-Structure to XML
            // Many websites use XML to share data | APIs which use XML
            string studentXML =
                @"<Students>
                  <Student>
                     <Name>Toni</Name>
                     <Age>21</Age>
                     <University>Yale</University>
                     <GPA>4</GPA>
                  </Student>

                  <Student>
                     <Name>Carla</Name>
                     <Age>17</Age>
                     <University>Yale</University>
                     <GPA>3.2</GPA>
                  </Student>

                  <Student>
                     <Name>Leyla</Name>
                     <Age>19</Age>
                     <University>MIT</University>
                     <GPA>3.1</GPA>
                  </Student>

                  <Student>
                     <Name>Jim</Name>
                     <Age>25</Age>
                     <University>Harvard</University>
                     <GPA>3.0</GPA>
                  </Student>

                  </Students>";


            // Patse studentXML String so we can use it with Linq
            XDocument studentsXDoc = new XDocument();
            studentsXDoc = XDocument.Parse(studentXML);


            var students = from student in studentsXDoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               GPA = student.Element("GPA").Value
                           };

            foreach (var student in students) 
            {
                Console.WriteLine($"Student {student.Name}, with age: {student.Age} and from university {student.University} and with GPA {student.GPA}");
            }

            Console.WriteLine("-----------------------\n\n");

            //var sortedStudentsByAge = from student in studentsXDoc.Descendants("Student")
            //                          orderby (int)student.Element("Age")
            //                          select new
            //                          {
            //                              Name = student.Element("Name").Value,
            //                              Age = student.Element("Age").Value,
            //                              University = student.Element("University").Value
            //                          };

            var sortedStudentsByAge = from student in students
                                      orderby student.Age
                                      select student;

            foreach (var student in sortedStudentsByAge)
            {
                Console.WriteLine($"Student {student.Name}, with age: {student.Age} and from university {student.University} and with GPA {student.GPA}");
            }




        }
    }
}
