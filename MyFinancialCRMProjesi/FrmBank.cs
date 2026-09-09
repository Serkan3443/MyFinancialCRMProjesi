using MyFinancialCRMProjesi.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MyFinancialCRMProjesi
{
	public partial class FrmBank : Form
	{
		public FrmBank()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db=new FinancialCrmDbEntities();
		private void FrmBank_Load(object sender, EventArgs e)
		{
			var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();

			var vakifBankBalance=db.Banks.Where(x=>x.BankTitle=="Vakıf Bankası").Select(y=>y.BankBalance).FirstOrDefault();

			var IsBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

			lblZiraartBankBalance.Text= ziraatBankBalance.ToString() +"₺";
			lblVakifBankBalance.Text = vakifBankBalance.ToString() + "₺";
			lblIsBankBalance.Text = IsBankBalance.ToString() + "₺";
		}
	}
}
