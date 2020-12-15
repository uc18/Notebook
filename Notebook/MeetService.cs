using System;
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
            Console.WriteLine("Введите название события");
            string name = Console.ReadLine();

            Console.WriteLine("Введите дату начала события в формате дд ММММ ГГГГ ЧЧ:ММ");
            var dateStartEvent = DateTime.Parse(Console.ReadLine(), cultureInfo);

            Console.WriteLine("Введите дату окончания события в формате дд ММММ ГГГГ ЧЧ:ММ");
            var dateEndEvent = DateTime.Parse(Console.ReadLine(), cultureInfo);

            Console.WriteLine("Введите дату напоминания дд ММММ ГГГГ ЧЧ:ММ");
            var dateNotification = DateTime.Parse(Console.ReadLine(), cultureInfo);

            if (GetValidationMessage(dateStartEvent, dateEndEvent, dateNotification, out string validationMessage))
            {
                Console.WriteLine(validationMessage);
                Console.ReadLine();
            }
            else
            {
                Meet meet = new Meet(name, dateStartEvent, dateEndEvent, dateNotification);
                _listMeets.AddMeet(meet);
            }

        }

        public void GetAllMeets()
        {
            foreach (var meet in _listMeets.Meets)
            {
                Console.WriteLine(meet);
            }
            Console.WriteLine("Нажмите любую клавишу для выхода из просмотра.");
            Console.ReadLine();
        }

        public void ChangeExistingMeet()
        {
            foreach (var meet in _listMeets.Meets)
            {
                Console.WriteLine(meet);
            }
            Console.WriteLine("Введите название встречи для изменения");
            string nameDelMeet = Console.ReadLine();

            var a = _listMeets.Meets.Find(o => o.Name == nameDelMeet);

            Console.WriteLine(a);
            Console.ReadLine();

        }

        public void DeleteExistingMeet()
        {
            Console.WriteLine("Удаление события");
        }

        private bool GetValidationMessage(DateTime dateStart, DateTime dateEnd, DateTime dateNotification, out string validationMessage)
        {
            validationMessage = "";

            var today = DateTime.Today;

            if (dateStart < today || dateEnd < today || dateNotification < today)
            {
                validationMessage = "Дата события и нотификации не может быть в прошлом";
                return true;
            }

            foreach (var meet in _listMeets.Meets)
            {
                //TO DO продумать варианты
                if (meet.DateStart >= dateStart && meet.DateEnd <= dateEnd)
                {
                    validationMessage = "События не могут пересекаться";
                    return true;
                }
            }
            return false;
        }
    }
}