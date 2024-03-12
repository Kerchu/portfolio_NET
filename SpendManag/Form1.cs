using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpendManag
{
    public partial class Form1 : Form
    {
        public class Spend
        {
            public string desc { get; set; }
            public decimal amount { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegisterSpend_Click(object sender, EventArgs e)
        {
            Spend newSpend = new Spend
            {
                desc = txtDesc.Text,
                amount = decimal.Parse(txtAmount.Text),
            };

            if (newSpend != null )
            {
                decimal arsAmount = 0;
                arsAmount = newSpend.amount;
                newSpend.amount = newSpend.amount / 990;
                dgv_data.Rows.Add(newSpend.desc, arsAmount, newSpend.amount);
            }
        }
    }
}
