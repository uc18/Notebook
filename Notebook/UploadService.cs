using System;
using System.IO;
using System.Collections.Generic;

namespace Notebook
{
    /// <summary>
    /// Класс, в котором описывается выгрузка встреч
    /// </summary>
    class UploadService
    {
        public UploadService(){}

        /// <summary>
        /// Выгрузка встреч за определенный день
        /// </summary>
        public void UploadOnFile(List<Meet> meets)
        {
            try
            {
                using StreamWriter file = File.AppendText(".\\data.txt");
                {
                    foreach (var meet in meets)
                    {
                        file.WriteLine(meet);
                    }
                    file.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}, произошла непредвиденная ошибка");
            }
        }

    }
}
