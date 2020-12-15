using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    /// <summary>
    /// Класс, который описывает встречи
    /// </summary>
    class Meet
    {
        /// <summary>
        /// Название встречи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата начала встречи
        /// </summary>
        public DateTime DateStart { get; set; } 

        /// <summary>
        /// Дата конца встречи
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Дата уведомления о встрече
        /// </summary>
        public DateTime DateNotification { get; set; }

        public Meet(string name, DateTime dateStart, DateTime dateEnd, DateTime dateNotification)
        {
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            DateNotification = dateNotification;
        }

        public override string ToString()
        {
            return $"Событие {Name}; дата: {DateStart}: {DateEnd}; уведомить: {DateNotification}";
        }

    }
}