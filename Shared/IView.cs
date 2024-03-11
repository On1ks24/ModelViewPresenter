using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IView
    {
        /// <summary>
        /// Загрузка данных
        /// </summary>
        event EventHandler Load;
        /// <summary>
        /// Добавление студента на форме
        /// </summary>
        event EventHandler<StudentArgs> OnStudentAddView;
        /// <summary>
        /// Удаление студента на форме
        /// </summary>
        event EventHandler<StudentArgs> OnStudentDeleteView;
        /// <summary>
        /// Обновление таблицы
        /// </summary>
        /// <param name="args">Контейнер, содержащий данные о студентах</param>
        void Refresh(StudentArgs args);
        /// <summary>
        /// Обновление гистограммы
        /// </summary>
        /// <param name="args">Контейнер, содержащий данные о студентах</param>
        void RefreshHystogramm(StudentArgs args);
    }
}
