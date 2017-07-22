using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Basket B;

        public Form1()
        {
            InitializeComponent();
            B = new Basket();
            comboBox1.Items.Add("Альпен Гольд");
            comboBox1.Items.Add("Булочка с сыром");
            comboBox1.Items.Add("Марс");
            comboBox1.Items.Add("Сникерс");
            comboBox1.Items.Add("Сок 'Добрый' 1л");
            comboBox1.Items.Add("Твикс");

            comboBox2.Items.Add("Картошка");
            comboBox2.Items.Add("Крупа гречневая");
            comboBox2.Items.Add("Огурцы");
            comboBox2.Items.Add("Печенье 'Юбилейное'");
            comboBox2.Items.Add("Помидоры");
            comboBox2.Items.Add("Сахар");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
        private void button3_Click(object sender, EventArgs e)
        {
            B = new Basket();
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pieces item = new Pieces("No", 1, 1, 1);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    item.Acode = 1;
                    item.Title = "Альпен Гольд";
                    item.PriceFP = 60;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
                case 1:
                    item.Acode = 2;
                    item.Title = "Булочка с сыром";
                    item.PriceFP = 35;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
                case 2:
                    item.Acode = 3;
                    item.Title = "Марс";
                    item.PriceFP = 30;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
                case 3:
                    item.Acode = 4;
                    item.Title = "Сникерс";
                    item.PriceFP = 35;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
                case 4:
                    item.Acode = 5;
                    item.Title = "Сок 'Добрый' 1л";
                    item.PriceFP = 80;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
                case 5:
                    item.Acode = 6;
                    item.Title = "Твикс";
                    item.PriceFP = 35;
                    item.Count = Decimal.ToInt32(numericUpDown1.Value);
                    break;
            }
            B.AddCM(item);
            DataLoad(B);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mass item = new Mass("No", 1, 1, 1);
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    item.Acode = 7;
                    item.Title = "Картошка";
                    item.PriceFK = 35;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
                case 1:
                    item.Acode = 8;
                    item.Title = "Крупа гречневая";
                    item.PriceFK = 150;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
                case 2:
                    item.Acode = 9;
                    item.Title = "Огурцы";
                    item.PriceFK = 100;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
                case 3:
                    item.Acode = 10;
                    item.Title = "Печенье 'Юбилейное'";
                    item.PriceFK = 80;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
                case 4:
                    item.Acode = 11;
                    item.Title = "Помидоры";
                    item.PriceFK = 150;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
                case 5:
                    item.Acode = 12;
                    item.Title = "Сахар";
                    item.PriceFK = 35;
                    item.Weight = Decimal.ToInt32(numericUpDown2.Value);
                    break;
            }
            B.AddWM(item);
            DataLoad(B);
        }


        private void DataLoad(Basket bas)
        {
            dataGridView1.RowCount = bas.SumCount();
            for (int i = 0; i < bas.WMi; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = bas.WM[i].Acode;
                dataGridView1.Rows[i].Cells[1].Value = bas.WM[i].Title;
                dataGridView1.Rows[i].Cells[2].Value = bas.WM[i].Weight.ToString() + " кг.";
                dataGridView1.Rows[i].Cells[3].Value = bas.WM[i].PriceFK.ToString() + " руб. за кг.";
            }

            for (int i = 0; i < bas.CMi; i++)
            {
                dataGridView1.Rows[i + bas.WMi].Cells[0].Value = bas.CM[i].Acode;
                dataGridView1.Rows[i + bas.WMi].Cells[1].Value = bas.CM[i].Title;
                dataGridView1.Rows[i + bas.WMi].Cells[2].Value = bas.CM[i].Count.ToString() + " шт.";
                dataGridView1.Rows[i + bas.WMi].Cells[3].Value = bas.CM[i].PriceFP.ToString() + " руб. за шт.";
            }

            label6.Text = B.Price().ToString() + " рублей";

        }

    }
}
