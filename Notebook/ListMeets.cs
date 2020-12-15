using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    /// <summary>
    /// Класс, который описывает существующие встречи
    /// </summary>
    class ListMeets
    {
        public List<Meet> Meets { get; set; } = new List<Meet>();

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