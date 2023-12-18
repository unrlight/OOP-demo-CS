using System;
using System.Collections.Generic;
using System.Text;

namespace Kurichev_Lab2
{
    class Test : IDateAndCopy
    {
        public string TestName;
        public bool Pass;
        public System.DateTime Date { get; set; }


        public Test(string testname, bool pass, DateTime date) // Конструктор
        {
            TestName = testname;
            Pass = pass;
            Date = date;
        }

        public Test()// Конструктор без параметров
        {
            TestName = "prog";
            Pass = true;
            Date = new DateTime(4444, 2, 2);
        }

        public override string ToString() // Полный вывод
        {
            return ("Test of " + TestName + " : " + Pass + "\n");
        }

        public object DeepCopy()
        {
            Test ttest = new Test(TestName, Pass, Date);
            return (ttest);
        }
    }
}
