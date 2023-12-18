using System;
using System.Collections.Generic;
using System.Text;

namespace Kurichev_Lab2
{
    interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }

    class Person : IDateAndCopy
    {
            protected string name;
            protected string secondname;
            protected DateTime date;

            public Person(string Name, string Secondname, DateTime Birthdate) // Конструктор
            {
                this.name = Name;
                this.secondname = Secondname;
                this.date = Birthdate;
            }

            public Person() : this("temp1", "temp2", new DateTime(1111, 1, 1)) // Конструктор без параметров
            {
                
            }

            // Геттеры-сеттеры для всех переменных внутри класса
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Secondname
            {
                get { return secondname; }
                set { secondname = value; }
            }
            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }


            public override string ToString() // Полный вывод
            {
                return ("\n" + "Full Person info" + "\n" + name + " (Person name)" + "\n" + secondname + " (Person secondname)" + "\n" + date.ToString() + " (Person birthdate)");
            }

            public virtual string ToShortString() // Краткий вывод
            {
                return ("\n" + "Short Person info" + "\n" + name + " (Person name)" + "\n" + secondname + " (Second name)");
            }

            public override bool Equals(object obj)
            {
                Person tperson = (Person)obj; // конвертирует в person для сравнения
                return (tperson.Name == this.Name && tperson.secondname == this.secondname && tperson.date == this.date);
            }

            public static bool operator ==(Person a, Person b)
            {
                return(a.Equals(b));
            }

            public static bool operator !=(Person a, Person b)
            {
                return(!(a == b));
            }

            public virtual object DeepCopy() // Копирование
            {
                Person tperson = new Person(name, secondname, date);
                return (tperson);
            }

        public override int GetHashCode()
            {
                //return (date.GetHashCode() + Name.GetHashCode() + secondname.GetHashCode());
                return (HashCode.Combine(date, name, secondname));
            }

    }
}
