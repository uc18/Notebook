using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Notebook
{
    /// <summary>
    /// Класс, в котором идет вся основная работа со встречами
    /// </summary>
    class MeetService
    {
        CultureInfo cultureInfo = new CultureInfo("ru-Ru");
        ListMeets _listMeets;

        public MeetService(ListMeets listMeets) 
        {
            _listMeets = listMeets;
        }

        public void CreateNewMeet()
        {
            Console.WriteLine("Введите название встречи");
            string name = Console.ReadLine();

            Console.WriteLine("Введите дату встречи");
            var DateOrder = DateTime.Parse(Console.ReadLine(), cultureInfo);

            Console.WriteLine("Введите дату напоминания");
            var DateNotification = DateTime.Parse(Console.ReadLine(), cultureInfo);

            Meet meet = new Meet(name, DateOrder, DateNotification);

            Console.WriteLine(DateOrder);

            _listMeets.AddMeet(meet);
        }
           

        public void ChangeExistingMeet()
        {
            Console.WriteLine("изменение события");
        }

        public void DeleteExistingMeet()
        {
            Console.WriteLine("удаление события");
        }
    }
}
