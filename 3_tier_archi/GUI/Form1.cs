using _3_tier_archi.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_tier_archi
{
    public partial class Form1 : Form
    {
        Stores currentStore;

        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshdataGridViewStoreManage()
        {
            dataGridViewStoreManage.DataSource = StoresDAL.GetAllCommand();
        }
        private void ClearForm()
        {
            txtStoreName.Text = "";
            txtStoreID.Text = "";
            txtStorePhone.Text = "";
        }

        private void dataGridViewStoreManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentStore = new Stores();
            DataGridViewRow row = new DataGridViewRow();

            row = dataGridViewStoreManage.Rows[e.RowIndex];
            currentStore.StId = int.Parse(row.Cells[0].Value.ToString());
            currentStore.StoreID = row.Cells[1].Value.ToString();
            currentStore.StoreName = row.Cells[2].Value.ToString();
            currentStore.StorePhone = row.Cells[3].Value.ToString();
            txtStoreID.Text = currentStore.StoreID;
            txtStoreName.Text = currentStore.StoreName;
            txtStorePhone.Text = currentStore.StorePhone;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Stores store = new Stores();
            store.StoreName = txtStoreName.Text;
            store.StoreID = txtStoreID.Text;
            store.StorePhone = txtStorePhone.Text;
            StoresDAL.InsertCommand(store);
            RefreshdataGridViewStoreManage();
            MessageBox.Show("Store Successfully Added");
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentStore.StoreName = txtStoreName.Text;
            currentStore.StoreID = txtStoreID.Text;
            currentStore.StorePhone = txtStorePhone.Text;
            StoresDAL.UpdateCommand(currentStore);
            RefreshdataGridViewStoreManage();
            MessageBox.Show("Store Successfully Updated");
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StoresDAL.DeleteCommand(currentStore);

            RefreshdataGridViewStoreManage();

            MessageBox.Show("Store Successfully Deleted");

            ClearForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshdataGridViewStoreManage();
        }
    }
}
