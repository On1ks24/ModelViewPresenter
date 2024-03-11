using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Интерфейс, представляющий ключевое поле
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Айди
        /// </summary>
        int Id { get; set; }
    }
}
