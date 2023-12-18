using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kurichev_Lab2
{
    enum Education
    {
        Specialist,
        Вachelor,
        SecondEducation,
    }
    class Student : Person, IDateAndCopy
    {
        private Education studentEducation;
        private int studentGroup;
        private ArrayList studentExams = new ArrayList();
        private ArrayList studentTests = new ArrayList();

        public Student(Person studentPerson, Education StudentEducation, int StudentGroup) : base(studentPerson.Name, studentPerson.Secondname, studentPerson.Date) // Конструктор
        {
            this.studentEducation = StudentEducation;
            this.studentGroup = StudentGroup;
        }

        public Student() // Конструктор без параметров
        {
            studentEducation = Education.Specialist;
            studentGroup = 09063;
        }

        // Геттеры-сеттеры для всех переменных внутри класса Student

        public Person StudentPerson
        {
            get
            {
                return (new Person(name, secondname, date));
            }
            set
            {
                name = value.Name;
                secondname = value.Secondname;
                date = value.Date;
            }
        }

        public Education StudentEducation
        {
            get { return this.studentEducation; }
            set { this.studentEducation = value; }
        }

        public int StudentGroup
        {
            get { return this.studentGroup; }
            set
            {
                if (value > 100 && value <= 599  )
                    this.studentGroup = value;
                else
                    throw new Exception("Value out of range");
            }
        }

        public ArrayList StudentExams
        {
            get { return this.studentExams; }
            set { this.studentExams = value; }
        }

        public ArrayList StudentTests
        {
            get { return this.studentTests; }
            set { this.studentTests = value; }
        }

        public double Avgexam // Средний балл
        {
            get
            {
                int examcount = 0;
                double examratings = 0.0;

                foreach (Exam ex in studentExams) // Проходимся по всему списку
                {
                    examcount++;
                    examratings += ex.rating;
                }

                if (examcount == 0) return 0;
                else return (examratings / examcount);

            }
        }
        public bool this[Education index] // индекастор
        {
            get
            {
                if (this.studentEducation == index)
                    return true;
                else
                    return false;
            }
        }

        public void AddExams(params Exam[] a) // добавляем экзамен
        {
            studentExams.AddRange(a);
        }

        public void AddTests(params Test[] a) // добавляем экзамен
        {
            studentTests.AddRange(a);
        }

        public override string ToString() // Полный вывод
        {
            string tempoutput = ("Student person info: " + base.ToString() + "\n"
                    + "Education: " + studentEducation + "\n" + "Group number: " + studentGroup
                    + "\n" + "Average exam rate: " + Avgexam + "\n");

            foreach (var ex in studentExams)
            {
                tempoutput += ex.ToString();
            }
            tempoutput += "\n";
            foreach (var tests in studentTests)
            {
                tempoutput += tests.ToString();
            }

            return tempoutput;
        }

        public override string ToShortString() // Краткий вывод
        {
            return ("Student person info: " + "\n" + base.ToString() + "\n"
                    + "Education: " + studentEducation + "\n" + "Group number: " + studentGroup
                    + "\n" + "Average exam rate: " + Avgexam + "\n");
        }

        public override object DeepCopy() // Копирование
        {
            Student tstudent = new Student(new Person(base.name, base.secondname, base.date), studentEducation, studentGroup);

            foreach (Exam currentExam in studentExams)
            {
                Exam t = (Exam)currentExam.DeepCopy();
                tstudent.studentExams.Add(t);
            }

            foreach (Test currentTest in studentTests)
            {
                Test t = (Test)currentTest.DeepCopy();
                tstudent.studentTests.Add(t);
            }

            return (tstudent);
        }

        public IEnumerable IterateExamsAndTests() // Итератор по экзаменам и тестам
        {
            foreach (object currentExam in studentExams)
                yield return currentExam;
            foreach (object currentTest in studentTests)
                yield return currentTest;
        }

        public IEnumerable IterateExamsAndTestsWithRate(int reqsRating) // Итератор по экзаменом с проверкой оценки
        {
            foreach (Exam currentExam in studentExams)
                if (currentExam.rating > reqsRating)
                    yield return currentExam;
        }

    }
}
