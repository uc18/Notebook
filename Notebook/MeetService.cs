using System;
using System.Globalization;
using System.Collections.Generic;

namespace Notebook
{
    /// <summary>
    /// Класс, в котором идет вся основная работа с событиями
    /// </summary>
    class MeetService
    {
        ListMeets _listMeets;

        public MeetService(ListMeets listMeets) 
        {
            _listMeets = listMeets;
        }

        /// <summary>
        /// Метод для создания событий
        /// </summary>
        public void CreateNewMeet(string name, DateTime dateStart, DateTime dateEnd, DateTime dateNotification)
        {
           
            if (GetValidationMessage(dateStart, dateEnd, dateNotification, out string validationMessage))
            {
                Console.WriteLine(validationMessage);
                Console.ReadLine();
            }
            else
            {
                Meet meet = new Meet(name, dateStart, dateEnd, dateNotification);
                _listMeets.AddMeet(meet);
            }

        }

        /// <summary>
        /// Метод возвращающий все события
        /// </summary>
        public bool GetAllMeets(out List<Meet> meets)
        {
            meets = new List<Meet>();
            if ( _listMeets.Meets.Count > 0)
            {
                foreach (var meet in _listMeets.Meets)
                {
                    meets.Add(meet);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает встречи за выбранный промежуток времени
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="meets"></param>
        /// <returns></returns>
        public bool GetIntervalMeets(DateTime start,DateTime end, out List<Meet> meets)
        {
            meets = new List<Meet>();
            if (_listMeets.Meets.Count > 0)
            {
                foreach (var meet in _listMeets.Meets)
                {
                    if(start <= meet.DateStart && end >= meet.DateEnd)
                    {
                        meets.Add(meet);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для удаления события
        /// </summary>
        public void DeleteExistingMeet(Meet meet)
        {
            _listMeets.DelMeet(meet);
        }

        #region
        /// <summary>
        /// Внутренний метод для проверки временных промежутков дат
        /// </summary>
        /// <param name="dateStart">Дата начала события</param>
        /// <param name="dateEnd">Дата окончания события</param>
        /// <param name="dateNotification">Дата уведомления</param>
        /// <param name="validationMessage">Возвращаемое сообщение</param>
        /// <returns>Булевый флаг</returns>
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
                if ((meet.DateStart >= dateStart && meet.DateStart <= dateEnd) ||
                    (meet.DateEnd > dateStart && meet.DateEnd <= dateEnd) ||
                    (dateStart >= meet.DateStart && dateStart < meet.DateEnd) ||
                    (dateEnd > meet.DateStart && dateEnd <= meet.DateEnd))
                {
                    validationMessage = "События не могут пересекаться";
                    return true;
                }
            }


            return false;
        }

        #endregion
    }
}