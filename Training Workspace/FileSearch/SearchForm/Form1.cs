using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SearchForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void search(object sender, MouseEventArgs e)
        {
            Searcher sr=new Searcher();
            List<string> match=sr.search(textBox1.Text);
            MessageBox.Show(sr.display(match));
        }
    }
}
