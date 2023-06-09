﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace CS_AcademyGroup
{
    [Serializable]
        public class Academy_Group 
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
                    Console.WriteLine("\nПожалуйста введите данные студента : ");
                    Console.Write("\nИмя :\t\t");
                    System.String name = Console.ReadLine();

                    Console.Write("\nФамилия :\t");
                    System.String surname = Console.ReadLine();

                    Console.Write("\nВозраст :\t");
                    System.UInt16 age = System.UInt16.Parse(Console.ReadLine());

                    Console.Write("\nНомер телефона :");
                    System.String phone = Console.ReadLine();

                    Console.Write("\nСредний балл :\t");
                    System.Double average = System.Double.Parse(Console.ReadLine());

                    Console.Write("\nНомер группы :\t");
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
                    Console.WriteLine("\nПожалуйста введите данные студента для удаления : ");
                    Console.WriteLine("\nФамилия :");
                    System.String surname = Console.ReadLine();
                    int index = -1;
                    for (int i = 0; i < ag.Count; i++)
                    {
                        if ((ag[i] as Student).Surname == surname)
                            index = i;
                    }
                    if (index == -1)
                        throw new Exception("Студент c данной фамилией отсутствует в списке");
                    else
                        ag.RemoveAt(index);
                    Console.WriteLine("Студент {0} удален из списка", surname);
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
                    Console.WriteLine("\nПожалуйста введите данные студента для редактирования : ");
                    Console.WriteLine("\nФамилия :");
                    System.String _surname = Console.ReadLine();
                    bool flag = false;

                    for (int i = 0; i < ag.Count; i++)
                    {
                        if ((ag[i] as Student).Surname == _surname)
                        {
                            flag = true;

                            (ag[i] as Student).Print();

                            Console.WriteLine("Какие данные студента Вы хотели бы изменить?\nНажмите любую кнопку для продолжения...");
                            Console.ReadKey();

                            string[] items =
                            {
                            "Имя",
                            "Фамилию",
                            "Возраст",
                            "Номер телефона",
                            "Средний балл",
                            "Номер группы",
                            "Выход"
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

                                            Console.WriteLine("Введите новое имя студента : ");
                                            System.String name = Console.ReadLine();
                                            (ag[i] as Student).Name = name;
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("Введите новую фамилию студента : ");
                                            System.String surname = Console.ReadLine();
                                            (ag[i] as Student).Surname = surname;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Введите новый возраст студента : ");
                                            System.UInt16 age = System.UInt16.Parse(Console.ReadLine());
                                            (ag[i] as Student).Age = age;
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Введите новый номер телефона студента : ");
                                            System.String phone = Console.ReadLine();
                                            (ag[i] as Student).Phone = phone;
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Введите новый средний балл студента : ");
                                            System.Double average = System.Double.Parse(Console.ReadLine());
                                            (ag[i] as Student).Average = average;
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("Введите новый номер группы студента : ");
                                            System.String number_Of_Group = Console.ReadLine();
                                            (ag[i] as Student).Number_Of_Group = number_Of_Group;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                    (ag[i] as Student).Print();
                                Console.WriteLine("Данные о студенте были успешно изменены");

                            } while (menuResult != items.Length - 1);
                        }
                    }

                    if (!flag)
                        throw new Exception("Студент с такой фамилией отсутствует в списке!");
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
                    Console.WriteLine("\n\t\t\t\t\tСписок Академической группы :\n\nИмя: \t\tФамилия: \tВозраст: \tНомер телефона: \tСредний балл: \tНомер группы: ");

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

                        Console.WriteLine("Сериализация успешно выполнена!");
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
