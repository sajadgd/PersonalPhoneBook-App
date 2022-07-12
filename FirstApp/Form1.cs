using FirstApp.Repository;
using FirstApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstApp
{
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.DataSource = repository.SelectAll();
        }

        private void dgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddOrEditContact frm = new AddOrEditContact();
            frm.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string FirstName = dgvContacts.CurrentRow.Cells[1].Value.ToString();
            string LastName = dgvContacts.CurrentRow.Cells[2].Value.ToString();
            string FullName = FirstName + " " + LastName;
            if (dgvContacts.CurrentRow != null)
            {
                
                if (MessageBox.Show($"آیا از حذف {FullName} اطمینان دارید ؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int contactId = Convert.ToInt32(dgvContacts.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactId);
                    BindGrid();
                }
                
            }
            else
            {
                MessageBox.Show("لطفاٌ گزینه مورد نظر را انتخاب کنید !");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int contactId = Convert.ToInt32(dgvContacts.CurrentRow.Cells[0].Value);
            AddOrEditContact frm = new AddOrEditContact();
            frm.contactId = contactId;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvContacts.DataSource = repository.Search(txtSearch.Text);
        }
    }
}
