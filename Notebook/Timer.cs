using System;

namespace Notebook
{
    class Timer
    {
        public DateTime TimeCheck { get; set; }

        ListMeets _listMeets;

        public delegate void TimerHandler(string message);

        public event TimerHandler Notify;

        public Timer(ListMeets listMeets, DateTime timeCheck) 
        {
            _listMeets = listMeets;
            TimeCheck = timeCheck;
        }

        public void CheckNotification ()
        {
            DateTime date = DateTime.Now;

            foreach (var meet in _listMeets.Meets)
            {
                if (date == meet.DateNotification)
                {
                    Notify?.Invoke($"Скоро событие {meet.Name}");
                    TimeCheck = TimeCheck.AddHours(1);
                }
            }

        }
    }
}
