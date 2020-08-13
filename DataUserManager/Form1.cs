using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataUserManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initForm();
            createTableInDatagridView();

        }
        private void initForm()
        {
            btn_detail.Enabled = false;
            btn_delete.Enabled = false;
        }
        private void optionItem_Click(object sender, EventArgs e)
        {
          using(frmOptions frmOptions  = new frmOptions())
            {
                frmOptions.ShowDialog();
            }
        }

        private void createTableInDatagridView()
        {
            dtGrvUsers.ColumnCount = 7;
            dtGrvUsers.Columns[0].Name = "STT";
            dtGrvUsers.Columns[0].Width = 60;
            dtGrvUsers.Columns[1].Name = "ID";
            dtGrvUsers.Columns[1].Width = 250;
            dtGrvUsers.Columns[2].Name = "Tên máy";
            dtGrvUsers.Columns[2].Width = 240;
            dtGrvUsers.Columns[3].Name = "Ngày bắt đâu";
            dtGrvUsers.Columns[3].Width = 240;
            dtGrvUsers.Columns[4].Name = "Vị trí bắt đầu";
            dtGrvUsers.Columns[4].Width = 150;
            dtGrvUsers.Columns[5].Name = "Trạng thái";
            dtGrvUsers.Columns[5].Width = 150;
            dtGrvUsers.Columns[6].Name = "";
            //dtGrvUsers.Columns[6].Width = 60;

            for (int i  = 0;i < 10; i++)
            {
                string[] row = new string[] { i+"", Guid.NewGuid().ToString("N"), "Product " + i, "","", (i % 3) == 1 ? "Đang hoạt động" : "Không hoạt động"};
                dtGrvUsers.Rows.Add(row);
            }
            updateDatagridViewStatus();
            dtGrvUsers.Rows[dtGrvUsers.RowCount - 1].Selected = true;

        }
        private void updateDatagridViewStatus()
        {
            foreach (DataGridViewRow row in dtGrvUsers.Rows)
            {
                if (Convert.ToString(row.Cells["Trạng thái"].Value) == "Đang hoạt động")
                {
                    row.Cells[6].Style.BackColor = Color.Green;
                    //row.Cells[6].Style.Padding = new Padding(20, 20, 20, 20);

                }
                else
                {
                    row.Cells[6].Style.BackColor = Color.Red;
                    //row.Cells[6].Style.Padding = new Padding(20, 20, 20, 20);
                }
            }
        }

        private void dtGrvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < dtGrvUsers.RowCount- 1)
            {
                btn_detail.Enabled = true;
                btn_delete.Enabled = true;

            }
            else
            {
                btn_detail.Enabled = false;
                btn_delete.Enabled = false;
            }
        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            using(frmUserDetail frmUserDetail = new frmUserDetail(dtGrvUsers.CurrentRow))
            {
                frmUserDetail.ShowDialog();
            }
        }
    }
}
