using MyFinancialCRMProjesi.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
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
			//Banka bakiyelerini veren kodlar
			var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();

			var vakifBankBalance=db.Banks.Where(x=>x.BankTitle=="Vakıf Bankası").Select(y=>y.BankBalance).FirstOrDefault();

			var IsBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

			lblZiraartBankBalance.Text= ziraatBankBalance.ToString() +"₺";
			lblVakifBankBalance.Text = vakifBankBalance.ToString() + "₺";
			lblIsBankBalance.Text = IsBankBalance.ToString() + "₺";
			//----------------------------------------------------------------------------------------------

			//Banka Hareketleri
			var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();//Take(1) yani sqldeki order by desc olarak geçer son işlemi getirir demek.
			lblBankProcess1.Text = bankProcess1.Descriptionn + " " + bankProcess1.Amount +"₺" + " " + bankProcess1.ProcessDate;

			var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
			lblBankProcess2.Text = bankProcess2.Descriptionn + " " + bankProcess2.Amount + "₺" + " " + bankProcess2.ProcessDate;

			var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
			lblBankProcess3.Text = bankProcess3.Descriptionn + " " + bankProcess3.Amount + "₺" + " " + bankProcess3.ProcessDate;

			var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
			lblBankProcess4.Text = bankProcess4.Descriptionn + " " + bankProcess4.Amount + "₺" + " " + bankProcess4.ProcessDate;

			var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
			lblBankProcess5.Text=bankProcess5.Descriptionn + " " + bankProcess5.Amount +"₺" + " " + bankProcess5.ProcessDate;
			
			
		}

		private void btnBillingForm_Click(object sender, EventArgs e)
		{
			FrmBilling frm=new FrmBilling();
			frm.Show();
			this.Hide();
		}
	}
}
