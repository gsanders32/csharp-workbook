using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    class Program
    {
        static bool add = true;
        static Dictionary<string, string> students = new Dictionary<string, string>(); // create student dictionary
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Gradebook!");           
            AddStudent(); //call method 
        }

        static void AddStudent()
        {
            do
            {
                Console.WriteLine("Enter the students name or type quit to stop and see results");
                string userStudentName = Console.ReadLine().Trim();
                if (userStudentName.ToLower() != "quit" && userStudentName.ToLower() != "q") // check for quit
                {
                    while (true)
                    {
                        Console.WriteLine($"Please Enter {userStudentName} Grades separated by spaces");
                        string userGrades = Console.ReadLine().Trim();
                        try //check if grades are numbers
                        {
                            string[] testGrade = userGrades.Split(" ");
                            foreach (string item in testGrade)
                            {
                                decimal test = Convert.ToDecimal(item);
                            }
                            students.Add(userStudentName, userGrades);//add student and grades
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You entered a grade that was not a number");    
                        }
                    }
                }
                else
                {
                    add = false;
                    if(students.Count > 0) // check if user entered anything
                    {
                        Display();//call method display
                    }
                    else
                    {
                        Console.WriteLine("You did not enter anything - Goodbye!");
                    }
                }
            } while (add); //break when false
        }

        static void Display()
        {      
            foreach(KeyValuePair<string, string> student in students)
            {
                decimal minGrade = 200, maxGrade = 0, sum = 0;
                string studentName = student.Key; //set current student name
                string[] studentGrade = student.Value.Split(" ");  //set current student grades as an array
                decimal[] decGrades = studentGrade.Select(decimal.Parse).ToArray(); //convert string array to dec array
                foreach(decimal grade in decGrades) // loop through grades
                {
                    sum += grade; //add up all grades
                    if (grade < minGrade) // find min grade
                    {
                        minGrade = grade;
                    }else if(grade > maxGrade) // find max grade
                    {
                        maxGrade = grade;
                    }
                }
                decimal avg = sum / decGrades.Length; //get grade avg
                
                Console.WriteLine($"Student: {studentName}\nLowest Grade: {minGrade}\nHighest Grade: {maxGrade}\nAverage Grade: {avg}\n");
                Console.WriteLine("Press enter to see the next Record");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("That was the last one - Goodbye!");
            Console.ReadKey();
        }
    }
}
