using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoxExpress;

namespace InterBox
{
    public interface View
    {
        //string FilePath { get; }
        //string Content { get; set; }
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        //event EventHandler ContentChanged;
    }

    public partial class IBox : Form, View
    {
        public IBox()
        {
            InitializeComponent();
            butOpen.Click += new EventHandler(ButOpen_Click);
            butSave.Click += ButSave_Click;
            //butSelect.Click += ButSelect_Click;
            //fldContent.TextChanged += fldContent_TextChanged;
        }

        FormSample GetModelFromUI()
        {
            return new FormSample
            {
                Name = textBox1.Text,
                Product = new Product()
                {
                    //Type = comboBox1.,
                    ProductName = textBox3.Text,
                    Description = textBox2.Text,
                    Count = (int)numericUpDown1.Value,
                },
                Address = new Address()
                {
                    //Gos = comboBox2,
                    Region = textBox4.Text,
                    City = textBox5.Text,
                    Index = textBox6.Text,
                    Phone = textBox7.Text,
                }
            };
         }

        private void ComboBox()
        {
            comboBox1.Items.Add(Сountry.RussianFederation);
            comboBox1.Items.Add(Сountry.China);
            comboBox1.Items.Add(Сountry.India);

            comboBox2.Items.Add(Staff.Electronics);
            comboBox2.Items.Add(Staff.Clothes);
            comboBox2.Items.Add(Staff.Cosmetics);
        }

        private void SetModelToUI(FormSample wtf)
        {
            textBox1.Text = wtf.Name;
            textBox3.Text = wtf.Product.ProductName;
            textBox2.Text = wtf.Product.Description;
            numericUpDown1.Value = wtf.Product.Count;
            textBox4.Text = wtf.Address.Region;
            textBox5.Text = wtf.Address.City;
            textBox6.Text = wtf.Address.Index;
            textBox7.Text = wtf.Address.Phone;
        }

        private void Saver(FormSample wtf)
        {
            if (comboBox1.SelectedIndex == 0)
                wtf.Product.Type = Staff.Electronics;
            if (comboBox1.SelectedIndex == 1)
                wtf.Product.Type = Staff.Clothes;
            if (comboBox1.SelectedIndex == 2)
                wtf.Product.Type = Staff.Cosmetics;


            if (comboBox2.SelectedIndex == 0)
                wtf.Address.Gos = Сountry.RussianFederation;
            if (comboBox2.SelectedIndex == 1)
                wtf.Address.Gos = Сountry.China;
            if (comboBox2.SelectedIndex == 2)
                wtf.Address.Gos = Сountry.India;

        }
        private void Setter(FormSample wtf)
        {
            if (wtf.Product.Type == Staff.Electronics)
                comboBox1.SelectedIndex = 0;
            if (wtf.Product.Type == Staff.Clothes)
                comboBox1.SelectedIndex = 1;
            if (wtf.Product.Type == Staff.Cosmetics)
                comboBox1.SelectedIndex = 2;


            if (wtf.Address.Gos == Сountry.RussianFederation)
                comboBox2.SelectedIndex = 0;
            if (wtf.Address.Gos == Сountry.China)
                comboBox2.SelectedIndex = 1;
            if (wtf.Address.Gos == Сountry.India)
                comboBox2.SelectedIndex = 2;

        }
        private void ButSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //text.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
            var wtf = new SaveFileDialog() { Filter = "Файлы заказов|*.txt" };
            var result = wtf.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var mem = GetModelFromUI();
                Saver(mem);
                Kekus.WriteToFile(wtf.FileName, mem);
            }
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            var wtf = new OpenFileDialog() { Filter = "Файлы заказа|*.txt" };
            var result = wtf.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var mem = Kekus.LoadFromFile(wtf.FileName);
                SetModelToUI(mem);
                Setter(mem);
            }
        }
        //private void fldContent_TextChanged(object sender, EventArgs e)
        //{
        //    if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        //}
        //public string Content
        //{
        //    get { return fldContent.Text; }
        //    set { fldContent.Text = value; }
        //}

        //public string FilePath
        //{
        //    get { return text.Text; }
        //}

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        //public event EventHandler ContentChanged;
    }
}
