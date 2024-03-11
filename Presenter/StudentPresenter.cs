using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Presenter
{
    public class StudentPresenter
    {
        public IView _view;
        public IModel _model;

        /// <summary>
        /// Конструктор презентера
        /// </summary>
        /// <param name="view">Интерфейс программы</param>
        /// <param name="model">модель программы</param>
        public StudentPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.Load += Load;
            _view.OnStudentAddView += ViewStudentAdd;
            _view.OnStudentDeleteView += ViewDeleteStudent;
            _model.OnDataChanged += Refresh;
            _model.OnDataChanged += RefreshHystogramm;
        }
        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="sender">объект, сообщающий о событии</param>
        /// <param name="studentArgs">Контейнер, содержащий данные о событии</param>
        private void Refresh(object sender, StudentArgs studentArgs)
        {
            _view.Refresh(studentArgs);
        }
        /// <summary>
        /// Обновление гистограммы
        /// </summary>
        /// <param name="sender">объект, сообщающий о событии</param>
        /// <param name="studentArgs">Контейнер, содержащий данные о событии</param>
        private void RefreshHystogramm(object sender, StudentArgs studentArgs)
        {
            _view.RefreshHystogramm(studentArgs);
        }
        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <param name="sender">объект, сообщающий о событии</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Load(object sender, EventArgs e)
        {
            _model.GetStartData();
        }
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="sender">объект, сообщающий о событии</param>
        /// <param name="studentArgs">Контейнер, содержащий данные о событии</param>
        private void ViewStudentAdd(object sender, StudentArgs studentArgs)
        {
            _model.AddStudent(studentArgs);
        }
        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="sender">объект, сообщающий о событии</param>
        /// <param name="studentArgs">Контейнер, содержащий данные о событии</param>
        private void ViewDeleteStudent(object sender, StudentArgs studentArgs)
        {
            _model.Delete(studentArgs.Id);
        }
    }
}
