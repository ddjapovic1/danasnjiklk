using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automobili
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            List<Automobil> al = ab.GetAutomobilis();
            foreach(Automobil a in al)
            {
                listBox1.Items.Add(a.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            Automobil a = new Automobil(1, textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox4.Text));
            bool result = ab.insertAuto(a);
            listBox1.Items.Clear();
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            List<Automobil> al = ab.jeftinijeOd(Convert.ToInt32(textBox5.Text));
            foreach(Automobil a in al)
            {
                listBox2.Items.Add(a.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            
            bool result = ab.deleteAuto(textBox6.Text);
            listBox1.Items.Clear();
            Form1_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            List<Automobil> al = ab.MarkaAuta(textBox7.Text);
            foreach (Automobil a in al)
            {
                listBox3.Items.Add(a.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AutoBusiness ab = new AutoBusiness();
            List<Automobil> al = ab.najvecaCena(2000);
            foreach (Automobil a in al)
            {
                listBox4.Items.Add(a.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Automobil a = new Automobil(Convert.ToInt32(textBox8.Text), textBox9.Text, Convert.ToInt32(textBox10.Text ),Convert.ToDecimal(textBox11.Text), Convert.ToInt32(textBox12.Text));
            AutoBusiness ab = new AutoBusiness();
            bool result = ab.UpdateAuto(a);
            listBox1.Items.Clear();
            Form1_Load(null, null);
            if (result)
                MessageBox.Show("Valid");
            else
                MessageBox.Show("Invalid");
        }
    }
}
