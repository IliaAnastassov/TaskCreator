using System;
using System.IO;

namespace TaskCreator.Application
{
    public class Program
    {
        const char HASH = '#';
        const string INFO_PREFIX = "info_";
        const string HRG_PREFIX = "HRG_";
        const string EMS_PREFIX = "EMS_";
        const string EXTENSION_TXT = ".txt";
        const string EXTENSION_SQL = ".sql";

        public static void Main()
        {
            try
            {
                var taskId = Console.ReadLine();
                var currentDirPath = Directory.GetCurrentDirectory();
                var taskDirPath = Path.Combine(currentDirPath, $"{HASH}{taskId} -");

                if (!Directory.Exists(taskDirPath))
                {
                    Directory.CreateDirectory(taskDirPath);

                    CreateFile(INFO_PREFIX, taskId, taskDirPath, EXTENSION_TXT);
                    CreateFile(HRG_PREFIX, taskId, taskDirPath, EXTENSION_SQL);
                    CreateFile(EMS_PREFIX, taskId, taskDirPath, EXTENSION_SQL);
                }
                else
                {
                    Console.WriteLine($"A directory for task {HASH}{taskId} already exists!");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private static void CreateFile(string prefix, string taskId, string taskDirPath, string extension)
        {
            var fileName = $"{prefix}{taskId}{extension}";
            var filePath = Path.Combine(taskDirPath, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }
}
