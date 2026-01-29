using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selectioners
{
    public partial class Form1 : Form
    {
        private readonly PlantService plantService;

        public Form1()
        {
            InitializeComponent();
            plantService = new PlantService(new JsonPlantRepository());
            LoadData();
        }

        private void LoadData()
        {
            var list = plantService.GetAll()
                .Select(p => new { p.Id, p.Name, p.Type, p.Description })
                .ToList();

            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm();

            if (add.ShowDialog() == DialogResult.OK)
            {
                plantService.Add(add.Plant);
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            var plant = plantService.GetAll().First(p => p.Id == id);

            AddEditForm edit = new AddEditForm(plant);

            if (edit.ShowDialog() == DialogResult.OK)
            {
                plantService.Update();
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            plantService.Delete(id);
            LoadData();
        }
        private void Form1_Load(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            var list = plantService.Search(text)
                .Select(p => new { p.Id, p.Name, p.Type, p.Description })
                .ToList();

            dataGridView1.DataSource = list;
        }
    }
}
