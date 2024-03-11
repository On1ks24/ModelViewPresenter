using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLogic;
using Ninject;
using Presenter;
using Shared;
using ZedGraph;
using static System.Int32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba5
{
    /// <summary>
    /// Основная форма взаимодействия с программой
    /// </summary>
    public partial class Form1 : Form,IView
    {
        public Logic logic;
        public event EventHandler OnAppStart = delegate
        {
        };
        public event EventHandler<StudentArgs> OnStudentAddView = delegate
        {
        };
        public event EventHandler<StudentArgs> OnStudentDeleteView = delegate
        {
        };

        private StudentPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<Logic>();
            _presenter = new StudentPresenter(this, logic);
            OnAppStart(this, EventArgs.Empty);
        }
        public void CheckNull(Form2 form2)
        {
            if(!string.IsNullOrWhiteSpace(form2.textBox1.Text) && !string.IsNullOrWhiteSpace(form2.textBox2.Text) && !string.IsNullOrWhiteSpace(form2.textBox3.Text))
            {
                OnStudentAddView(this, new StudentArgs(form2.textBox1.Text, form2.textBox2.Text, form2.textBox3.Text));
            }
            else
            {
                MessageBox.Show("Невозможно добавить студента с пустыми свойствами");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selected = listView1.SelectedItems[0];
            OnStudentDeleteView(this, new StudentArgs(Parse(selected.Text)));
        }
        public void Refresh(StudentArgs args)
        {
            listView1.Items.Clear();
            listView1.Refresh();
            var students = args.Students;
            foreach (var student in students)
            {
                var item = new ListViewItem(student["Id"]);
                item.SubItems.Add(student["Name"]);
                item.SubItems.Add(student["Speciality"]);
                item.SubItems.Add(student["Group"]);
                listView1.Items.Add(item);
            }
        }
        public void RefreshHystogramm(StudentArgs args)
        {
            GraphPane pane = zg1.GraphPane; // Получим панель для рисования
            pane.CurveList.Clear(); // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.YAxis.Title.Text = "Количество студентов"; //Подписываем ось Oy
            pane.XAxis.Title.Text = "Специальность"; //Подписываем ось Ox
            List<string> names = new List<string>(); // Подписи под столбцами
            List<double> values = new List<double>(); // Высота столбцов
            // Заполним данные
            var specialities = args.DictionaryCountSpecialities;
            foreach (var person in specialities)
            {
                string s = person.Key;
                names.Add(s);
                values.Add(person.Value);
            }
            double[] doubles = new double[values.Count];
            string[] strings = new string[names.Count];
            //копируем листы с данными в массивы, потому что так требует ZedGraph
            for (int i = 0; i < values.Count; i++)
            {
                doubles[i] = values[i];
            }
            for (int i = 0; i < names.Count; i++)
            {
                strings[i] = names[i];
            }
            // Создадим кривую-гистограмму
            // Первый параметр - название кривой для легенды
            // Второй параметр - значения для оси X, т.к. у нас по этой оси будет идти текст, а функция ожидает тип параметра double[], то пока передаем null
            // Третий параметр - значения для оси Y
            // Четвертый параметр - цвет
            BarItem curve = pane.AddBar("Распределение студентов по специальностям", null, doubles, Color.Blue);
            pane.Title.Text = "Распределение студентов по специальностям"; //Изменение заголовка
            pane.XAxis.Type = AxisType.Text; // Настроим ось X так, чтобы она отображала текстовые данные
            pane.XAxis.Scale.TextLabels = strings; // Уставим для оси наши подписи
            zg1.AxisChange(); // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zg1.Invalidate(); // Обновляем график
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void zg1_Load(object sender, EventArgs e)
        {

        }
    }
}
