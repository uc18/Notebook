using System;

namespace Notebook
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Notebook";

            Console.WriteLine("Выберете действие: \n" +
                               "1: Создать новое событие \n" +
                               "2: Изменить созданное событие \n" +
                               "3: Удалить созданное событие");
            string a;
            ListMeets listMeets = new ListMeets();
            MeetService meetService = new MeetService(listMeets);
            do
            {
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        meetService.CreateNewMeet();
                        break;
                    case "2":
                        meetService.ChangeExistingMeet();
                        break;
                    case "3":
                        meetService.DeleteExistingMeet();
                        break;
                    default:
                        Console.WriteLine("Неизвестное значение");
                        Console.WriteLine("Выйти?");
                        a = Console.ReadLine();
                        break;
                }
            } while (a != "4");
            
        }

    }
}
