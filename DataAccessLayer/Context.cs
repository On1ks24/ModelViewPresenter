using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        public Context() : base("DbConnection") { }
        /// <summary>
        /// Коллекция студентов
        /// </summary>
        public DbSet<Student> Students { get; set; }
    }
}
