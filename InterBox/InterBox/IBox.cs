using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterBox
{
    public interface View
    {
        string FilePath { get; }
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
    }

    public partial class IBox : Form, View
    {
        public IBox()
        {
            InitializeComponent();
            butOpen.Click += new EventHandler(ButOpen_Click);
            butSave.Click += ButSave_Click;
            butSelect.Click += ButSelect_Click;
        }

        private void ButSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                text.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        public string FilePath
        {
            get { return text.Text; }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
    }
}
