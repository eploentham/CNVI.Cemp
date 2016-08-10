using Cemp.Control;
using Cemp.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*
 * 57.12.09.01  อุยแจ้งว่า อยากให้โปรแกรมสามารถแก้ไข การเรียงข้อมูลในใบเสนอราคาให้
 * 57.12.09.03  อุยแจ้งว่า ตรงเบอร์โทรขอพนักงาน ให้แสดงเป็นเบอร์ มือถือ
 * 57.12.17.01 
 * 57.12.19.01  Bug พอแก้ไข แล้วจะเป็นการเพิ่ม record ใหม่
 * 58.01.13.01  คุณกรณ์ แจ้งขอแก้ไข     หน้าView ให้กรองปี
 * 58.01.13.02  เปาแจ้งว่า หน้าจอใบเสนอราคา อยากให้สามารถcopy จากใบเสนอราคาใบอื่น มาใช้งานได้
 * 59.07.29.01  คุณกรณ์แจ้งว่า save ไม่แสดง แต่check ดูแล้ว เลขที่เอกสาร "000" เต็ม แก้ไข เพิ่ม "0000" คิดว่าพอ
 * 59.08.09.01  คุณกรณ์ แจ้งแก้ไข เพิ่มการค้นหา
 * */

namespace Cemp.gui
{
    public partial class FrmQuotationAdd : Form
    {
        CnviControl cc;
        Quotation qu;
        Company cp;
        int colRow = 0, colItemCode=1, colItem = 2, colMethod = 3, colQty = 4, colPriceCost=5, colPriceSale = 6, colAmount = 7, colId=8, colDel=9, colItemId=10, colMethodId=11, colEdit=12;
        int colCnt = 13;
        String oldNetTotal = "";
        Boolean pageLoad = false, flagViewCost = false, flagNewCopy = false;
        //NumberFormat fmt = NumberFormat.getCurrencyInstance();
        public FrmQuotationAdd(String quId, Boolean flagViewCost1, Boolean flagNewCopy1, CnviControl c)
        {            
            InitializeComponent();
            label41.Text = System.DateTime.Now.ToLongTimeString();
            cc = c;
            flagViewCost=flagViewCost1;
            flagNewCopy = flagNewCopy1;
            initConfig(quId);
            label42.Text = System.DateTime.Now.ToLongTimeString();
        }
        private void initConfig(String quId)
        {
            //String ll = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
            //cc.lw.WriteLog("FrmQuotationAdd initConfig Start");
            pageLoad = true;
            //cc = c;
            qu = new Quotation();
            cp = cc.cpdb.selectByPk();
            txtVatRate.Text = cp.vat;
            dtpDateQu.Format = DateTimePickerFormat.Short;
            cboComp = cc.cpdb.getCboCompany(cboComp);
            cboCust = cc.cudb.getCboCustomer(cboCust);
            cboStaff = cc.sfdb.getCboStaff(cboStaff);
            cboStaffApprove = cc.sfdb.getCboStaff(cboStaffApprove);
            setControl(quId);
            setGrd(quId);
            calAmountcost();
            pageLoad = false;
            txtItemAmount.ReadOnly = true;
            txtRow.ReadOnly = true;
            //dgvAdd.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtAmountDiscount.ReadOnly = true;
            txtVatRate.ReadOnly = true;
            txtVat.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtNetTotal.ReadOnly = true;
            txtAmountCost.ReadOnly = true;
            //String lll = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
            txtAmountCost.Visible = flagViewCost;
            //cc.lw.WriteLog("FrmQuotationAdd initConfig End " + ll + " " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
        }
        private void setResize()
        {
            dgvAdd.Width = this.Width - 80;
            //groupBox3.Left = dgvAdd.Width - groupBox3.Width - 50;
            btnSave.Left = dgvAdd.Width - 80;
            btnDoc.Left = btnSave.Left;
            btnPrint.Left = btnSave.Left;
            btnPrintT.Left = btnSave.Left;
            btnCalEx.Left = btnSave.Left;
            groupBox2.Left = this.Width - groupBox2.Width - btnSave.Width - 150;
            groupBox3.Left = groupBox2.Left;
            //groupBox1.Height = this.Height = 150;
        }
        private void setControl(String quId)
        {
            qu = cc.qudb.selectByPk(quId);
            
            cboRemark1 = cc.qudb.getCboRemark1(cboRemark1);
            cboRemark2 = cc.qudb.getCboRemark2(cboRemark2);
            cboRemark3 = cc.qudb.getCboRemark3(cboRemark3);
            cboRemark4 = cc.qudb.getCboRemark4(cboRemark4);
            cboRemark5 = cc.qudb.getCboRemark5(cboRemark5);
            cboRemark6 = cc.qudb.getCboRemark6(cboRemark6);
            cboRemark7 = cc.qudb.getCboRemark7(cboRemark7);

            //cboItem = cc.itdb.getCboItemQuotation(cboItem);
            cboItem = cc.itdb.getCboItemByList(cboItem, cc.lit);

            //cboItemGroup = cc.itgdb.getCboItemGroup(cboItemGroup);
            cboItemGroup = cc.itgdb.getCboItemGroupByList(cboItemGroup,cc.litg);
            //cboMethod = cc.medb.getCboMethod(cboMethod);

            cboContact.Text = qu.ContactName;
            txtAmount.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.Amount)));
            txtAmountDiscount.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.AmountDiscount)));
            txtCompAddress1.Text = qu.CompAddress1;
            txtCompAddress2.Text = qu.CompAddress2;
            txtCompTaxId.Text = qu.CompTaxId;
            txtCompId.Text = qu.CompId;
            cboComp.Text = qu.CompName;
            txtCustAddress.Text = qu.CustAddress;
            txtCustEmail.Text = qu.CustEmail;
            txtCustFax.Text = qu.CustFax;
            txtCustTel.Text = qu.CustTel;
            cboCust.Text = qu.CustName;
            txtCustId.Text = qu.CustId;
            txtDiscount.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.Discount)));
            txtNetTotal.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.NetTotal)));
            txtPlus1.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.Plus1)));
            if (flagNewCopy)
            {
                txtQuId.Text = "";
                dtpDateQu.Value = DateTime.Now;
            }
            else
            {
                txtQuId.Text = qu.Id;
                txtQuNumber.Text = qu.QuoNumber + "-" + qu.QuoNumberCnt;
                cboStaffApprove.Text = qu.StaffApproveName;
                txtStaffApproveId.Text = qu.StaffApproveId;
                txtStaffEmail.Text = qu.StaffEmail;
                txtStaffTel.Text = qu.StaffTel;
                txtStaffId.Text = qu.StaffId;
                cboStaff.Text = qu.StaffName;
                try
                {
                    if (!qu.QuoDate.Equals(""))
                    {
                        dtpDateQu.Value = DateTime.Parse(cc.cf.dateDBtoShow1(qu.QuoDate));
                    }
                    else
                    {
                        dtpDateQu.Value = DateTime.Now;
                    }

                }
                catch (Exception ex)
                {
                    dtpDateQu.Value = DateTime.Parse(cc.cf.dateDBtoShow(qu.QuoDate));
                }
            }
            
            
            
            txtTotal.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.Total)));
            txtVat.Text = String.Format("{0:#,###,###.00}",double.Parse(cc.cf.NumberNull1(qu.Vat)));
            txtVatRate.Text = qu.VatRate;
            

            //txtLine1.Text = qu.Line1;
            txtLine2.Text = qu.Line2;
            //txtLine3.Text = qu.Line3;
            txtLine4.Text = qu.Line4;
            txtLine5.Text = qu.Line5;
            txtLine6.Text = qu.Line6;

            //txtVatRate.Text = qu.VatRate;
            cboRemark1.Text = qu.Remark1;
            cboRemark2.Text = qu.Remark2;
            cboRemark3.Text = qu.Remark3;
            cboRemark4.Text = qu.Remark4;
            cboRemark5.Text = qu.Remark5;
            cboRemark6.Text = qu.Remark6;
            cboRemark7.Text = qu.Remark7;            

            if (qu.Id.Equals(""))
            {
                if (cboComp.Items.Count == 1)
                {
                    cboComp.Text = cp.NameT;
                    txtCompId.Text = cp.Id;
                    txtCompAddress1.Text = cp.AddressT;
                    txtCompAddress2.Text = "TEL. "+cp.Tele+" FAX. "+cp.Fax+" Email : "+cp.Email;
                    txtCompTaxId.Text = cp.Spec1+" เลขประจำตัวผู้เสียภาษีอากร"+cp.TaxId;
                    txtVatRate.Text = cp.vat;
                }
                //txtLine1.Text = cc.initC.quoLine1;
                txtLine2.Text = cc.cp.quLine2;
                //txtLine3.Text = cc.initC.quoLine3;
                txtLine4.Text = cc.cp.quLine4;
                txtLine5.Text = cc.cp.quLine5;
                txtLine6.Text = cc.cp.quLine6;

                btnPrint.Visible = false;
            }
            else
            {
                btnPrint.Visible = true;
            }
            
            txtQuNumber.ReadOnly = true;
            txtPriceCost.ReadOnly = true;
            oldNetTotal = qu.NetTotal;
            btnUnActive.Visible = false;
            chkActive.Checked = true;
        }
        private void getQuotation()
        {
            qu.Amount = txtAmount.Text.Replace(",", "");
            qu.AmountDiscount = txtAmountDiscount.Text.Replace(",", "");
            qu.CompAddress1 = txtCompAddress1.Text;
            qu.CompAddress2 = txtCompAddress2.Text;
            qu.CompTaxId = txtCompTaxId.Text;
            qu.CompId = txtCompId.Text;
            qu.CompName = cboComp.Text;
            qu.CustAddress = txtCustAddress.Text;
            qu.CustEmail = txtCustEmail.Text;
            qu.CustFax = txtCustFax.Text;
            qu.CustTel = txtCustTel.Text;
            qu.CustName = cboCust.Text;
            qu.CustId = txtCustId.Text;
            qu.Discount = txtDiscount.Text.Replace(",", "");
            qu.NetTotal = txtNetTotal.Text.Replace(",", "");
            qu.Plus1 = txtPlus1.Text.Replace(",", "");
            qu.Id = txtQuId.Text;
            qu.QuoNumber = txtQuNumber.Text;
            qu.StaffEmail = txtStaffEmail.Text;
            qu.StaffTel = txtStaffTel.Text;
            qu.StaffId = cc.getValueCboItem(cboStaff);
            qu.StaffName = cboStaff.Text;
            qu.Total = txtTotal.Text.Replace(",","");
            qu.Vat = txtVat.Text.Replace(",", "");
            qu.VatRate = txtVatRate.Text;
            qu.StaffApproveName = cboStaffApprove.Text;
            qu.StaffApproveId = cc.getValueCboItem(cboStaffApprove);
            qu.Active = "1";
            qu.Remark1 = cboRemark1.Text;
            qu.Remark2 = cboRemark2.Text;
            qu.Remark3 = cboRemark3.Text;
            qu.ContactName = cboContact.Text;
            qu.QuoDate = cc.cf.datetoDB(dtpDateQu.Value);

            //qu.Line1 = txtLine1.Text;
            qu.Line2 = txtLine2.Text;
            qu.Line3 = cp.quLine3;
            qu.Line4 = txtLine4.Text;
            qu.Line5 = txtLine5.Text;
            qu.Line6 = txtLine6.Text;

            qu.Remark4 = cboRemark4.Text;
            qu.Remark5 = cboRemark5.Text;
            qu.Remark6 = cboRemark6.Text;
            qu.Remark7 = cboRemark7.Text;
            //qu.StatusQuo = "1";
            qu.userCreate = cc.sf.Id;
            qu.userModi = cc.sf.Id;

            qu.YearId = dtpDateQu.Value.Year.ToString();       //58.01.13.01 +
        }
        private void setGrd(String quId)
        {
            DataTable dt = cc.quidb.selectByQuId(quId);
            //DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
            //newColumn.Name = "abc";
            //newColumn.DataSource = new string[] { "a", "b", "c" };
            //newColumn.ReadOnly = false;

            //DataTable dt = new DataTable();
            //dt = cc.sfdb.selectAll();
            dgvAdd.Rows.Clear();
            dgvAdd.ColumnCount = colCnt;

            dgvAdd.RowCount = dt.Rows.Count + 1;
            dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdd.Columns[colRow].Width = 50;
            dgvAdd.Columns[colItem].Width = 250;
            dgvAdd.Columns[colMethod].Width = 250;
            dgvAdd.Columns[colQty].Width = 120;
            dgvAdd.Columns[colPriceSale].Width = 150;
            dgvAdd.Columns[colAmount].Width = 180;

            dgvAdd.Columns[colRow].HeaderText = "ลำดับ";
            dgvAdd.Columns[colItemCode].HeaderText = "CODE";
            dgvAdd.Columns[colItem].HeaderText = "Parameter";
            dgvAdd.Columns[colMethod].HeaderText = "Method";
            dgvAdd.Columns[colQty].HeaderText = "QTY";
            dgvAdd.Columns[colPriceCost].HeaderText = "Cost";
            dgvAdd.Columns[colPriceSale].HeaderText = "Price";
            dgvAdd.Columns[colAmount].HeaderText = "Amount";
            dgvAdd.Columns[colId].HeaderText = "  ";

            dgvAdd.Columns[colQty].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAdd.Columns[colPriceSale].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAdd.Columns[colAmount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvAdd.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvAdd.Font = font;
            dgvAdd.Columns[colId].Visible = false;
            dgvAdd.Columns[colDel].Visible = false;
            dgvAdd.Columns[colItemId].Visible = false;
            dgvAdd.Columns[colMethodId].Visible = false;
            dgvAdd.Columns[colEdit].Visible = false;

            dgvAdd.Columns[colPriceCost].Visible = flagViewCost;
            dgvAdd.Columns[colItemCode].ReadOnly = true;
            dgvAdd.Columns[colPriceCost].ReadOnly = true;
            dgvAdd.Columns[colPriceSale].ReadOnly = true;
            dgvAdd.Columns[colAmount].ReadOnly = true;
            dgvAdd.Columns[colQty].ReadOnly = true;
            //dgvAdd.Columns[colRow].ReadOnly = true;       //57.12.09.01

            //dgvAdd.Columns.Add(newColumn);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //dgvAdd.Rows[0].Cells = newColumn;
                    //DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(dgvAdd.Rows[i].Cells[colItem]);
                    //cell.DataSource = newColumn;

                    //dgvAdd[colRow, i].Value = (i + 1);    //57.12.09.01 -
                    dgvAdd[colRow, i].Value = dt.Rows[i][cc.quidb.qui.RowNumber].ToString();//57.12.09.01 +
                    dgvAdd[colItemCode, i].Value = dt.Rows[i][cc.quidb.qui.ItemCode].ToString();
                    dgvAdd[colItem, i].Value = dt.Rows[i][cc.quidb.qui.ItemDescription].ToString();
                    dgvAdd[colMethod, i].Value = dt.Rows[i][cc.quidb.qui.MethodDescription].ToString();
                    dgvAdd[colQty, i].Value = dt.Rows[i][cc.quidb.qui.Qty].ToString();
                    dgvAdd[colPriceCost, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.quidb.qui.PriceCost]);
                    dgvAdd[colPriceSale, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.quidb.qui.PriceSale]);
                    if (dt.Rows[i][cc.quidb.qui.StatusPrice].ToString().Equals("2"))
                    {
                        dgvAdd[colAmount, i].Value = "ฟรี";
                    }
                    else
                    {
                        dgvAdd[colAmount, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.quidb.qui.Amount]);
                    }
                    
                    dgvAdd[colItemId, i].Value = dt.Rows[i][cc.quidb.qui.ItemId].ToString();
                    dgvAdd[colMethodId, i].Value = dt.Rows[i][cc.quidb.qui.MethodId].ToString();
                    dgvAdd[colId, i].Value = dt.Rows[i][cc.quidb.qui.Id].ToString();
                    dgvAdd[colDel, i].Value = "";
                    dgvAdd[colEdit, i].Value = "";
                    if ((i % 2) != 0)
                    {
                        //dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        dgvAdd.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(cc.initC.grdQuoColor);//59.08.09.01 +
                    }
                }
            }
        }
        private void calDiscount()
        {
            Double amt = 0, disCountPer=0, discount=0;
            amt = Double.Parse(cc.cf.NumberNull1(txtAmount.Text.Replace(",", "")));
            disCountPer = Double.Parse(cc.cf.NumberNull1(txtDiscountPer.Text.Replace(",", "")));
            discount = (amt * disCountPer) / 100;
            txtDiscount.Text = String.Format("{0:#,###,###.00}", discount);

            calNetTotal();
        }
        /*
         * ทำเพื่อแก้ไข Bug เพราะไม่ได้เพิ่ม Field amount_cost ใน table t_quotation
         */
        private void calAmountcost()
        {
            Double amt = 0, amtCost = 0;
            String amt1 = "";
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                if (dgvAdd[colAmount, i].Value == null)
                {
                    continue;
                }
                if (dgvAdd[colAmount, i].Value.ToString().Equals(""))
                {
                    continue;
                }
                if (!dgvAdd[colDel, i].Value.ToString().Equals("1"))
                {
                    //amt += Double.Parse(cc.cf.NumberNull1(dgvAdd[colAmount, i].Value.ToString().Replace(",", "")));
                    amtCost += (Double.Parse(cc.cf.NumberNull1(dgvAdd[colPriceCost, i].Value.ToString().Replace(",", ""))) *
                        Double.Parse(cc.cf.NumberNull1(dgvAdd[colQty, i].Value.ToString().Replace(",", ""))));
                }
            }
            //txtAmount.Text = String.Format("{0:#,###,###.00}", amt);
            txtAmountCost.Text = String.Format("{0:#,###,###.00}", amtCost);
        }
        private void calAmount()
        {
            Double amt = 0, amtCost=0;
            String amt1 = "";
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                if (dgvAdd[colAmount, i].Value==null)
                {
                    continue;
                }
                if (dgvAdd[colAmount, i].Value.ToString().Equals(""))
                {
                    continue;
                }
                if (!dgvAdd[colDel, i].Value.ToString().Equals("1"))
                {
                    try
                    {
                        amt += Double.Parse(cc.cf.NumberNull1(dgvAdd[colAmount, i].Value.ToString().Replace(",", "")));
                        amtCost += (Double.Parse(cc.cf.NumberNull1(dgvAdd[colPriceCost, i].Value.ToString().Replace(",", ""))) *
                            Double.Parse(cc.cf.NumberNull1(dgvAdd[colQty, i].Value.ToString().Replace(",", ""))));
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }
            }
            txtAmount.Text = String.Format("{0:#,###,###.00}", amt);
            txtAmountCost.Text = String.Format("{0:#,###,###.00}", amtCost);
        }
        private void calNetTotal()
        {
            Double amt = 0, amtDis=0,total=0,netTotal=0, vat=0, plus=0;
            amt = Double.Parse(cc.cf.NumberNull1(txtAmount.Text.Replace(",", "")));
            amtDis = amt - Double.Parse(cc.cf.NumberNull1(txtDiscount.Text.Replace(",", "")));
            total = amtDis + Double.Parse(cc.cf.NumberNull1(txtPlus1.Text.Replace(",", "")));
            vat = (total * Double.Parse(cc.cf.NumberNull1(txtVatRate.Text.Replace(",", ""))) / 100);
            netTotal = total + vat;
            txtPlus1.Text = String.Format("{0:#,###,###.00}", Double.Parse(cc.cf.NumberNull1(txtPlus1.Text)));
            txtAmountDiscount.Text = String.Format("{0:#,###,###.00}", amtDis);
            txtTotal.Text = String.Format("{0:#,###,###.00}", total);
            txtVat.Text = String.Format("{0:#,###,###.00}", vat);
            txtNetTotal.Text = String.Format("{0:#,###,###.00}", netTotal);
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.F1:
                    // ... Process Shift+Ctrl+Alt+B ...
                    //Cursor cursor = Cursor.Current;
                    //Cursor.Current = Cursors.WaitCursor;
                    //btnSave.Enabled = false;
                    ////saveLotto();
                    ////row = 0;
                    //btnSave.Enabled = true;
                    //Cursor.Current = cursor;
                    cc.itSearch.PriceSale="";
                    cc.itSearch.userCancel = "";
                    cc.itSearch.Id = "";
                    FrmItemSearch frm = new FrmItemSearch(cc);
                    frm.ShowDialog(this);
                    if (!cc.itSearch.userCancel.Equals(""))
                    {
                        txtRow.Text = "";
                        //cboItem.Text = cc.itSearch.Code + " " + cc.itSearch.NameT + "[" + cc.itSearch.MethodNameT+"]";
                        txtItemPrice.Text = cc.itSearch.PriceSale;
                        txtPriceCost.Text = cc.itSearch.PriceCost;
                        txtItemQty.Text = cc.itSearch.userCancel;
                        calItemAmount();
                        setItemtoGrd(cc.itSearch.Id, getRow());
                    }
                    
                    //calItemAmount();
                    //btnAdd_Click(null,null);
                    return true; // signal that we've processed this key
                //case Keys.Insert:
                //    //txtInputFocus();
                //    return true;
            }
            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }
        private void FrmQuotationAdd_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuotationAdd_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean chkdel = false;
            String quId = "";
            if (!flagNewCopy)           //58.01.13.02 +
            {
                if (txtQuNumber.Text.Equals(""))
                {
                    MessageBox.Show("ไม่มีเลขที่ Quotation", "ป้อนข้อมูลไม่ครบ");
                    return;
                }
            }
            
            if (cboComp.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ชื่อบริษัท", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboCust.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ชื่อลูกค้า", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboContact.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ชื่อผู้ติดต่อ", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboStaff.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ชื่อผู้เสนอราคา", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboStaffApprove.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ชื่อผู้อนุมัติ", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            //if (txtStaffCode.Text.Equals(""))
            //{
            //    MessageBox.Show("ไม่ได้ป้อนรหัส", "ป้อนข้อมูลไม่ครบ");
            //    return;
            //}
            //if (txtQuNumber.Text.Equals(""))
            //{
            //    qu = cc.qudb.selectByNumber(txtQuNumber.Text);
            //    if (!qu.Id.Equals(""))
            //    {
            //        MessageBox.Show("ป้อนรหัสซ้ำ\nรหัส " + qu.QuoNumber + " ชื่อ " + s.NameT, "รหัสซ้ำ");
            //        return;
            //    }
            //    if (!s.Code.Equals(""))
            //    {
            //        MessageBox.Show("ป้อนชื่อซ้ำ\nรหัส " + s.Code + " ชื่อ " + s.NameT, "ชื่อซ้ำ");
            //        return;
            //    }
            //}
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            getQuotation();
            if (qu.Id.Equals(""))
            {
                qu.QuoNumber = cc.qudb.getQuoNumber("");
                String[] doc1 = qu.QuoNumber.Split('-');
                qu.QuoNumber = doc1[0];
                qu.QuoNumberCnt = doc1[1];
            }
            else
            {
                String[] doc1 = qu.QuoNumber.Split('-');
                qu.QuoNumber = doc1[0];
                //if (qu.NetTotal.Equals(oldNetTotal))
                //{
                qu.QuoNumberCnt = doc1[1];
                //}
                //else
                //{
                //    qu.QuoNumberCnt = String.Concat(int.Parse(doc1[1])+1);
                //}
            }
            quId = cc.qudb.insertQuotation(qu);
            if (quId.Length >= 1)
            {
                for (int i = 0; i < dgvAdd.RowCount; i++)
                {
                    
                    if (dgvAdd[colAmount, i].Value == null)
                    {
                        continue;
                    }
                    if (dgvAdd[colAmount, i].Value.ToString().Equals(""))
                    {
                        continue;
                    }
                    if (dgvAdd[colItemId, i].Value.ToString().Equals(""))
                    {
                        continue;
                    }
                    if (!flagNewCopy)       //58.01.13.02 +
                    {
                        if (dgvAdd[colEdit, i].Value.ToString().Equals(""))
                        {
                            continue;
                        }
                    }
                    QuotationItem qui = new QuotationItem();
                    //Item it = cc.itdb.selectByPk(dgvAdd[colItemId, i].Value.ToString());
                    //ItemGroup itg = cc.itgdb.selectByPk(it.ItemGroupId);
                    Item it = cc.getItemByList(dgvAdd[colItemId, i].Value.ToString());
                    ItemGroup itg = cc.getItemGroupByList(it.ItemGroupId);

                    qui.RowNumber = dgvAdd[colRow, i].Value.ToString();//57.12.09.01 +
                    qui.ItemCode = it.Code;
                    qui.PriceSale = cc.cf.NumberNull1(dgvAdd[colPriceSale, i].Value.ToString());
                    //qui.PriceCost = cc.cf.NumberNull1(dgvAdd[colPriceCost, i].Value.ToString());
                    qui.Qty = cc.cf.NumberNull1(dgvAdd[colQty, i].Value.ToString());
                    if (dgvAdd[colAmount, i].Value.ToString().Equals("ฟรี"))
                    {
                        qui.Amount = "0";
                    }
                    else
                    {
                        qui.Amount = cc.cf.NumberNull1(dgvAdd[colAmount, i].Value.ToString());
                    }
                    
                    qui.ItemDescription = dgvAdd[colItem, i].Value.ToString();
                    qui.MethodDescription = dgvAdd[colMethod, i].Value.ToString();
                    qui.ItemId = dgvAdd[colItemId, i].Value.ToString();
                    qui.MethodId = dgvAdd[colMethodId, i].Value.ToString();
                    if (dgvAdd[colId, i].Value == null)
                    {
                        qui.Id = "";
                    }
                    else
                    {
                        qui.Id = dgvAdd[colId, i].Value.ToString();
                    }
                    
                    qui.Active = "1";
                    qui.QuoId = quId;
                    qui.ItemGroupId = itg.Id;
                    qui.ItemGroupNameT = itg.NameT;
                    qui.ItemGroupNameE = itg.NameE;
                    qui.ItemGroupSort = itg.Sort1;
                    qui.PriceCost = cc.cf.NumberNull1(dgvAdd[colPriceCost, i].Value.ToString());
                    qui.ItemType = it.ItemType;
                    qui.StatusPrice = it.StatusPrice;
                    if (dgvAdd[colDel, i].Value.ToString().Equals("1"))
                    {
                        cc.quidb.VoidQuotationItem(dgvAdd[colId, i].Value.ToString());
                        chkdel = true;
                    }
                    else
                    {
                        cc.quidb.insertQuotationItem(qui);
                    }
                }
                Quotation qu1 = cc.qudb.selectByPk(quId);
                txtQuNumber.Text = qu1.QuoNumber+"-"+qu1.QuoNumberCnt;
                txtQuId.Text = quId;
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                setGrd(quId);
                //if (chkdel)
                //{
                //    delGrdDelete();
                //    calAmount();
                //    calNetTotal();
                //}
                
                btnPrint.Visible = true;
                //this.Dispose();
                //this.Hide();
            }
            Cursor.Current = cursor;
        }
        private void calItemAmount()
        {
            txtItemAmount.Text = String.Format("{0:#,###,###.00}", (Double.Parse(cc.cf.NumberNull1(txtItemQty.Text)) * Double.Parse(cc.cf.NumberNull1(txtItemPrice.Text))));
            //txtItemAmount.Text = String.Concat(Double.Parse(cc.cf.NumberNull1(txtItemQty.Text)) * Double.Parse(cc.cf.NumberNull1(txtItemPrice.Text)));
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                Customer cu = new Customer();
                cu = cc.cudb.selectByPk(cc.getValueCboItem(cboCust));
                txtCustId.Text = cu.Id;
                txtCustAddress.Text = cu.AddressT;
                txtCustEmail.Text = cu.Email;
                txtCustFax.Text = cu.Fax;
                txtCustTel.Text = cu.Tele+" , "+cu.Mobile;
                cboContact.Text = cu.ContactName1;
            }
        }
        private void clearItem()
        {
            txtRow.Text = "";
            txtItemQty.Text = "";
            txtItemPrice.Text = "";
            txtPriceCost.Text = "";
            cboItem.Text = "";
            txtItemAmount.Text = "";
        }
        private void setItemtoGrd(String itId, int row)
        {
            Item it = new Item();
            //it = cc.itdb.selectByPk(itId);      //57.12.19.01 -
            it = cc.getItemByList(itId);        //57.12.19.01 +
            if (it.Id.Equals(""))
            {
                return;
            }
            //if (row >= dgvAdd.RowCount)
            //{
            //    return;
            //}
            dgvAdd[colRow, row].Value = (row + 1);
            dgvAdd[colItemCode, row].Value = it.Code;
            dgvAdd[colItemId, row].Value = it.Id;
            dgvAdd[colMethodId, row].Value = it.MethodId;
            dgvAdd[colItem, row].Value = it.NameT;
            dgvAdd[colMethod, row].Value = it.MethodNameT;
            dgvAdd[colQty, row].Value = String.Format("{0:#,###,###.00}", txtItemQty.Text);
            dgvAdd[colPriceSale, row].Value = String.Format("{0:#,###,###.00}", Double.Parse(cc.cf.NumberNull1(txtItemPrice.Text)));
            dgvAdd[colPriceCost, row].Value = String.Format("{0:#,###,###.00}", Double.Parse(cc.cf.NumberNull1(txtPriceCost.Text)));
            if (it.StatusPrice.Equals("2"))
            {
                dgvAdd[colAmount, row].Value = "ฟรี";
            }
            else
            {
                dgvAdd[colAmount, row].Value = String.Format("{0:#,###,###.00}", txtItemAmount.Text);
            }
            //dgvAdd[colId, row].Value = "";          //57.12.19.01 -
            dgvAdd[colDel, row].Value = "";
            dgvAdd[colEdit, row].Value = "1";
            if ((row % 2) != 0)
            {
                dgvAdd.Rows[row].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
            dgvAdd.FirstDisplayedScrollingRowIndex = row;
            calAmount();
            calNetTotal();

            clearItem();
        }
        private int getRow()
        {
            int row = 0;

            if (txtRow.Text.Equals(""))
            {
                row = dgvAdd.Rows.Add(1);
            }
            else
            {
                try
                {
                    row = int.Parse(txtRow.Text) - 1;
                    dgvAdd.Rows[row].DefaultCellStyle.BackColor = Color.DeepPink;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่พบข้อมูล ลำดับ", "Error");
                    //return;
                }
            }
            return row;
        }
        private void delGrdDelete()
        {
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                if (dgvAdd[colDel, i].Value == null)
                {
                    continue;
                }
                if (dgvAdd[colDel, i].Value.ToString().Equals("1"))
                {
                    dgvAdd.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setItemtoGrd(cc.getValueCboItem(cboItem), getRow());
        }

        private void dgvAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pageLoad = true;
            if (dgvAdd[colRow, e.RowIndex].Value == null)
            {
                return;
            }
            txtRow.Text = dgvAdd[colRow, e.RowIndex].Value.ToString();
            txtItemPrice.Text = dgvAdd[colPriceSale, e.RowIndex].Value.ToString();
            txtItemQty.Text = dgvAdd[colQty, e.RowIndex].Value.ToString();
            txtItemAmount.Text = dgvAdd[colAmount, e.RowIndex].Value.ToString();
            cboItem.SelectedItem = cc.setCboItem(cboItem, dgvAdd[colItemId, e.RowIndex].Value.ToString());
            txtPriceCost.Text = dgvAdd[colPriceCost, e.RowIndex].Value.ToString();
            //cboMethod.Text = dgvAdd[colMethod, e.RowIndex].Value.ToString();
            pageLoad = false;
        }

        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            calItemAmount();
            btnAdd.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtRow.Text.Equals(""))
            {
                return;
            }
            dgvAdd[colDel, (int.Parse(txtRow.Text)-1)].Value = "1";
            dgvAdd[colEdit, (int.Parse(txtRow.Text) - 1)].Value = "1";
            dgvAdd.Rows[(int.Parse(txtRow.Text)-1)].DefaultCellStyle.BackColor = Color.DarkGray;
            calAmount();
            calNetTotal();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            calNetTotal();
        }

        private void txtPlus1_Leave(object sender, EventArgs e)
        {
            calNetTotal();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            FrmItemAdd frm = new FrmItemAdd("", cc);
            frm.ShowDialog(this);
            //cboItem = cc.itdb.getCboItemQuotation(cboItem);
            cboItem = cc.itdb.getCboItemByList(cboItem, cc.lit);
        }

        private void cboComp_Enter(object sender, EventArgs e)
        {
            cboComp.BackColor = Color.LightYellow;
        }

        private void cboComp_Leave(object sender, EventArgs e)
        {
            cboComp.BackColor = Color.White;
        }

        private void txtCompAddress1_Enter(object sender, EventArgs e)
        {
            txtCompAddress1.BackColor = Color.LightYellow;
        }

        private void txtCompAddress1_Leave(object sender, EventArgs e)
        {
            txtCompAddress1.BackColor = Color.White;
        }

        private void txtCompAddress2_Enter(object sender, EventArgs e)
        {
            txtCompAddress2.BackColor = Color.LightYellow;
        }

        private void txtCompAddress2_Leave(object sender, EventArgs e)
        {
            txtCompAddress2.BackColor = Color.White;
        }

        private void txtCompTaxId_Enter(object sender, EventArgs e)
        {
            txtCompTaxId.BackColor = Color.LightYellow;
        }

        private void txtCompTaxId_Leave(object sender, EventArgs e)
        {
            txtCompTaxId.BackColor = Color.White;
        }

        private void cboCust_Enter(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.LightYellow;
        }

        private void cboCust_Leave(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.White;
        }

        private void cboContact_Enter(object sender, EventArgs e)
        {
            cboContact.BackColor = Color.LightYellow;
        }

        private void cboContact_Leave(object sender, EventArgs e)
        {
            cboContact.BackColor = Color.White;
        }

        private void txtCustAddress_Enter(object sender, EventArgs e)
        {
            txtCustAddress.BackColor = Color.LightYellow;
        }

        private void txtCustAddress_Leave(object sender, EventArgs e)
        {
            txtCustAddress.BackColor = Color.White;
        }

        private void txtCustTel_Enter(object sender, EventArgs e)
        {
            txtCustTel.BackColor = Color.LightYellow;
        }

        private void txtCustTel_Leave(object sender, EventArgs e)
        {
            txtCustTel.BackColor = Color.White;
        }

        private void txtCustFax_Enter(object sender, EventArgs e)
        {
            txtCustFax.BackColor = Color.LightYellow;
        }

        private void txtCustFax_Leave(object sender, EventArgs e)
        {
            txtCustFax.BackColor = Color.White;
        }

        private void txtCustEmail_Enter(object sender, EventArgs e)
        {
            txtCustEmail.BackColor = Color.LightYellow;
        }

        private void txtCustEmail_Leave(object sender, EventArgs e)
        {
            txtCustEmail.BackColor = Color.White;
        }

        private void cboItem_Enter(object sender, EventArgs e)
        {
            cboItem.BackColor = Color.LightYellow;
        }

        private void cboItem_Leave(object sender, EventArgs e)
        {
            cboItem.BackColor = Color.White;
        }

        private void txtItemQty_Enter(object sender, EventArgs e)
        {
            txtItemQty.BackColor = Color.LightYellow;
        }

        private void txtItemQty_Leave(object sender, EventArgs e)
        {
            txtItemQty.BackColor = Color.White;
            calItemAmount();
        }

        private void txtItemPrice_Enter(object sender, EventArgs e)
        {
            txtItemPrice.BackColor = Color.LightYellow;
        }

        private void cboRemark1_Enter(object sender, EventArgs e)
        {
            cboRemark1.BackColor = Color.LightYellow;
        }

        private void cboRemark1_Leave(object sender, EventArgs e)
        {
            cboRemark1.BackColor = Color.White;
        }

        private void cboRemark2_Enter(object sender, EventArgs e)
        {
            cboRemark2.BackColor = Color.LightYellow;
        }

        private void cboRemark2_Leave(object sender, EventArgs e)
        {
            cboRemark2.BackColor = Color.White;
        }

        private void cboRemark3_Enter(object sender, EventArgs e)
        {
            cboRemark3.BackColor = Color.LightYellow;
        }

        private void cboRemark3_Leave(object sender, EventArgs e)
        {
            cboRemark3.BackColor = Color.White;
        }

        private void cboStaff_Enter(object sender, EventArgs e)
        {
            cboStaff.BackColor = Color.LightYellow;
        }

        private void cboStaff_Leave(object sender, EventArgs e)
        {
            cboStaff.BackColor = Color.White;
        }

        private void txtStaffTel_Enter(object sender, EventArgs e)
        {
            txtStaffTel.BackColor = Color.LightYellow;
        }

        private void txtStaffTel_Leave(object sender, EventArgs e)
        {
            txtStaffTel.BackColor = Color.White;
        }

        private void cboStaffApprove_Enter(object sender, EventArgs e)
        {
            cboStaffApprove.BackColor = Color.LightYellow;
        }

        private void cboStaffApprove_Leave(object sender, EventArgs e)
        {
            cboStaffApprove.BackColor = Color.White;
        }

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            txtDiscount.BackColor = Color.LightYellow;
        }

        private void txtPlus1_Enter(object sender, EventArgs e)
        {
            txtPlus1.BackColor = Color.LightYellow;
        }

        private void txtStaffEmail_Enter(object sender, EventArgs e)
        {
            txtStaffEmail.BackColor = Color.LightYellow;
        }

        private void txtStaffEmail_Leave(object sender, EventArgs e)
        {
            txtStaffEmail.BackColor = Color.White;
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                ////cboItem.DropDownStyle = ComboBoxStyle.
                //Item it = cc.itdb.selectByPk(cc.getValueCboItem(cboItem));
                //txtItemPrice.Text = it.PriceSale;
                //txtPriceCost.Text = it.PriceCost;
                //txtItemQty.Text = "1.00";
                //calItemAmount();
                //txtItemQty.SelectAll();
                //txtItemQty.Focus();
                //setFocusItemQty();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String sql = "";
            //OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = cc.qudb.selectPrintById1(txtQuId.Text);
            Quotation qu = cc.qudb.selectByPk(txtQuId.Text);
            qu.ContactName = "Attn : " + qu.ContactName;
            qu.CustAddress = "Address : " + qu.CustAddress;
            qu.CustTel = "Telephone : " + qu.CustTel + " Email : " + qu.CustEmail;
            qu.Line1 = "Quotation";
            qu.QuoNumber = "No : " + qu.QuoNumber+"-"+qu.QuoNumberCnt;
            qu.QuoDate = "Date : " + qu.QuoDate;
            qu.StaffName = "ผู้เสนอราคา :" + qu.StaffName;
            qu.StaffTel = "เบอร์โทร : " + qu.StaffTel;
            qu.StaffEmail = "Email : " + qu.StaffEmail;
            qu.Remark1 = "1. " + qu.Remark1;
            qu.Remark2 = "2. " + qu.Remark2;
            qu.Remark3 = "3. " + qu.Remark3;
            //DataTable dtqu = cc.qudb.selectPrintById(txtQuId.Text);
            //DataTable dtqui = cc.quidb.selectByQuId(txtQuId.Text);
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtqu);
            //ds.Tables.Add(dtqui);
            //cc.conn.f
            //dat
            FrmReport frm = new FrmReport(cc);
            frm.setReportQuotation(qu,dt);
            frm.ShowDialog(this);
        }
        private void btnPrintT_Click(object sender, EventArgs e)
        {
            String sql = "";
            //OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = cc.quidb.selectByQuId(txtQuId.Text);
            Quotation qu = cc.qudb.selectByPk(txtQuId.Text);
            qu.ContactName = "เรียน : " + qu.ContactName;
            qu.CustAddress = "ที่อยู่ : " + qu.CustAddress;
            qu.CustTel = "เบอร์โทร : " + qu.CustTel + " Fax : " + qu.CustFax + " Email : " + qu.CustEmail;
            qu.Line1 = cc.cp.quLine1;
            qu.QuoNumber = "เลขที่ : " + qu.QuoNumber + "-" + qu.QuoNumberCnt;
            qu.QuoDate = "วันที่ :" + cc.cf.dateDBtoShow(qu.QuoDate);

            //qu.StaffName = "ผู้เสนอราคา  " + qu.StaffName+" ";
            qu.StaffTel = "เบอร์โทร : " + qu.StaffTel;
            qu.StaffEmail = "Email : " + qu.StaffEmail;
            //qu.Line4=qu.Line4;
            qu.Line5 = "Email : " + qu.Line5;
            if (!qu.Remark1.Equals(""))
            {
                qu.Remark1 = "1. " + qu.Remark1;
            }
            if (!qu.Remark2.Equals(""))
            {
                qu.Remark2 = "2. " + qu.Remark2;
            }
            if (!qu.Remark3.Equals(""))
            {
                qu.Remark3 = "3. " + qu.Remark3;
            }
            if (!qu.Remark4.Equals(""))
            {
                qu.Remark4 = "4. " + qu.Remark4;
            }
            if (!qu.Remark5.Equals(""))
            {
                qu.Remark5 = "5. " + qu.Remark5;
            }
            if (!qu.Remark6.Equals(""))
            {
                qu.Remark6 = "6. " + qu.Remark6;
            }
            if (!qu.Remark7.Equals(""))
            {
                qu.Remark7 = "7. " + qu.Remark7;
            }

            //qu.ThaiBaht = cc.ThaiBaht("11");
            qu.ThaiBaht = cc.ThaiBaht(qu.NetTotal);
            //qu.Amount = "รวมราคา " + qu.Amount;
            //qu.Discount = "ส่วนลด " + qu.Amount;
            //DataTable dtqu = cc.qudb.selectPrintById(txtQuId.Text);
            //DataTable dtqui = cc.quidb.selectByQuId(txtQuId.Text);
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtqu);
            //ds.Tables.Add(dtqui);
            //cc.conn.f
            //dat
            FrmReport frm = new FrmReport(cc);
            frm.setReportQuotation(qu, dt);
            frm.ShowDialog(this);
        }

        private void cboStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                Staff sf = cc.sfdb.selectByPk(cc.getValueCboItem(cboStaff));
                txtStaffEmail.Text = sf.Email;
                //txtStaffTel.Text = sf.Tele;   //57.12.09.03 -
                txtStaffTel.Text = sf.Mobile;   //57.12.09.03 +
            }
        }
        private void mnuCost_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvView.SelectedRows[0].Index.ToString(), "aaa");
            if (dgvAdd.SelectedRows[0].Index == -1)
            {
                return;
            }
            if (dgvAdd[colId, dgvAdd.SelectedRows[0].Index].Value == null)
            {
                return;
            }

            //FrmQuotationAdd frm = new FrmQuotationAdd(dgvAdd[colId, dgvAdd.SelectedRows[0].Index].Value.ToString(), true, cc);
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            //frm.ShowDialog(this);
            setGrd(txtQuId.Text);
        }
        private void dgvAdd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cc.sf.Priority.Equals("1"))
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem(" ดูข้อมูลต้นทุน"));
                m.MenuItems.Add(" ดูข้อมูลต้นทุน", new EventHandler(mnuCost_Click));
                int currentMouseOverRow = dgvAdd.HitTest(e.X, e.Y).RowIndex;

                m.Show(dgvAdd, new Point(e.X, e.Y));

            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;
                setEnable(true);
            }
        }
        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;
                setEnable(false);

            }
        }
        private void setEnable(Boolean enable1)
        {
            cboComp.Enabled = enable1;
            cboCust.Enabled = enable1;
            cboStaff.Enabled = enable1;
            cboStaffApprove.Enabled = enable1;
            cboRemark1.Enabled = enable1;
            cboRemark2.Enabled = enable1;
            cboRemark3.Enabled = enable1;
            cboRemark4.Enabled = enable1;
            cboRemark5.Enabled = enable1;
            cboRemark6.Enabled = enable1;
            cboRemark7.Enabled = enable1;
            cboItem.Enabled = enable1;
            cboItemGroup.Enabled = enable1;
            cboContact.Enabled = enable1;
            txtAmount.Enabled = enable1;
            txtAmountDiscount.Enabled = enable1;
            txtCompAddress1.Enabled = enable1;
            txtCompAddress2.Enabled = enable1;
            txtCompTaxId.Enabled = enable1;
            //txtCompId.Enabled = enable1;
            cboComp.Enabled = enable1;
            txtCustAddress.Enabled = enable1;
            txtCustEmail.Enabled = enable1;
            txtCustFax.Enabled = enable1;
            txtCustTel.Enabled = enable1;
            cboCust.Enabled = enable1;
            txtCustId.Enabled = enable1;
            txtDiscount.Enabled = enable1;
            txtNetTotal.Enabled = enable1;
            txtPlus1.Enabled = enable1;
            //txtQuId.Text = qu.Id;
            txtQuNumber.Enabled = enable1;
            txtStaffEmail.Enabled = enable1;
            txtStaffTel.Enabled = enable1;
            txtStaffId.Enabled = enable1;
            cboStaff.Enabled = enable1;
            txtTotal.Enabled = enable1;
            txtVat.Enabled = enable1;
            txtVatRate.Enabled = enable1;
            cboStaffApprove.Enabled = enable1;
            txtStaffApproveId.Enabled = enable1;

            txtLine2.Enabled = enable1;
            txtLine4.Enabled = enable1;
            txtLine5.Enabled = enable1;
            txtLine6.Enabled = enable1;

            //txtVatRate.Text = qu.VatRate;
            cboRemark1.Enabled = enable1;
            cboRemark2.Enabled = enable1;
            cboRemark3.Enabled = enable1;
            cboRemark4.Enabled = enable1;
            cboRemark5.Enabled = enable1;
            cboRemark6.Enabled = enable1;
            cboRemark7.Enabled = enable1;

            dtpDateQu.Enabled = enable1;
            txtDiscountPer.Enabled = enable1;
            btnPrint.Enabled = enable1;
            dgvAdd.Enabled = enable1;
            txtItemQty.Enabled = enable1;
            txtItemPrice.Enabled = enable1;
        }        

        private void txtDiscountPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDiscountPer_Leave(object sender, EventArgs e)
        {
            calDiscount();
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                cc.qudb.VoidQuotation(txtQuId.Text);
                this.Dispose();
            }
        }

        private void txtItemQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calItemAmount();
                setItemtoGrd(cc.getValueCboItem(cboItem), getRow());
            }
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            String[] doc1 =txtQuNumber.Text.Split('-');
            qu.QuoNumber = doc1[0];
            //if (qu.NetTotal.Equals(oldNetTotal))
            //{
            //    qu.QuoNumberCnt = doc1[1];
            //}
            //else
            //{
                qu.QuoNumberCnt = String.Concat(int.Parse(doc1[1]) + 1);
            //}
            if (cc.qudb.updateQuoNumberCnt(txtQuId.Text, qu.QuoNumberCnt).Equals("1"))
            {
                txtQuNumber.Text = qu.QuoNumber + "-" + qu.QuoNumberCnt;
                MessageBox.Show("update เลขที่เอกสารเรียบร้อย", "เลขที่เอกสาร");
            }
        }
        private void setFocusItemQty()
        {
            if (!pageLoad)
            {
                //cboItem.DropDownStyle = ComboBoxStyle.
                Item it = cc.itdb.selectByPk(cc.getValueCboItem(cboItem));
                txtItemPrice.Text = it.PriceSale;
                txtPriceCost.Text = it.PriceCost;
                txtItemQty.Text = "1.00";
                calItemAmount();
                txtItemQty.SelectAll();
                txtItemQty.Focus();
            }
        }
        private void cboItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setFocusItemQty();
            }
            else if (e.KeyCode == Keys.Down)
            {
                cboItem.DroppedDown = true;
            }
        }

        private void dgvAdd_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == colRow)
            {
                //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                dgvAdd[colEdit, e.RowIndex].Value = "1";
            }
        }

        private void btnCalEx_Click(object sender, EventArgs e)
        {
            FrmQuotationEx frm = new FrmQuotationEx(cc, txtQuId.Text,qu.QuExId);
            frm.ShowDialog(this);
            qu = cc.qudb.selectByPk(txtQuId.Text);
        }
    }
}
