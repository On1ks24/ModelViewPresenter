using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий для Dapper
    /// </summary>
    /// <typeparam name="T">Любой класс</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Подключение к БД
        /// </summary>
        private Context context = new Context();
        /// <summary>
        /// Функция сохранения изменений
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
        /// <summary>
        /// Функция добавления объекта
        /// </summary>
        /// <param name="item">Добавляемый объект</param>
        public void Add(T item)
        {
            context.Set<T>().Add(item);
            Save();
        }
        /// <summary>
        /// Функция удаления объекта
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        public void Delete(int Id)
        {
            var i = context.Set<T>().Find(Id);
            context.Set<T>().Remove(i);
            Save();
        }
        /// <summary>
        /// Функция для возвращения списка всех объектов, представленных в БД
        /// </summary>
        /// <returns>Лист со всеми объектами</returns>
        public IEnumerable<T> GetAll()
        {
            return new ObservableCollection<T>(context.Set<T>().ToList());
        }
        /// <summary>
        /// Функция, возвращающая объект по id
        /// </summary>
        /// <param name="Id">Id требуемого объекта</param>
        /// <returns>Объект БД</returns>
        public T GetById(int Id)
        {
            var s = context.Set<T>().FirstOrDefault(x => x.Id == Id);
            return s;
        }
    }
}
