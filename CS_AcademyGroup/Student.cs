using System;
using System.Collections.Generic;

namespace CS_AcademyGroup
{
    public class Student : Person, IComparable<Student>
    {
        public Double average;

        public String number_Of_Group;
        public Double Average
        {
            get => average;

            set => average = value;
        }
        public String Number_Of_Group
        {
            get => number_Of_Group;

            set => number_Of_Group = value;
        }
        //  Конструктор по умолчанию
        public Student()
            : this(null, null, 0, null, 0, null) { }

        //  Конструктор с параметрами
        public Student(String name,
                        String surname,
                        UInt16 age,
                        String phone,
                        Double average,
                        String number_Of_Group)
            : base(name, surname, age, phone)
        {
            this.average = average;
            this.number_Of_Group = number_Of_Group;
        }
        new public void Print()
        {
            base.Print();
            Console.WriteLine("\t\t\t{0} \t\t{1}", average, number_Of_Group);
        }
        public int CompareTo(Student obj)
        {
            return name.CompareTo((obj as Student).name);
        }

        public class SortBySurname : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).surname.CompareTo((obj2 as Student).surname);

                throw new NotImplementedException();
            }
        }
        public class SortByAge : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).age.CompareTo((obj2 as Student).age);

                throw new NotImplementedException();
            }
        }
        public class SortByAverage : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).average.CompareTo((obj2 as Student).average);

                throw new NotImplementedException();
            }
        }

        public class SortByGroup : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).number_Of_Group.CompareTo((obj2 as Student).number_Of_Group);

                throw new NotImplementedException();
            }
        }
    }
}
