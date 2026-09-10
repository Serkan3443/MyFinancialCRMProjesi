using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCRMProjesi.Models;

namespace MyFinancialCRMProjesi
{
	public partial class FrmDashboard : Form
	{
		public FrmDashboard()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db=new FinancialCrmDbEntities();
		int count = 0;
		private void FrmDashboard_Load(object sender, EventArgs e)
		{
			var totalBalance = db.Banks.Sum(x => x.BankBalance);
			lblTotalBalance.Text = totalBalance.ToString() +"₺";

			var lastBankProcessAmout = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
			lblBankProcessAmout.Text = lastBankProcessAmout.ToString() + "₺";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			count++;
			if (count % 4 == 1)
			{
				var elektrikFaturasi= db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Elektrik Faturası";
				lblBillAmout.Text=elektrikFaturasi.ToString() + "₺";
			}

			if (count % 4 == 2)
			{
				var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Doğalgaz Faturası";
				lblBillAmout.Text = dogalgazFaturasi.ToString() + "₺";
			}
			if (count % 4 == 3)
			{
				var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Su Faturası";
				lblBillAmout.Text = suFaturasi.ToString() + "₺";
			}
			if (count % 4 == 0)
			{
				var internetFaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "İnternet Faturası";
				lblBillAmout.Text = internetFaturasi.ToString() + "₺";
			}
		}
	}
}
