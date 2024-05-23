using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch.Engine
{
    internal class Engine
    {
        public static string GetDirectory()
        {
            while (true)
            {
                Console.WriteLine("Введите директорию в которой хотите найти файл ");
                string userDirectory = Console.ReadLine();
                if (Directory.Exists(userDirectory))
                    return userDirectory;
                else
                    Console.WriteLine("Неправильная директория");
            }
            
        }

        public static string GetFileName()
        {
            Console.WriteLine("Введите название файла");
            string userFileName = Console.ReadLine();
            return userFileName;
        }

        public static void Start()
        {
            string directory = GetDirectory();
            string fileName = GetFileName();


            string[] dirs = Directory.GetDirectories(directory);

            string[] files = Directory.GetFiles(directory);

            foreach (var item in dirs)
            {
                Console.WriteLine(item);
            }

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }


        }

    }
}
