using System;
using System.Collections.Generic;
using System.Text;

namespace Kurichev_Lab2
{

    class Exam : IDateAndCopy
    {
        public string examname;
        public int rating;
        public System.DateTime Date { get; set; }

        public Exam(string Examname, int Rating, DateTime ExamDate) // Конструктор
        {
            this.examname = Examname;
            this.rating = Rating;
            this.Date = ExamDate;
        }

        public Exam() : this("TempNameExam", 5, new DateTime(2222, 2, 2)) // Конструктор без параметров
        {
            ;
        }

        

        public override string ToString() // Полный вывод
        {
            return ("\n" + "Exam of " + examname + " info:" + "\n" + "Rate: " + rating + "\n" + "Exam date: " + Date.ToString());
        }

        public object DeepCopy()
        {
            Exam texam = new Exam(examname, rating, Date);
            return (texam);
        }
}
}
