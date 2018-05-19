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

        public static bool goga = false;

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
                if (goga == true)
                {
                    string st1 = textBox1.Text;
                    string st2 = textBox2.Text;
                    string textik = File.ReadAllText("Bloknotik");
                    if (textik.Contains(st1) || textik.Contains(st2))
                    {
                        MessageBox.Show("В меня такой же не влезет");
                    }
                    else
                    {
                        int x1 = search(textBox1.Text);

                        if (x1 == -1)
                        {
                            System.IO.StreamWriter write = new System.IO.StreamWriter("Bloknotik", true);
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
                {
                    string st1 = textBox1.Text;
                    string st2 = textBox2.Text;
                    
                    string textik = File.ReadAllText("Bloknotikk");
                    if (textik.Contains(st1) || textik.Contains(st2))
                    {
                        MessageBox.Show("В меня такой же не влезет");
                    }
                    else
                    {
                        int x1 = search(textBox1.Text);
                        if (x1 == -1)
                        {
                            System.IO.StreamWriter write = new System.IO.StreamWriter("Bloknotikk", true);
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
            }
            else
                MessageBox.Show("В номерок буковка попала, так не пойдет");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
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
            int n = 0;
            int t = 0;
            int a = 0;
            int p = 0;
            string s = textBox1.Text;
            string d = textBox2.Text;
            int x = search(s);
            int y = search2(d);

            if (goga == true)
            {
                
                string text = File.ReadAllText("Bloknotik");
                if (text.Contains(textBox2.Text) && String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
                {
                    using (StreamReader reader = new StreamReader("Bloknotik"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != d)
                        {
                            a++;
                        }
                        textBox1.Text = File.ReadLines("Bloknotik").Skip(a-1).Take(1).First();
                    }
                }
                else if (text.Contains(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox1.Text))
                {
                    using (StreamReader reader = new StreamReader("Bloknotik"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != s)
                        {
                            p++;
                        }
                        textBox2.Text = File.ReadLines("Bloknotik").Skip(p+1).First();
                    }
                }
                else if ((!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox1.Text)))
                {
                    MessageBox.Show("Чтобы найти неприятеля, введите его номерок или наименование. Дальше я сделаю все сам ;)");
                }
                else if ((String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox1.Text)))
                {
                    MessageBox.Show("А шо искать-то? :D");
                }
                else
                {
                    MessageBox.Show("Нет такого в блокнотике. Земля ему пухом...");
                }
            }
            else
            {
                
                string text = File.ReadAllText("Bloknotikk");
                if (text.Contains(textBox2.Text) && String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
                {
                    using (StreamReader reader = new StreamReader("Bloknotikk"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != d)
                        {
                            t++;
                        }
                        textBox1.Text = File.ReadLines("Bloknotikk").Skip(t - 1).First();

                    }
                }
                else if (text.Contains(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox1.Text))
                {
                    using (StreamReader reader = new StreamReader("Bloknotikk"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != s)
                        {
                            n++;
                        }
                        textBox2.Text = File.ReadLines("Bloknotikk").Skip(n+1).First();
                    }
                }
                else if ((!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox1.Text)))
                {
                    MessageBox.Show("Чтобы найти неприятеля, введите его номерок или наименование. Дальше я сделаю все сам ;)");
                }
                else if ((String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox1.Text)))
                {
                    MessageBox.Show("А шо искать-то? :D");
                }
                else
                {
                    MessageBox.Show("Нет такого в блокнотике. Земля ему пухом...");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Phone x;
            x.Name = textBox1.Text;
            x.Number = textBox2.Text;
            string line = null;
            int x1 = search(x.Name);
            int x2 = search2(x.Number);

            if ((x1 == -1 || x2 == -1) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox1.Text))
            {
                if (goga == false)
                {
                    goga = true;
                    using (StreamReader reader = new StreamReader("Bloknotikk"))
                    {
                        var biggie = File.Create("Bloknotik");
                        biggie.Close();
                        using (StreamWriter writer = new StreamWriter("Bloknotik"))
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
                    File.Delete("Bloknotikk");
                }
                else
                {
                    goga = false;
                    using (StreamReader reader = new StreamReader("Bloknotik"))
                    {
                        var biggie = File.Create("Bloknotikk");
                        biggie.Close();
                        using (StreamWriter writer = new StreamWriter("Bloknotikk"))
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
                    File.Delete("Bloknotik");
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
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Bloknotik"))
                goga = true;
            else if (File.Exists("Bloknotikk"))
                goga = false;
        }
    }
}