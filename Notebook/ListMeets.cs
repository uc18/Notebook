using System;
using System.Collections.Generic;

namespace Notebook
{
    /// <summary>
    /// Класс, который описывает список существующих встреч
    /// </summary>
    class ListMeets
    {
        public List<Meet> Meets { get; set; } = new List<Meet>
        { 
            new Meet() { 
                Name = "Another meet",
                DateStart = new DateTime(2021,04,05,12,00,00),
                DateEnd = new DateTime(2021,04,05,12,15,00),
                DateNotification = new DateTime(2021,04,04,08,00,00)
            },
            new Meet() {
                Name = "MatchDay",
                DateStart = new DateTime(2021,04,04,20,00,00),
                DateEnd = new DateTime(2021,04,04,22,00,00),
                DateNotification = new DateTime(2021,04,04,01,22,30)
            },
        };

        public ListMeets() {}

        public void AddMeet(Meet meet)
        {
            Meets.Add(meet);
        }

        public void DelMeet(Meet meet)
        {
            Meets.Remove(meet);
        }
    }
}