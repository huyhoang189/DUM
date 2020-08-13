using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataUserManager
{
    public partial class frmUserDetail : Form
    {
        public frmUserDetail()
        {
            InitializeComponent();
        }
        public frmUserDetail(DataGridViewRow user)
        {
            InitializeComponent();
            textBox1.Text = user.Cells["ID"].Value.ToString();
        }
    }
}
