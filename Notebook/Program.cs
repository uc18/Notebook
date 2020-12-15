using System;

namespace Notebook
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Notebook";

            string a;
            ListMeets listMeets = new ListMeets();
            MeetService meetService = new MeetService(listMeets);
            do
            {
                Console.Clear();
                Console.WriteLine("Выберете действие: \n" +
                               "1: Создать новое событие \n" +
                               "2: Изменить созданное событие \n" +
                               "3: Просмотреть все события \n" +
                               "4: Удалить созданное событие \n" +
                               "5: Выход из программы");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.Clear();
                        meetService.CreateNewMeet();
                        break;
                    case "2":
                        Console.Clear();
                        meetService.ChangeExistingMeet();
                        break;
                    case "3":
                        Console.Clear();
                        meetService.GetAllMeets();
                        break;
                    case "4":
                        Console.Clear();
                        meetService.DeleteExistingMeet();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                }
            } while (a != "5");
            
        }

    }
}