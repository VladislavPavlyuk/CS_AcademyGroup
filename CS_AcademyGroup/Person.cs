using System;

namespace CS_AcademyGroup
{
    [Serializable]
    public class Person : Object
    {
        public String name, surname, phone;
        public UInt16 age;

        public String Name
        {
            get => name;

            set => name = value;
        }

        public String Surname
        {
            get => surname;

            set => surname = value;
        }
        public UInt16 Age
        {
            get => age;

            set => age = value;
        }
        public String Phone
        {
            get => phone;

            set => phone = value;
        }
        //  Конструктор по умолчанию
        public Person() :
            this(null, null, 0, null)
        { }

        //  Конструктор с параметрами
        public Person(String name,
                        String surname,
                        UInt16 age,
                        String phone)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.phone = phone;
        }

        public void Print()
        {
            Console.Write("{0}\t\t{1}\t\t{2}\t\t{3}", name, surname, age, phone);
        }
    }
}

