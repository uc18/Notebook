using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    /// <summary>
    /// Класс, в котором идет вся основная работа со встречами
    /// </summary>
    class MeetService
    {
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
            Console.WriteLine("Введите дату напоминания");

            Meet meet = new Meet(name,DateTime.Today, DateTime.Today);

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
