using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IModel
    {
        /// <summary>
        /// Изменение данных
        /// </summary>
        event EventHandler<StudentArgs> OnDataChanged;
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="studentArgs"></param>
        void AddStudent(StudentArgs studentArgs);
        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Получение начальных данных
        /// </summary>
        void GetStartData();
    }
}
