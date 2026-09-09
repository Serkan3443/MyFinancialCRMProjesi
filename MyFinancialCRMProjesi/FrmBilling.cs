using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCRMProjesi.Models;
namespace MyFinancialCRMProjesi
{
	public partial class FrmBilling : Form
	{
		public FrmBilling()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		private void FrmBilling_Load(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnListBilling_Click(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnNewBilling_Click(object sender, EventArgs e)
		{
			string title=txtBillingTitle.Text;
			decimal amout = decimal.Parse(txtBillingAmout.Text);
			string period = txtBillingPeriot.Text;

			Bills bills = new Bills();
			bills.BillTitle = title;
			bills.BillAmount = amout;
			bills.BillPeriod = period;
			db.Bills.Add(bills);
			db.SaveChanges();
			MessageBox.Show("Ödeme Başarılı bir şekilde sisteme eklendi","Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values=db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnDeleteBilling_Click(object sender, EventArgs e)
		{
			
			int id = int.Parse(txtBillingId.Text);
			var remove = db.Bills.Find(id);
			db.Bills.Remove(remove);
			db.SaveChanges();
			MessageBox.Show("Ödeme Başarılı bir şekilde sistemden silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnUpdateBilling_Click(object sender, EventArgs e)
		{
			string title=txtBillingTitle.Text;
			decimal amout=decimal.Parse(txtBillingAmout.Text);
			string period = txtBillingPeriot.Text;
			int id = int.Parse(txtBillingId.Text);
			var value=db.Bills.Find(id);
			
			value.BillTitle = title;
			value.BillAmount = amout;
			value.BillPeriod = period;
			db.Bills.AddOrUpdate(value);
			db.SaveChanges();

			MessageBox.Show("Ödeme Başarılı bir şekilde sistemde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;

		}

		private void btnBanks_Click(object sender, EventArgs e)
		{
			FrmBank frm = new FrmBank();
			frm.Show();
			this.Hide();
		}
	}
}
