using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Model;
using DataAccessLayer;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace BLogic
{
    /// <summary>
    /// Логика программы
    /// </summary>
    public class Logic : IModel
    {
        /// <summary>
        /// репозиторий
        /// </summary>
        public IRepository<Student> _students;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<StudentArgs> OnDataChanged = delegate{};
        /// <summary>
        /// Конструктор, присваивающий репозиторий
        /// </summary>
        /// <param name="students">репозиторий</param>
        public Logic(IRepository<Student> students)
        {
            _students = students;
        }
        /// <summary>
        /// Функция добавления студентов
        /// </summary>
        /// <param name="studentArgs"></param>
        public void AddStudent(StudentArgs studentArgs)
        {
            var newStudent = new Student()
            {
                Name = studentArgs.Name,
                Group = studentArgs.Group,
                Speciality = studentArgs.Speciality
            };
            _students.Add(newStudent);
            studentArgs.Id = newStudent.Id;
            OnDataChanged(this, new StudentArgs(GetAll(), DictionaryCountSpecialities()));
        }

        /// <summary>
        /// Функция удаления студента
        /// </summary>
        /// <param name="id">id студента</param>
        public void Delete(int id)
        {
            _students.Delete(id);
            OnDataChanged(this, new StudentArgs(GetAll(), DictionaryCountSpecialities()));
        }
        /// <summary>
        /// Изменение данных
        /// </summary>
        public void GetStartData()
        {
            OnDataChanged(this, new StudentArgs(GetAll(),DictionaryCountSpecialities()));
        }
        /// <summary>
        /// Лист с данными студентов
        /// </summary>
        /// <returns>Коллекция с данными студентов</returns>
        private List<Dictionary<string, string>> GetAll()
        {
            var students = _students.GetAll().Select(student => new Dictionary<string, string>()
            {
                {
                    "Id", student.Id.ToString()
                },
                {
                    "Name", student.Name
                },
                {
                    "Speciality", student.Speciality
                },
                {
                    "Group", student.Group
                }
            }).ToList();
            return students;
        }
        /// <summary>
        /// Словарь со всеми специальностями и количеством студентов,зачисленных на эту специальность.
        /// </summary>
        public Dictionary<string, int> DictionaryCountSpecialities()
        {
            List<string> special= new List<string>();
            foreach (Student s in _students.GetAll())
            {
                special.Add(s.Speciality);
            }
            Dictionary<string, int> result = special.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            return result;
        }
    }
}
