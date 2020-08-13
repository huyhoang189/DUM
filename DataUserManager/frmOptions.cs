
using System;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using DataUserManager.Helper;

namespace DataUserManager
{
    public partial class frmOptions : Form
    {
        private string currentNameDb = "";
        public frmOptions()
        {
            InitializeComponent();
            initForm();
            if(GlobalVar.nameDataBase.Length > 2)
                cbbSelectedDb.Text = GlobalVar.nameDataBase;
            if (GlobalVar.nameDirectory.Length > 2)
                txt_directory.Text = GlobalVar.nameDirectory;
        }
        private void initForm()
        {
            cbbSelectedDb.Enabled = false;
            txt_directory.Enabled = false;
            btn_save.Enabled = false;
            btn_edit.Enabled = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            cbbSelectedDb.DataSource = new BindingSource(DatabaseHelper.getListLocalServer() , null);
            cbbSelectedDb.DisplayMember = "Value";
            cbbSelectedDb.ValueMember = "Key";
        }
       
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //save file
            if (cbbSelectedDb.Enabled)
            {
                cbbSelectedDb.Enabled = false;
                txt_directory.Enabled = false;
                btn_save.Enabled = false;
                btn_edit.Enabled = true;
                lb_status.Text = "Kết nối thành công " + currentNameDb;
                GlobalVar.nameDataBase = currentNameDb;

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //edit file
            if(cbbSelectedDb.Enabled == false)
            {
                cbbSelectedDb.Enabled = true;
                txt_directory.Enabled = true;
                btn_save.Enabled = true;
                btn_edit.Enabled = false;
            }
        }

        private void cbbSelectedDb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                object Db = cbbSelectedDb.SelectedItem;
                string nameDb = Db.GetType().GetProperty("Value").GetValue(Db, null).ToString();
                currentNameDb = nameDb;
                //MessageBox.Show(nameDb);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_directory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txt_directory.Text = fbd.SelectedPath;
                    GlobalVar.nameDirectory = fbd.SelectedPath;
                }
            }
        }
    }
}
