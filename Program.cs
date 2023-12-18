using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kurichev_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person t1 = new Person(); // 1 задание
            Person t2 = new Person();

            Console.WriteLine("Сравнение ссылок: " + ReferenceEquals(t1, t2));

            Console.WriteLine("\n");

            Console.WriteLine("Хеш 1: " + t1.GetHashCode());
            Console.WriteLine("Хеш 2: " + t2.GetHashCode());

            DateTime session1 = new DateTime(2021, 4, 25);
            DateTime session2 = new DateTime(2020, 2, 12);

            Exam examMathanaliz = new Exam("mathanaliz", 3, session2);
            Exam examDevelopment = new Exam("development", 4, session1);
            Exam examLinal = new Exam("linal", 2, session1);
            Test testEnglish = new Test("english", true, session2);
            Test testMathanaliz = new Test("mathanaliz", false, session1);

            Student t3 = new Student(new Person ("Student3", "Student3LastName", session2), Education.SecondEducation, 555);

            t3.AddExams(examMathanaliz, examDevelopment, examLinal); // 2 задание
            t3.AddTests(testMathanaliz, testEnglish);

            Person t4 = t3.StudentPerson; // 3 задание
            Console.WriteLine(t4.ToString());

            var t5 = t3.DeepCopy();
            Exam exam4 = new Exam("CopyCheckExam", 5, session2); 
            t3.AddExams(exam4); // 4 задание

            Console.WriteLine("\n");
            Console.WriteLine("Changed version: " + t3.ToString());
            Console.WriteLine("\n");
            Console.WriteLine("Original version: " + t5.ToString());

            Console.WriteLine("\n");
            try // 5 задание
            {
                t3.StudentGroup = 11119063;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");

            Console.WriteLine("\n");
            foreach (var going in t3.IterateExamsAndTests()) // 6 задание
            {
                if (going.GetType() == examMathanaliz.GetType())
                    Console.Write("Exam: " + ((Exam)going).examname + " ");
                else
                    Console.Write("Test: " + ((Test)going).TestName + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("\n");
            foreach (Exam going in t3.IterateExamsAndTestsWithRate(3)) // 7 задание
            {
                Console.Write("Exam: " + going.examname);
            }
            Console.WriteLine("\n");

        }
    }
}
