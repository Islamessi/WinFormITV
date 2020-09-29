using System;
using System.Windows.Forms;
using TestWinForm.Controller;

namespace TestWinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var a = (Form2)sender;
            var tmp = FormsController.GetFormByName(int.Parse(a.Text));
            FormsController.FormsDatas.Remove(tmp);
            FormsController.SaveFormsDatas();
            Form1.SetLabel1Value();
        }

        private void Form2_Move(object sender, EventArgs e)
        {
            var form = (Form2)sender;
            FormsController.ChangingFormData(form);
            Form1.SetLabel1Value();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            var form = (Form2)sender;
            FormsController.ChangingFormData(form);
            Form1.SetLabel1Value();
        } 
    }
}
