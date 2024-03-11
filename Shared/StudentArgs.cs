using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class StudentArgs : EventArgs
    {
        /// <summary>
        /// Айди
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string Speciality { get; }
        /// <summary>
        /// Группа
        /// </summary>
        public string Group { get; }
        public List<Dictionary<string, string>> Students { get; }
        /// <summary>
        /// Аргументы студента для добавления
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="group">Группа</param>
        public StudentArgs(string name, string speciality, string group)
        {
            Name = name;
            Speciality = speciality;
            Group = group;
        }
        public Dictionary<string, int> DictionaryCountSpecialities { get; }
        /// <summary>
        /// Аргументы студента для обновления
        /// </summary>
        /// <param name="students"></param>
        public StudentArgs(List<Dictionary<string, string>> students, Dictionary<string, int> dictionaryCountSpecialities) 
        {
            DictionaryCountSpecialities = dictionaryCountSpecialities;
            Students = students; 
        }
        /// <summary>
        /// Аргументы студента для удаления
        /// </summary>
        /// <param name="id">айди студента</param>
        public StudentArgs(int id)
        {
            Id = id;
        }
    }
}
