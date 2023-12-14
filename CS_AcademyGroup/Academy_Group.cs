using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;


namespace CS_AcademyGroup
{
    [Serializable]
    public class Academy_Group : ICloneable, IEnumerable, IEnumerator
    {
        ArrayList ag;

            int position = -1;

            FileStream stream = null;

            BinaryFormatter formatter = null;

            object[] temp = null;

            public Academy_Group()          // конструктор по умолчанию
            {
                ag = new ArrayList();
            }

        public void Add()
        {
            try
            {
                Console.WriteLine("\nPlease enter students data : ");

                Console.Write("\nName :\t\t");
                System.String name = Console.ReadLine();

                Console.Write("\nSurname :\t");
                System.String surname = Console.ReadLine();

                Console.Write("\nAge :\t");
                System.UInt16 age = System.UInt16.Parse(Console.ReadLine());

                Console.Write("\nPhone number :");
                System.String phone = Console.ReadLine();

                Console.Write("\nAverage rate :\t");
                System.Double average = System.Double.Parse(Console.ReadLine());

                Console.Write("\nGroup number :\t");
                System.String number_Of_Group = Console.ReadLine();

                Student st = new Student(name, surname, age, phone, average, number_Of_Group);
                ag.Add(st);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        public void Remove()
        {
            try
            {
                Console.WriteLine("\nPlease enter student surname to delete : ");

                System.String surname = Console.ReadLine();
                int index = -1;
                for (int i = 0; i < ag.Count; i++)
                {
                    if ((ag[i] as Student).Surname == surname)
                        index = i;
                }
                if (index == -1)
                    throw new Exception("Student with such name and surname is not exist in the list");
                else
                    ag.RemoveAt(index);
                Console.WriteLine("Student {0} deleted from the list", surname);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        public void Edit()
        {
            try
            {
                Console.WriteLine("\nPlease enter students name to edit : ");
                Console.WriteLine("\nSurname :");
                System.String _surname = Console.ReadLine();
                bool flag = false;

                for (int i = 0; i < ag.Count; i++)
                {
                    if ((ag[i] as Student).Surname == _surname)
                    {
                        flag = true;

                        (ag[i] as Student).Print();

                        Console.WriteLine("What students data you want to edit?\nPress any key to continue...");
                        Console.ReadKey();

                        string[] items =
                        {
                            "Name",
                            "Surname",
                            "Age",
                            "Phone number",
                            "Average rate",
                            "Groupe number",
                            "Exit"
                        };

                        ConsoleMenu menu = new ConsoleMenu(items);
                        int menuResult;
                        do
                        {
                            menuResult = menu.PrintMenu();

                            //Console.Clear();
                            switch (menuResult)
                            {
                                case 0:
                                    {

                                        Console.WriteLine("Enter students new name : ");
                                        System.String name = Console.ReadLine();
                                        (ag[i] as Student).Name = name;
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("Enter students new surname : ");
                                        System.String surname = Console.ReadLine();
                                        (ag[i] as Student).Surname = surname;
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Enter students new age : ");
                                        System.UInt16 age = System.UInt16.Parse(Console.ReadLine());
                                        (ag[i] as Student).Age = age;
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("Enter students new phone number : ");
                                        System.String phone = Console.ReadLine();
                                        (ag[i] as Student).Phone = phone;
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.WriteLine("Enter students new average rate : ");
                                        System.Double average = System.Double.Parse(Console.ReadLine());
                                        (ag[i] as Student).Average = average;
                                        break;
                                    }
                                case 5:
                                    {
                                        Console.WriteLine("Enter students new group number : ");
                                        System.String number_Of_Group = Console.ReadLine();
                                        (ag[i] as Student).Number_Of_Group = number_Of_Group;
                                        break;
                                    }
                                default:
                                    break;
                            }
                                (ag[i] as Student).Print();
                            Console.WriteLine("Students data was changed successfully");

                        } while (menuResult != items.Length - 1);
                    }
                }

                if (!flag)
                    throw new Exception("Student with such surname doesn't exist!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        public void Print()
        {
            try
            {
                Console.WriteLine("\n\t\t\t\t\tAcademy group list\n\nName: \t\tSurname: \tAge: \tPhone number: \tAverage rate: \tGroup number: ");

                foreach (Student temp in ag)
                {
                    temp.Print();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        public void SaveBinary()
        {
            try
            {
                const string fileName = "AcademyGroup.bin";

                using (stream = new FileStream(fileName, FileMode.Create))
                {
                    formatter = new BinaryFormatter();
                    formatter.Serialize(stream, ag);
                    stream.Close();

                    Console.WriteLine("Serialization is done successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        public void LoadBinary()
            {
                try
                {
                    const string fileName = "AcademyGroup.bin";

                    if (File.Exists(fileName))
                    {
                        using (stream = new FileStream(fileName, FileMode.Open))
                        {
                            formatter = new BinaryFormatter();
                            ag = (ArrayList)formatter.Deserialize(stream);
                            stream.Close();
                            Console.WriteLine("Десериализация успешно выполнена!");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
            }
 
            public void Search()
            {
                try
                {
                    Console.WriteLine("\nПожалуйста введите данные студента для поиска : ");
                    Console.WriteLine("\nФамилия :");
                    System.String _surname = Console.ReadLine();
                    bool flag = false;
                    for (int i = 0; i < ag.Count; i++)
                    {
                        if ((ag[i] as Student).Surname == _surname)
                        {
                            flag = true;

                            (ag[i] as Student).Print();
                        }
                    }
                    if (!flag)
                        throw new Exception("В списке отсутствует студент с такой фамилией!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
            }
    }
}
