using Cemp.Control;
using Cemp.gui;
using Cemp.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp
{
    public partial class FrmMain : Form
    {
        CnviControl cc;
        Form frm;
        Staff sf;
        public FrmMain(Form f, String sfCode, CnviControl l)
        {
            InitializeComponent();
            initConfig(f, sfCode, l);
        }
        private void initConfig(Form f, String sfCode, CnviControl l)
        {
            //lc = new LottoryControl();
            cc = l;
            frm = f;
            sf = cc.sfdb.selectByCode(sfCode);
            cc.sf = sf;
            tvMain();
        }
        private void showFrame(Form f)
        {
            this.Hide();
            f.ShowDialog(this);
            this.Show();
        }
        private void tvMain()
        {
            tv1.Nodes.Clear();

            //if (sf.Priority.Equals("1") || sf.Priority.Equals("3"))
            //{
            tv1.Nodes.Add("nQuotationView", "พิมพ์ Quotation");
            tv1.Nodes.Add("nQuoConfirmView", "Confirm Quotation");
            tv1.Nodes.Add("nMOUView", "พิมพ์ ใบข้อตกลง");
            //tv1.Nodes.Add("nMOUPlaceRecord", "พิมพ์ ใบรับตัวอย่าง");
            tv1.Nodes.Add("nInputResult", "ป้อนผลตัวอย่าง");
            tv1.Nodes.Add("nBillView", "พิมพ์ Bill Note");
            tv1.Nodes.Add("nPOView", "พิมพ์ ใบสั่งซื้อ");
            tv1.Nodes.Add("nAPView", "หน้าจอ บริหารเจ้าหนี้");
            tv1.Nodes.Add("nARView", "หน้าจอ บริหารลูกหนี้");
            //tv1.Nodes.Add("nQuotationReport", "หน้าจอ Quotation รายงาน");
            //}
            //if (sf.Priority.Equals("2") || sf.Priority.Equals("3"))
            //{
            //    tv1.Nodes.Add("nLottoImage", "นำรูปเข้าระบบ");
            //    tv1.Nodes.Add("nLottoApprove", "ยืนยันตัวเลข");
            //    tv1.Nodes.Add("nLottoResult", "ตรวจรางวัลประจำงวด");
            //    tv1.Nodes.Add("nLottoSummary", "สรุปข้อมูลประจำงวด");
            //}
            //if (sf.Priority.Equals("3"))
            //{
            tv1.Nodes.Add("nInitConfig", "กำหนดค่าโปรแกรม");
            tv1.Nodes["nInitConfig"].Nodes.Add("nItemView", "สร้างรายการ Parameter");
            tv1.Nodes["nInitConfig"].Nodes.Add("nMethodView", "สร้างรายการ Method");
            tv1.Nodes["nInitConfig"].Nodes.Add("nItemGroupView", "สร้าง Parameter Group");
            tv1.Nodes["nInitConfig"].Nodes.Add("nAnalysisView", "สร้างรายการ Analysis");
            tv1.Nodes["nInitConfig"].Nodes.Add("nCustomerView", "สร้าง ลูกค้า");
            tv1.Nodes["nInitConfig"].Nodes.Add("nStaffView", "สร้าง พนักงาน");

            tv1.Nodes["nInitConfig"].Nodes.Add("nCompany", "ข้อมูลบริษัท");
            //tv1.Nodes["nInitConfig"].Nodes.Add("nCpBankView", "ข้อมูลสมุดบัญชีธนาคาร");
            tv1.Nodes["nInitConfig"].Nodes.Add("nPassword", "เปลี่ยนรหัสผ่าน");
            tv1.Nodes["nInitConfig"].Nodes.Add("nBankView", "ข้อมูลธนาคาร");
            tv1.Nodes["nInitConfig"].Nodes.Add("nPrefixView", "คำนำหน้าชื่อ");
            tv1.Nodes["nInitConfig"].Nodes.Add("nInitConfig", "กำหนดค่าโปรแกรม");
            //}

            tv1.ExpandAll();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Last Update " + System.IO.File.GetLastWriteTime(System.Environment.CurrentDirectory + "\\" + Process.GetCurrentProcess().ProcessName + ".exe");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frm != null)
            {
                frm.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void tv1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.ToString() == "nQuotationView")
            {
                FrmQuotationView frm = new FrmQuotationView(sf.Id,cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nQuoConfirmView")
            {
                FrmQuoConfirmView frm = new FrmQuoConfirmView(sf.Id, cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nMOUView")
            {
                FrmMOUView frm = new FrmMOUView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInputResult")
            {
                FrmResultView frm = new FrmResultView(sf.Id, cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nBillView")
            {
                FrmInvoiceView frm = new FrmInvoiceView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nCompany")
            {
                FrmCompany frm = new FrmCompany(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nCustomerView")
            {
                FrmCustView frm = new FrmCustView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nStaffView")
            {
                FrmStaffView frm = new FrmStaffView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nItemView")
            {
                FrmItemView frm = new FrmItemView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nMethodView")
            {
                FrmMethodView frm = new FrmMethodView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nTest")
            {
                FrmReport frm = new FrmReport(null);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nItemGroupView")
            {
                FrmItemGroupView frm = new FrmItemGroupView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nPOView")
            {
                FrmPOView frm = new FrmPOView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInitConfig")
            {
                FrmInitConfig frm = new FrmInitConfig(sf.Code, cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nAnalysisView")
            {
                FrmAnalysisView frm = new FrmAnalysisView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nAPView")
            {
                FrmAP frm = new FrmAP();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nARView")
            {
                FrmAR frm = new FrmAR();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nCpBankView")
            {
                FrmAR frm = new FrmAR();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nBankView")
            {
                FrmBankView frm = new FrmBankView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nPrefixView")
            {
                FrmStaffPrefixView frm = new FrmStaffPrefixView(cc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nQuotationReport")
            {
                //FrmQuotationReport frm = new FrmQuotationReport(cc);
                //showFrame(frm);
            }
        }
    }
}
