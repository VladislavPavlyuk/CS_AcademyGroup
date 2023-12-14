using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_AcademyGroup;

namespace CS_AcademyGroup
{
    [Serializable]
    public class Student : Person
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
            : this(null, null, 0, null, 0, null){}

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
    }
}
