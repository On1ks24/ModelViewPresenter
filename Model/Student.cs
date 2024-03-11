using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student:IDomainObject
    {
        /// <summary>
        /// Id студента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Специальность студента
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// Группа студента
        /// </summary>
        public string Group { get; set; }
    }
}
