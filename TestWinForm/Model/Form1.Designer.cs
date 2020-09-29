using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TestWinForm.Controller;

namespace TestWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            Label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть новое окно";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 27);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "Закрыть окно";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(503, 12);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(50, 20);
            Label1.TabIndex = 3;
            Label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя формы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(Label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosingAsync);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_ResizeAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;

        /// <summary>
        /// Вывод краткой информации о всех дочерних окнах в главной форме.
        /// </summary>
        public static void SetLabel1Value()
        {
            string tmp = "Все открытые формы:\n\n" +
                "Имя    Высота    Ширина\n";
            for (int i = 1; i < FormsController.FormsDatas.Count; i++)
            {
                if (FormsController.FormsDatas[i].WindowState == FormWindowState.Normal)
                {
                    tmp += $"{FormsController.FormsDatas[i].Name,-9}|  {FormsController.FormsDatas[i].Height,-10}|" +
                        $"  {FormsController.FormsDatas[i].Widht}\n";
                }
                else
                {
                    for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
                    {
                        if (Application.OpenForms[i1].Text == FormsController.FormsDatas[i].Name.ToString())
                        {
                            tmp += $"{Application.OpenForms[i1].Text,-9}|  {Application.OpenForms[i1].Height,-10}|" +
                            $"  {Application.OpenForms[i1].Width}\n";
                            break;
                        }
                    }
                }
            }
            Label1.Text = tmp;
        }

        private Button button2;
        private Label label3;
        private static Label Label1;
    }


}

