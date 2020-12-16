using System;

namespace Notebook
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Notebook";

            string options;
            ListMeets listMeets = new ListMeets();
            MeetService meetService = new MeetService(listMeets);
            UploadService uploadWorker = new UploadService();
            MeetMainWorker worker = new MeetMainWorker(meetService,uploadWorker);
            
            do
            {
                Console.Clear();
                Console.WriteLine("Выберете действие и нажмите Enter: \n" +
                               "1: Создать новое событие \n" +
                               "2: Изменить созданное событие \n" +
                               "3: Просмотреть все события \n" +
                               "4: Удалить созданное событие \n" +
                               "5: Выгрузить календарь \n" +
                               "6: Выход из программы");
                options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        Console.Clear();
                        worker.CreateNewMeet();
                        break;
                    case "2":
                        Console.Clear();
                        worker.ChangeExistsMeet();
                        break;
                    case "3":
                        Console.Clear();
                        worker.GetAllMeet();
                        break;
                    case "4":
                        Console.Clear();
                        worker.DeleteExistMeet();
                        break;
                    case "5":
                        Console.WriteLine("Выгрузка");
                        worker.SaveOnFile();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введен неизвестный символ, для продолжения нажмите Enter");
                        Console.ReadLine();
                        break;
                }
            } while (options != "6");
            
        }

    }
}