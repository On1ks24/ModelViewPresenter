using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий для Dapper
    /// </summary>
    /// <typeparam name="T">Любой класс</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        /// <summary>
        /// Функция добавления объекта
        /// </summary>
        /// <param name="item">Добавляемый объект</param>
        public void Add(T item)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Students (Name,Speciality,[Group]) VALUES(@Name, @Speciality,@Group); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = connectionDB.Query<int>(sqlQuery, item).FirstOrDefault();
                item.Id = (int)userId;
            }
        }
        /// <summary>
        /// Функция удаления объекта
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        public void Delete(int id)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Students WHERE Id = @id";
                connectionDB.Execute(sqlQuery, new { id });
            }
        }
        /// <summary>
        /// Функция для возвращения списка всех объектов, представленных в БД
        /// </summary>
        /// <returns>Лист со всеми объектами</returns>
        public IEnumerable<T> GetAll()
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                return connectionDB.Query<T>("SELECT * FROM Students").ToList();
            }
        }
        /// <summary>
        /// Функция, возвращающая объект по id
        /// </summary>
        /// <param name="Id">Id требуемого объекта</param>
        /// <returns>Объект БД</returns>
        public T GetById(int Id)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                return connectionDB.Query<T>("SELECT * FROM Students WHERE Id = @Id", new { Id }).FirstOrDefault();
            }
        }
        /// <summary>
        /// Функция сохранения изменений
        /// </summary>
        public void Save() { }
    }
}
