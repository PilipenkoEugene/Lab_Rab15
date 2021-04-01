using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowHelp = true;
            dlg.Color = panelChooseColor.BackColor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                panelChooseColor.BackColor = dlg.Color;
                labelResult.BackColor = dlg.Color;
            }
        }

        private void BtnChooseFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowColor = true;
            dlg.ShowHelp = true;
            dlg.Font = txtChooseFont.Font;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtChooseFont.Font = dlg.Font;
                labelResult.Font = dlg.Font;
                txtChooseFont.ForeColor = dlg.Color;
                labelResult.ForeColor = dlg.Color;
            }
        }

        private void BtnChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "выберите папку для демонстрации работы диалога";
            dlg.ShowNewFolderButton = true;
            dlg.SelectedPath = Application.StartupPath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtChooseFolder.Text = dlg.SelectedPath;
            }
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {            
            double x = Convert.ToDouble(textBoxX.Text);
            double n = Convert.ToDouble(textBoxN.Text);
            

            double result = 0;
            int znam = 2;
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    long zz = 1;
                    for (int j = 1; j <= znam ; j++)
                    {
                        zz = zz * j;
                    }
                    znam++;
                    if (i % 2 == 0)
                        result += Math.Sin(Math.Pow(x, i + 1)) * Math.Pow(x, i + 2) / zz;
                    else
                        result += Math.Pow(x, i + 1) * Math.Sin(Math.Pow(x, i + 2)) / zz;
                }

                labelResult.Text = String.Format("Ответ = {0:0.00}", result);
            }
            else
            {
                MessageBox.Show("Введите допустимое n");
            }

            if (txtChooseFolder.Text != "")
            {
                string file = Path.Combine(txtChooseFolder.Text, "result.txt");
                File.WriteAllText(file, Convert.ToString(result));
            }
        }
    }
}
