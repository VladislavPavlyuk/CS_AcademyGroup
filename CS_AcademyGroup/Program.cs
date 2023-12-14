using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace CS_AcademyGroup
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization.Formatters.Binary;


    namespace CS_AcademyGroup
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Academy_Group obj = new Academy_Group();

                string[] items =
                    {
                "Add student", //0
                "Delete student", //1
                "Change student data", //2
                "Print", //3 
                "Save", //4
                "Load", //5
                "Find student", //6
                "Exit"
            };

                ConsoleMenu menu = new ConsoleMenu(items);
                int menuResult;
                do
                {
                    Console.WriteLine("Academy group");

                    menuResult = menu.PrintMenu();

                    switch (menuResult)
                    {
                        case 0:
                            Add(obj); //Добавить студента в группу
                            break;
                        case 1:
                            Del(obj); //Удалить студента из группы
                            break;
                        case 2:
                            Edit(obj); //Изменить данные студента
                            break;
                        case 3:
                            Print(obj); //Распечатать группу
                            break;
                        case 4:
                            Save(obj); //Сохранить в Binary
                            break;
                        case 5:
                            Load(obj); //Загрузить из файла
                            break;
                        case 6:
                            Search(obj); //Поиск студента
                            break;
                        case 8:
                            Exit(); //выход
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                } while (menuResult != items.Length - 1);

                Console.Clear();

            }
            static void Add(Academy_Group obj)          // Добавить студента в группу
            {
                try
                {
                    obj.Add();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Del(Academy_Group obj)          // Удаление студента из группы                                 
            {
                try
                {
                    obj.Remove();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Edit(Academy_Group obj)         // редактирование сведений о студенте
            {
                try
                {
                    obj.Edit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Print(Academy_Group obj)        // Печать группы
            {
                try
                {
                    obj.Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Save(Academy_Group obj)        // сохранение в файл
            {
                try
                {
                    obj.SaveBinary();

                    Console.WriteLine("Press any key to continue");

                    Console.ReadKey();

                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Load(Academy_Group obj)     // загрузка группы из файла
            {
                try
                {
                    obj.LoadBinary();

                    Console.WriteLine("Press any key to continue");

                    Console.ReadKey();

                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Search(Academy_Group obj)       // поиск студента
            {
                try
                {
                    obj.Search();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void Exit()
            {
                Console.WriteLine("Good bye!");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Academy_Group obj = new Academy_Group();

            string[] items =
                {
                "Добавить студента в группу", //0
                "Удалить студента из группы", //1
                "Изменить данные студента", //2
                "Распечатать группу", //3 
                "Сохранить в файл", //4
                "Загрузить из файла", //5
                "Поиск студента", //6
                "Выход"
            };

            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                Console.WriteLine("Академическая группа");

                menuResult = menu.PrintMenu();

                switch (menuResult)
                {
                    case 0:
                        Add(obj); //Добавить студента в группу
                        break;
                    case 1:
                        Del(obj); //Удалить студента из группы
                        break;
                    case 2:
                        Edit(obj); //Изменить данные студента
                        break;
                    case 3:
                        Print(obj); //Распечатать группу
                        break;
                    case 4:
                        Save(obj); //Сохранить в Binary
                        break;
                    case 5:
                        Load(obj); //Загрузить из файла
                        break;
                    case 6:
                        Search(obj); //Поиск студента
                        break;
                    case 8:
                        Exit(); //выход
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);

            Console.Clear();

        }
        static void Add(Academy_Group obj)          // Добавить студента в группу
        {
            try
            {
                obj.Add();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Del(Academy_Group obj)          // Удаление студента из группы                                 
        {
            try
            {
                obj.Remove();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Edit(Academy_Group obj)         // редактирование сведений о студенте
        {
            try
            {
                obj.Edit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Print(Academy_Group obj)        // Печать группы
        {
            try
            {
                obj.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Save(Academy_Group obj)        // сохранение в файл
        {
            try
            {
                obj.SaveBinary();

                Console.WriteLine("Для продолжения нажмите любую клавишу");

                Console.ReadKey();

                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Load(Academy_Group obj)     // загрузка группы из файла
        {
            try
            {
                obj.LoadBinary();

                Console.WriteLine("Для продолжения нажмите любую клавишу");

                Console.ReadKey();                

                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }
        }
        static void Search(Academy_Group obj)       // поиск студента
        {
            try
            {
                obj.Search();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }
}
