using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14._04._2019
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (comboBox1.Text == "Customers(Покупатели)")
      {
        if (comboBox1.Text == "Customers(Покупатели)")
        {
          listBox1.Items.Clear();
          Customers.Show(listBox1);

        }
        else if (comboBox1.Text == "Sellers(Продавцы)")
        {
          listBox1.Items.Clear();
          Sellers.Show(listBox1);
        }
        else
        {
          listBox1.Items.Clear();
          Sales.Show(listBox1);
        }
      }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
