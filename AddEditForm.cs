using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Selectioners
{
    public partial class AddEditForm : Form
    {
        public Plant Plant { get; private set; }

        public AddEditForm()
        {
            InitializeComponent();
            Plant = new Plant();
        }

        public AddEditForm(Plant plant) : this()
        {
            Plant = plant;

            textBox1.Text = plant.Name;
            textBox2.Text = plant.Type;
            textBox3.Text = plant.Description;
        }
        private void AddEditForm_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введіть всю інформацію");
                return;
            }

            Plant.Name = textBox1.Text;
            Plant.Type = textBox2.Text;
            Plant.Description = textBox3.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
