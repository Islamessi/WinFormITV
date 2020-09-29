using System;
using System.Windows.Forms;
using TestWinForm.Controller;

namespace TestWinForm
{
    [Serializable]
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormsController.FormsDatas =  FormsController.GetFormsDatas();
            for (int i = 1; i < FormsController.FormsDatas.Count; i++)
            {
                FormsController.FormsDatas[i].Name = i;
            }
            #region comments
            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    if (fs.Length > 0) 
            //        FormsDatas = await JsonSerializer.DeserializeAsync<List<FormsData>>(fs);
            //    else
            //    {
            //        var tmp = new FormsData { Name = 0, X = 500, Y = 200, Height = 500, Widht = 1000 };
            //        FormsDatas.Add(tmp);
            //    }
            //}

            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    await JsonSerializer.SerializeAsync(fs, formsDatas);
            //}
            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    formsDatas = await JsonSerializer.DeserializeAsync<List<FormsData>>(fs);
            //}
            #endregion
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()
            {
                WindowState = FormsController.FormsDatas[0].WindowState,
                Height = FormsController.FormsDatas[0].Height,
                StartPosition = FormStartPosition.Manual,
                Location = new System.Drawing.Point { X = FormsController.FormsDatas[0].X, Y = FormsController.FormsDatas[0].Y },
                Text = FormsController.FormsDatas[0].Name.ToString(),
                Width = FormsController.FormsDatas[0].Widht,
            });
        }
    }
}
