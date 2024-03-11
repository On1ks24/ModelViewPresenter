using DataAccessLayer;
using Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogic
{
    /// <summary>
    /// Класс для инверсии зависимостей
    /// </summary>
    public class SimpleConfigModule:NinjectModule
    {
        /// <summary>
        /// Метод для выбора репозитория
        /// </summary>
        public override void Load()
        {
            //Bind<IRepository<Student>>().To<EntityRepository<Student>>().InSingletonScope();
            Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
        }
    }
}
