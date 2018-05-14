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
using System.Text.RegularExpressions;


namespace WindowsForm
{
    public struct Phone
    {
        public string Name;
        public string Number;
    }

    public partial class Form1 : Form
    {
        List<Phone> newPhone = new List<Phone>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            int count = 0;
            for (int i = 0; i < t2.Length; ++i)
            {
                if (char.IsLetter(t2[i]))
                {
                    count++;
                }
            }
            if (String.IsNullOrEmpty(t1) || String.IsNullOrEmpty(t2))
            {
                MessageBox.Show("Ошибка данных. \n" + "Необходимо ввести данные во все поля.", "Справочник", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else if (count == 0)
            {
                string st1 = textBox1.Text;
                string textik = File.ReadAllText("Begin");
                if (textik.Contains(st1))
                {
                    MessageBox.Show("В меня такой же не влезет");
                }
                else
                {
                    Phone x;
                    x.Name = textBox1.Text;
                    x.Number = textBox2.Text;
                    int x1 = search(x.Name);

                    if (x1 == -1)
                    {
                        newPhone.Add(x);
                        System.IO.StreamWriter write = new System.IO.StreamWriter("Begin", true);
                        write.WriteLine(textBox1.Text);
                        write.WriteLine(textBox2.Text);
                        write.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show("Внесен в блокнотик. Не долго ему осталось...");
                    }
                    else
                    {
                        MessageBox.Show("В меня такой же не влезет");
                    }
                }
            }
            else
                MessageBox.Show("В номерок буковка попала, так не пойдет");
        }

        int search(string s)
        {
            for (int i = 0; i < newPhone.Count; i++)
            {
                if (newPhone[i].Name.Equals(s))
                {
                    return i;
                }
            }
            return -1;
        }

        int search2(string d)
        {
            for (int i = 0; i < newPhone.Count; i++)
            {
                if (newPhone[i].Number.Equals(d))
                {
                    return i;
                }
            }
            return -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string d = textBox2.Text;
            int x = search(s);
            int y = search2(d);
            if (x != -1)
                textBox2.Text = newPhone[x].Number;
            else if (y != -1)
                textBox1.Text = newPhone[y].Name;
            else
                MessageBox.Show("Чот походу нет его");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Phone x;
            x.Name = textBox1.Text;
            x.Number = textBox2.Text;
            string line = null;
            int x1 = search(x.Name);
            int x2 = search(x.Number);

            if (x1 != -1 || x2 != -1)
            {
                newPhone.RemoveAt(x1);
                using (StreamReader reader = new StreamReader("Begin"))
                {
                    using (StreamWriter writer = new StreamWriter("End"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (String.Compare(line, x.Name) == 0)
                                continue;
                            if (String.Compare(line, x.Number) == 0)
                                continue;
                            writer.WriteLine(line);
                        }
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Абонент ликвидирован -_о");
            }
            else
            {
                MessageBox.Show("Хотелось бы его 'убрать', но я его не нашел :(");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newPhone.Clear();
            Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            newPhone.Clear();
            var biggie = File.CreateText("Begin");
            biggie.Close();
            var biggie2 = File.CreateText("End");
            biggie2.Close();
        }
    }
}