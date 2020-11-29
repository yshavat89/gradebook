using System;
using System.IO;
namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        private string path;
        public DiskBook(string name) : base(name)
        {
            if(!File.Exists(name+".txt"))
            {
                using(File.Create(name + ".txt"))
                {

                }
            }
            this.path = name + ".txt";

        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var f = File.AppendText(this.path))
            {
                f.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}