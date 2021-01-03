using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Notebook
{
    class MeetMainWorker
    {
        MeetService _meetService;
        UploadService _uploadService;
        public MeetMainWorker(MeetService meetService, UploadService uploadService) 
        {
            _meetService = meetService;
            _uploadService = uploadService;

        }

        public void CreateNewMeet()
        {
            Console.Write("Введите уникальное название события: ");
            string name = Console.ReadLine();

            DateTime dateStartEvent = ParseDateTime("Введите дату начала события в формате дд ММММ ГГГГ ЧЧ:ММ");
            DateTime dateNotification = ParseDateTime("Введите дату напоминания в формате дд ММММ ГГГГ ЧЧ");
            DateTime dateEndEvent = ParseDateDouble("Введите длительность события в минутах: ", dateStartEvent);

            _meetService.CreateNewMeet(name, dateStartEvent, dateEndEvent, dateNotification);
        }

        public void GetAllMeet()
        {
            bool data = _meetService.GetAllMeets(out List<Meet> meets);
            if (data)
            {
                foreach(var meet in meets)
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

        public void ChangeExistsMeet()
        {
            int i = 0;
            int index;
            string changeOptions;
            List<Meet> meets;
            bool data = _meetService.GetAllMeets(out meets);
            if (data)
            {
                foreach (var meet in meets)
                {
                    i++;
                    Console.WriteLine($"ID:{i}; {meet}");
                }

                bool success;
                do
                {
                    Console.Write("Выберете встречу, введя её индекс: ");
                    success = int.TryParse(Console.ReadLine(), out index);
                } while (success != true);

                var existMeet = meets[index - 1];

                do
                {
                    Console.WriteLine("Введите раздел для изменений: \n" +
                                       "1 - Название \n" +
                                       "2 - Дата уведомления \n" +
                                       "3 - Выход из раздела");
                    changeOptions = Console.ReadLine();
                    switch(changeOptions)
                    {
                        case "1":
                            Console.Write("Введите новое уникальное название события: ");
                            string name = Console.ReadLine();
                            existMeet.Name = name;
                            break;
                        case "2":
                            DateTime dateNotification = ParseDateTime("Введите новую дату напоминания в формате дд ММММ ГГГГ ЧЧ:ММ");
                            existMeet.DateNotification = dateNotification;
                            break;
                        case "3":
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Введен неизвестный символ, для продолжения нажмите Enter");
                            Console.ReadLine();
                            break;
                    }
                } while (changeOptions != "3");

            }
            else
            {
                Console.WriteLine("Событий нет. Нажмите ENTER для выхода.");
                Console.ReadLine();
            }
        }

        public void DeleteExistMeet()
        {
            int i = 0;
            int index;

            List<Meet> meets;
            bool data = _meetService.GetAllMeets(out meets);

            if (data)
            {
                foreach (var meet in meets)
                {
                    i++;
                    Console.WriteLine($"ID:{i}; {meet}");
                }

                bool success;
                do
                {
                    Console.Write("Выберете встречу, введя её индекс: ");
                    success = int.TryParse(Console.ReadLine(), out index);
                } while (success != true);

                var existMeet = meets[index - 1];

                _meetService.DeleteExistingMeet(existMeet);

                Console.WriteLine("Событие удалено");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("События не созданы. Нажмите ENTER для выхода.");
                Console.ReadLine();
            }

        }

        public void SaveOnFile()
        {
            DateTime dateStart = ParseDateTime("Введите дату начала события в формате дд ММММ ГГГГ ЧЧ:ММ");
            DateTime dateEnd = ParseDateTime("Введите дату конца события в формате дд ММММ ГГГГ ЧЧ:ММ");
            List<Meet> meets;
            if (_meetService.GetIntervalMeets(dateStart,dateEnd,out meets))
            {
                _uploadService.UploadOnFile(meets);
            }
        }

        /// <summary>
        /// Внутренний метод для преобразования даты
        /// </summary>
        /// <param name="message">Уведомляющее сообщение</param>
        /// <returns>Преобразованная дата</returns>
        private DateTime ParseDateTime(string message)
        {
            CultureInfo cultureInfo = new CultureInfo("ru-Ru");
            DateTimeStyles styles = DateTimeStyles.None;
            bool success;
            DateTime date;
            do
            {
                Console.WriteLine(message);
                success = DateTime.TryParse(Console.ReadLine(), cultureInfo, styles, out date);

            } while (success != true);
            return date;
        }

        /// <summary>
        /// Внутренний метод для преобразования даты окончания события
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dateStart"></param>
        /// <returns>Преобразованная дата</returns>
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
