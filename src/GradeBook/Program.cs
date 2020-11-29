using System;
using System.Collections.Generic;
///
/// C# Fundamentals Plural Sigth Course 
///https://app.pluralsight.com/course-player?clipId=16f3ffc4-267e-4e59-999b-9dd8cecc94e7
///
/// Commands
/// PS C:\Users\yshav\gradebook> dotnet test
/// PS C:\Users\yshav\gradebook> dotnet --project src\GradeBook

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram:
            try
            {



                Console.WriteLine("Enter Book Name: ");
                var bookName = Console.ReadLine();
                IBook book = new DiskBook(bookName);
                book.GradeAdded += OnGradeAdded;
                book.GradeAdded -= OnGradeAdded;
                book.GradeAdded += OnGradeAdded;
                book.GradeAdded += OnGradeAdded;

                EnterGrades(book);

                var stats = book.GetStatistics();

                Console.WriteLine(InMemoryBook.x);
                Console.WriteLine($"For the Book named {book.Name}");
                Console.WriteLine($"The lowest grade is {stats.Low}");
                Console.WriteLine($"The highest grade is {stats.High}");
                Console.WriteLine($"The average grade is {stats.Average:N1}");
                Console.WriteLine($"The letter grade is {stats.Letter}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                goto StartProgram;
            }

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter grade or 'q' to exit :");
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // Demonstrating Overloding AddGrade Method
                    // book.AddGrade('a',1);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added :)");
        }
    }
}
