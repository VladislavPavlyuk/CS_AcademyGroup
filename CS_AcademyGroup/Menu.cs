﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AcademyGroup
{
    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Сделайте выбор :\n");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                        Console.WriteLine(menuItems[i]);
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}

