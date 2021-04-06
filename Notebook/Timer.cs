using System;
using System.Threading;

namespace Notebook
{
    class Timer
    {
        readonly ListMeets _listMeets;

        public delegate void TimerHandler(string message);

        public event TimerHandler Notify;
        public bool something;

        public Timer(ListMeets listMeets) 
        {
            _listMeets = listMeets;
        }

        public void CheckNotification()
        {
            do
            {
                foreach (var meet in _listMeets.Meets)
                {
                    if (DateTime.Now.Ticks == meet.DateNotification.Ticks)
                    {
                        Notify?.Invoke($"Скоро событие {meet.Name}");
                        Console.WriteLine("SHIT HAPPEND!");
                        something = true;
                    }
                }
            } while(!something);
        }
    }
}
