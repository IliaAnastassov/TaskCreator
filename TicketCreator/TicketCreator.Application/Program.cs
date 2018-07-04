using System;
using System.IO;

namespace TicketCreator.Application
{
    public class Program
    {
        const char HASH = '#';
        const string INFO_PREFIX = "info_";
        const string QUERIES_PREFIX = "queries_";
        const string EXTENSION_TXT = ".txt";
        const string EXTENSION_SQL = ".sql";

        public static void Main()
        {
            try
            {
                var ticketId = Console.ReadLine();
                var currentDirPath = Directory.GetCurrentDirectory();
                var ticketDirPath = Path.Combine(currentDirPath, $"{HASH}{ticketId} -");

                if (!Directory.Exists(ticketDirPath))
                {
                    Directory.CreateDirectory(ticketDirPath);

                    CreateFile(INFO_PREFIX, ticketId, ticketDirPath, EXTENSION_TXT);
                    CreateFile(QUERIES_PREFIX, ticketId, ticketDirPath, EXTENSION_SQL);
                }
                else
                {
                    Console.WriteLine($"A directory for ticket {HASH}{ticketId} already exists!");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private static void CreateFile(string prefix, string ticketId, string ticketDirPath, string extension)
        {
            var infoFileName = $"{prefix}{ticketId}{extension}";
            var infoFilePath = Path.Combine(ticketDirPath, infoFileName);

            if (!File.Exists(infoFilePath))
            {
                File.Create(infoFilePath);
            }
        }
    }
}
