using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс, представляющий все необходимые функции репозитория
    /// </summary>
    /// <typeparam name="T">Любой класс</typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Функция добавления объекта
        /// </summary>
        /// <param name="item">Добавляемый объект</param>
        void Add(T item);
        /// <summary>
        /// Функция удаления объекта
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        void Delete(int Id);
        /// <summary>
        /// Функция для возвращения списка всех объектов, представленных в БД
        /// </summary>
        /// <returns>Лист со всеми объектами</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Функция, возвращающая объект по id
        /// </summary>
        /// <param name="Id">Id требуемого объекта</param>
        /// <returns>Объект БД</returns>
        T GetById(int Id);
        /// <summary>
        /// Функция сохранения изменений
        /// </summary>
        void Save();
    }
}
