using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class InMemoryBook : Book 
    {
        public InMemoryBook(string name) : base(name)
        {
            // setting category readonly veriable
            category = "software";
            grades = new List<double>();
            this.Name = name;
        }
        
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0 )
            {
                grades.Add(grade);
                if(GradeAdded !=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        // Overloding Methos
        public string AddGrade(char letter, int x)
        {
            
            return "";
        }
        
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            
            // foreach(var number in grades) 
            // {
            //     result.High = Math.Max(number, result.High);
            //     result.Low = Math.Min(number, result.Low);
            //     result.Average += number;
            // }

            // var index = 0;
            // while(index < grades.Count)
            // {
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Average += grades[index]; 
            //     index++;
            // };
            
            // for(var index = 0; index < grades.Count; index++)
            // {
            //     // if(grades[index] == 42.1)
            //     // {   
            //     //     // breaking out from the loop if 42.1 apperrs
            //     //     break;
            //     // }
                
            //     // if(grades[index] == 90.5)
            //     // {
            //     //     // skipping the code for this iterration  -->> mening that 90.5 will nNOT enter to the calculation
            //     //     continue;
            //     // }

            //     // double luckyNum = 60.3;
            //     // if (grades[index] == luckyNum)
            //     // {
            //     //     // jump to Lable
            //     //     goto LuckyNumberCode;
            //     // }

            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     // //Lable
            //     // LuckyNumberCode:
            //     result.Average += grades[index]; 
            // }
               for(var index = 0; index < grades.Count; index++)
            {

                result.Add(grades[index]);
            }

            return result;
        }

        private List<double> grades;
        // const field  - this filed can't be chenged
        public const int x = 3;
        
        // Read-only Defenithion 
        //readonly can be set just in the Book constractor 
        readonly string category = "Science";

        // // Defining Properties quickly as read only
        // public string Name
        // {
        //     get; 
        //     // just methods from Book.cs cen set Name propertie
        //     //private set;
        //     set;
        // }

        // Defining Properties
        // public string Name
        // {
        //     get
        //     {
        //         //code that execute whan reading Name propertie
        //         Console.WriteLine($"Name get function");
        //         return name;
        //     }
        //     set
        //     {
        //         //code that execute whan setting Name propertie
        //         // value is a spacial variable that holde the data that the Name sets
        //         Console.WriteLine($"Name set function value = {value}");
        //         if(!String.IsNullOrEmpty(value))
        //         {
        //             Console.WriteLine($"value leanth {value.Length}");
        //             name = value + "'s Grade Book";
        //         }
        //         else
        //         {
        //             Console.WriteLine($"value leanth {value.Length}");
        //             throw new ArgumentNullException($"Null ot Empty String");
        //         }
        //     }
        // }
        // private string name;
    }
}