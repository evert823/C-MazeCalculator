using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeCalculator
{
    public partial class frmWidthHeightEntry : Form
    {
        public frmWidthHeightEntry()
        {
            InitializeComponent();
        }

        public int HorizontalValue;
        public int VerticalValue;

        private void ValidateInput()
        {
            string nshor;
            string nsver;
            int nhor;
            int nver;

            this.HorizontalValue = 1;
            this.VerticalValue = 1;

            nshor = txbHorizontal.Text;
            nsver = txbVertical.Text;

            if (int.TryParse(nshor, out nhor) == false)
            {
                txbHorizontal.Text = "1";
                nhor = 1;
            }
            if (int.TryParse(nsver, out nver) == false)
            {
                txbVertical.Text = "1";
                nver = 1;
            }

            this.HorizontalValue = nhor;
            this.VerticalValue = nver;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateInput();
            this.Close();
        }
    }
}
