using System;
using System.Globalization;

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

            Console.Write("Введите название события: ");
            string name = Console.ReadLine();

            DateTime dateStartEvent = ParseDateTime("Введите дату начала события в формате дд ММММ ГГГГ ЧЧ:ММ");
            DateTime dateNotification = ParseDateTime("Введите дату напоминания в формате дд ММММ ГГГГ ЧЧ:ММ");
            DateTime dateEndEvent = ParseDateDouble("Введите длительность события в минутах: ", dateStartEvent);
            
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
            if ( _listMeets.Meets.Count > 0)
            {
                foreach (var meet in _listMeets.Meets)
                {
                    Console.WriteLine(meet);
                }
                Console.WriteLine("Нажмите ENTER для выхода из просмотра.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Событий нет. Нажмите ENTER для выхода.");
                Console.ReadLine();
            }
        }

        public void ChangeExistingMeet()
        {
            string changeOptions;
            if (_listMeets.Meets.Count > 0)
            {
                foreach (var meet in _listMeets.Meets)
                {
                    Console.WriteLine(meet);
                }
                Console.Write("Выберете встречу, введя её название: ");

                string nameMeet = Console.ReadLine();

                var existMeet = _listMeets.Meets.Find(o => o.Name == nameMeet);
                do
                {
                    Console.WriteLine("Введите раздел для изменений: \n" +
                                       "1 - Название \n" +
                                       "2 - Дата начала \n" +
                                       "3 - Дата уведомления \n" +
                                       "4 - Выход из раздела");
                    changeOptions = Console.ReadLine();
                    switch (changeOptions)
                    {
                        case "1":
                            Console.Write("Введите новое название встречи:");
                            string name = Console.ReadLine();
                            existMeet.Name = name;
                            break;

                        case "2":
                            DateTime dateStartEvent = ParseDateTime("Введите новое время начала встречи в формате дд ММММ ГГГГ ЧЧ:ММ");
                            existMeet.DateStart = dateStartEvent;
                            DateTime dateEndEvent = ParseDateDouble("Введите новую длительность события в минутах", dateStartEvent);
                            existMeet.DateEnd = dateEndEvent;
                            break;

                        case "3":
                            DateTime dateNotification = ParseDateTime("Введите новую дату напоминания дд ММММ ГГГГ ЧЧ:ММ");
                            existMeet.DateNotification = dateNotification;
                            break;

                        case "4":
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Введен неизвестный символ, для продолжения нажмите Enter");
                            Console.ReadLine();
                            break;
                    }
                } while (changeOptions != "4");

            }
            else
            {
                Console.WriteLine("События не созданы. Нажмите ENTER для выхода.");
                Console.ReadLine();
            }

        }

        public void DeleteExistingMeet()
        {
            if (_listMeets.Meets.Count > 0)
            {
                Console.WriteLine("Удаление события");
            }
            else
            {
                Console.WriteLine("События не созданы. Нажмите ENTER для выхода.");
                Console.ReadLine();
            }
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

        private DateTime ParseDateTime(string message)
        {
            CultureInfo cultureInfo = new CultureInfo("ru-Ru");
            DateTimeStyles styles = DateTimeStyles.None;
            bool success;
            DateTime date;
            do{
                    Console.WriteLine(message);
                    success = DateTime.TryParse(Console.ReadLine(), cultureInfo, styles, out date);

            } while (success != true);
            return date;
        }

        private DateTime ParseDateDouble(string message, DateTime dateStart)
        {
            bool success;
            DateTime date;
            do
            {
                Console.Write(message);
                success = Double.TryParse(Console.ReadLine(), out double Mins);
                date = dateStart.AddMinutes(Mins);

            } while (success != true);

            return date;
        }
    }
}