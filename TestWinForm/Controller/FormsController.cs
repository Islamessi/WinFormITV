using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TestWinForm.Controller
{
    public static class FormsController
    {
        public static List<FormsData> FormsDatas { get; set; } = new List<FormsData>();

        public static int NumberForms { get; set; }

        /// <summary>
        /// Сохранить данные о формах.
        /// </summary>
        public static void SaveFormsDatas()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("FormsDatas.dat", FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fs, FormsDatas);
            }
        }

        /// <summary>
        /// Получить данные о формах из файла.
        /// </summary>
        /// <returns></returns>
        public static List<FormsData> GetFormsDatas()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("FormsDatas.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    if (fomatter.Deserialize(fs) is List<FormsData> formsDatas)
                    {
                        return formsDatas;
                    }
                    return new List<FormsData>();
                }
                catch
                {
                    var tmp = new FormsData
                    {
                        Name = 0,
                        X = 500,
                        Y = 200,
                        Height = 500,
                        Widht = 1000,
                        WindowState = System.Windows.Forms.FormWindowState.Normal
                    };
                    FormsDatas.Add(tmp);
                    fomatter.Serialize(fs, FormsDatas);
                    return FormsDatas;
                }
            }
        }

        /// <summary>
        /// Получить форму из списка по имени.
        /// </summary>
        /// <param name="name"> Имя формы. </param>
        /// <returns></returns>
        public static FormsData GetFormByName(int name)
        {
            return FormsDatas.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Получить индекс Формы в листе по имени.
        /// </summary>
        /// <param name="name"> Имя формы. </param>
        /// <returns></returns>
        public static int GetNumberForm(int name)
        {
            for (int i = 0; i < FormsDatas.Count; i++)
            {
                if (FormsDatas[i].Name == name)
                {
                    return i;
                }
            }
            throw new System.Exception("Не найдено имени формы!");
        }


        /// <summary>
        /// Изменение данных о формах.
        /// </summary>
        /// <param name="form"> Форма. </param>
        public static void ChangingFormData(Form1 form)
        {
            if (form.Text != "Form1")
            {
                int index = GetNumberForm(int.Parse(form.Text));
                if (form.WindowState == System.Windows.Forms.FormWindowState.Minimized || 
                    form.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    FormsDatas[index].WindowState = form.WindowState;
                }
                else
                {
                    FormsDatas[index].X = form.Location.X;
                    FormsDatas[index].Y = form.Location.Y;
                    FormsDatas[index].Widht = form.Width;
                    FormsDatas[index].Height = form.Height;
                    FormsDatas[index].WindowState = form.WindowState;
                }
            }
            SaveFormsDatas();
        }
        public static void ChangingFormData(Form2 form)
        {
            if (form.Text != "Form2")
            {
                int index = GetNumberForm(int.Parse(form.Text));
                if (form.WindowState == FormWindowState.Minimized ||
                    form.WindowState == FormWindowState.Maximized)
                {
                    FormsDatas[index].WindowState = form.WindowState;
                }
                else
                {
                    FormsDatas[index].X = form.Location.X;
                    FormsDatas[index].Y = form.Location.Y;
                    FormsDatas[index].Widht = form.Width;
                    FormsDatas[index].Height = form.Height;
                    FormsDatas[index].WindowState = form.WindowState;
                }
            }
            SaveFormsDatas();
        }

        /// <summary>
        /// Изменение данныхв подчиненных формах.
        /// </summary>
        public static void ChangingDataInForm(Form2 form2)
        {
            int x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0;
            Screen[] sc;
            sc = Screen.AllScreens;
            foreach(var item in sc)
            {
                if (form2.Location.X > item.Bounds.X && form2.Location.X + form2.Width < item.Bounds.X + item.Bounds.Width)
                    x1 = form2.Location.X;
                else
                    x1 = item.Bounds.X;

            }
        }
    }
}
