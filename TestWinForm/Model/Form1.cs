using System;
using System.Drawing;
using System.Windows.Forms;
using TestWinForm.Controller;

namespace TestWinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Инициализация всех открытх ранее форм.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < FormsController.FormsDatas.Count; i++)
            {
                Form2 form2 = new Form2()
                {
                    WindowState = FormsController.FormsDatas[i].WindowState,
                    Height = FormsController.FormsDatas[i].Height,
                    Width = FormsController.FormsDatas[i].Widht,
                    Text = i.ToString(),
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(FormsController.FormsDatas[i].X, FormsController.FormsDatas[i].Y),
                };
                form2.Show();
            }
            FormsController.NumberForms = FormsController.FormsDatas.Count; //Запомнили количество открытх форм.
            SetLabel1Value(); //Изменение данных о формах в главной форме.
        }

        /// <summary>
        /// Кнопка открытия новых дочерних окон.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2 { Text = FormsController.NumberForms.ToString() };
            FormsData tmp = new FormsData
            {
                Name = int.Parse(form2.Text),
                X = form2.Location.X,
                Y = form2.Location.Y,
                Height = form2.Height,
                Widht = form2.Width,
                WindowState = form2.WindowState,
            };
            FormsController.NumberForms++; //Увеличиваем счетчик открытых форм.
            FormsController.FormsDatas.Add(tmp); //Добавляем в список открытых форм эту форму.
            form2.Show(); //Показываем на экране эту форму.
            FormsController.ChangingFormData(form2); //Обновление данных их и сохраняем в файл.
            SetLabel1Value(); //Изменение данных о формах в главной форме.
        }

        /// <summary>
        /// Перед закрытием всех форм Сохраняем данные еще раз, на всякий случай.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosingAsync(object sender, FormClosingEventArgs e)
        {
            FormsController.SaveFormsDatas();
        }

        /// <summary>
        /// Действия при изменении Размеров главной формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ResizeAsync(object sender, EventArgs e)
        {
            var form = (Form1)sender;
            FormsController.ChangingFormData(form);
            SetLabel1Value();
        }

        /// <summary>
        /// Действия при перемещении главной формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Move(object sender, EventArgs e)
        {
            var form = (Form1)sender;
            FormsController.ChangingFormData(form);
        }

        /// <summary>
        /// Действия при нажатии закрытия какой-то формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i =0; i< Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Text == textBox1.Text && textBox1.Text != "0") 
                    //Будут закрываться все существующие формы кроме главной.
                {
                    Application.OpenForms[i].Close();
                    break;
                }
            }
        }
    }
}
