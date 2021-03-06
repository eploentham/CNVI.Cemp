﻿using Cemp.Control;
using Cemp.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.gui
{
    public partial class FrmQuotationAdd1 : Form
    {
        CnviControl cc;
        Quotation qu;
        Company cp;
        int colRow = 0, colItem = 1, colMethod = 2, colQty = 3, colPrice = 4, colAmount = 5, colId=6, colDel=7;
        int colCnt = 8;
        String oldNetTotal = "";
        Boolean pageLoad = false;
        public FrmQuotationAdd1(String quId, CnviControl c)
        {
            InitializeComponent();
            initConfig(quId, c);
        }
        private void initConfig(String quId, CnviControl c)
        {
            pageLoad = true;
            cc = c;
            qu = new Quotation();
            cp = cc.cpdb.selectByPk();
            txtVatRate.Text = cp.vat;
            dtpDateQu.Format = DateTimePickerFormat.Short;
            setControl(quId);
            setGrd(quId);
            pageLoad = false;
            txtItemAmount.ReadOnly = true;
            txtRow.ReadOnly = true;
            dgvAdd.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtAmountDiscount.ReadOnly = true;
            txtVatRate.ReadOnly = true;
            txtVat.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtNetTotal.ReadOnly = true;
        }
        private void setResize()
        {
            dgvAdd.Width = this.Width - 80;
            //dgvAdd.Height = this.Height - 150;
            //btnAdd.Left = dgvView.Width + 20;
            //groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        private void setControl(String quId)
        {
            qu = cc.qudb.selectByPk(quId);
            cboComp = cc.cpdb.getCboCompany(cboComp);
            cboCust = cc.cudb.getCboCustomer(cboCust);
            cboStaff = cc.sfdb.getCboStaff(cboStaff);
            cboStaffApprove = cc.sfdb.getCboStaff(cboStaffApprove);
            cboRemark1 = cc.qudb.getCboRemark1(cboRemark1);
            cboRemark2 = cc.qudb.getCboRemark2(cboRemark2);
            cboRemark3 = cc.qudb.getCboRemark3(cboRemark3);
            cboItem = cc.quidb.getCboItemDescription(cboItem);
            cboMethod = cc.quidb.getCboMethodDescription(cboMethod);

            cboContact.Text = qu.ContactName;
            txtAmount.Text = qu.Amount;
            txtAmountDiscount.Text = qu.AmountDiscount;
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
            txtDiscount.Text = qu.Discount;
            txtNetTotal.Text = qu.NetTotal;
            txtPlus1.Text = qu.Plus1;
            txtQuId.Text = qu.Id;
            txtQuNumber.Text = qu.QuoNumber+"-"+qu.QuoNumberCnt;
            txtStaffEmail.Text = qu.StaffEmail;
            txtStaffTel.Text = qu.StaffTel;
            txtStaffId.Text = qu.StaffId;
            cboStaff.Text = qu.StaffName;
            txtTotal.Text = qu.Total;
            txtVat.Text = qu.Vat;
            txtVatRate.Text = qu.VatRate;
            cboStaffApprove.Text = qu.StaffApproveName;
            txtStaffApproveId.Text = qu.StaffApproveId;
            txtVatRate.Text = qu.VatRate;
            cboRemark1.Text = qu.Remark1;
            cboRemark2.Text = qu.Remark2;
            cboRemark3.Text = qu.Remark3;

            if (qu.Id.Equals(""))
            {
                if (cboComp.Items.Count == 1)
                {
                    cboComp.Text = cp.NameT;
                    txtCompId.Text = cp.Id;
                    txtCompAddress1.Text = cp.AddressT;
                    txtCompAddress2.Text = cp.AddressT;
                    txtCompTaxId.Text = cp.TaxId;
                    txtVatRate.Text = cp.vat;
                }
            }

            txtQuNumber.ReadOnly = true;
            oldNetTotal = qu.NetTotal;
        }
        private void getQuotation()
        {
            qu.Amount = txtAmount.Text;
            qu.AmountDiscount=txtAmountDiscount.Text;
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
            qu.Discount = txtDiscount.Text;
            qu.NetTotal = txtNetTotal.Text;
            qu.Plus1 = txtPlus1.Text;
            qu.Id = txtQuId.Text;
            qu.QuoNumber = txtQuNumber.Text;
            qu.StaffEmail = txtStaffEmail.Text;
            qu.StaffTel = txtStaffTel.Text;
            qu.StaffId = txtStaffId.Text;
            qu.StaffName = cboStaff.Text;
            qu.Total = txtTotal.Text;
            qu.Vat = txtVat.Text;
            qu.VatRate = txtVatRate.Text;
            qu.StaffApproveName = cboStaffApprove.Text;
            qu.StaffApproveId = txtStaffApproveId.Text;
            qu.Active = "1";
            qu.Remark1 = cboRemark1.Text;
            qu.Remark2 = cboRemark2.Text;
            qu.Remark3 = cboRemark3.Text;
            qu.ContactName = cboContact.Text;
            //qu.StatusQuo = "1";
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
            dgvAdd.ColumnCount = colCnt;

            dgvAdd.RowCount = dt.Rows.Count + 1;
            dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdd.Columns[colRow].Width = 50;
            dgvAdd.Columns[colItem].Width = 150;
            dgvAdd.Columns[colMethod].Width = 120;
            dgvAdd.Columns[colQty].Width = 80;
            dgvAdd.Columns[colPrice].Width = 80;
            dgvAdd.Columns[colAmount].Width = 180;

            dgvAdd.Columns[colRow].HeaderText = "ลำดับ";
            dgvAdd.Columns[colItem].HeaderText = "Parameter";
            dgvAdd.Columns[colMethod].HeaderText = "Method";
            dgvAdd.Columns[colQty].HeaderText = "QTY";
            dgvAdd.Columns[colPrice].HeaderText = "Price";
            dgvAdd.Columns[colAmount].HeaderText = "Amount";
            dgvAdd.Columns[colId].HeaderText = "  ";

            dgvAdd.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvAdd.Font = font;
            dgvAdd.Columns[colId].Visible = false;
            dgvAdd.Columns[colDel].Visible = false;
            //dgvAdd.Columns.Add(newColumn);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //dgvAdd.Rows[0].Cells = newColumn;
                    //DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(dgvAdd.Rows[i].Cells[colItem]);
                    //cell.DataSource = newColumn;

                    dgvAdd[colRow, i].Value = (i + 1);
                    dgvAdd[colItem, i].Value = dt.Rows[i][cc.quidb.qui.ItemDescription].ToString();
                    dgvAdd[colMethod, i].Value = dt.Rows[i][cc.quidb.qui.MethodDescription].ToString();
                    dgvAdd[colQty, i].Value = dt.Rows[i][cc.quidb.qui.Qty].ToString();
                    dgvAdd[colPrice, i].Value = dt.Rows[i][cc.quidb.qui.PriceSale].ToString();
                    dgvAdd[colAmount, i].Value = dt.Rows[i][cc.quidb.qui.Amount].ToString();
                    dgvAdd[colId, i].Value = dt.Rows[i][cc.quidb.qui.Id].ToString();
                    dgvAdd[colDel, i].Value = "";

                    if ((i % 2) != 0)
                    {
                        dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void calAmount()
        {
            Double amt = 0;
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
                amt += Double.Parse(cc.cf.NumberNull1(dgvAdd[colAmount, i].Value.ToString()));
            }
            txtAmount.Text = amt.ToString();
        }
        private void calNetTotal()
        {
            Double amt = 0, amtDis=0,total=0,netTotal=0, vat=0;
            amt = Double.Parse(cc.cf.NumberNull1(txtAmount.Text));
            amtDis = amt - Double.Parse(cc.cf.NumberNull1(txtDiscount.Text));
            total = amtDis+Double.Parse(cc.cf.NumberNull1(txtPlus1.Text));
            vat = (total * Double.Parse(cc.cf.NumberNull1(txtVatRate.Text)) / 100);
            netTotal = total + vat;
            txtAmountDiscount.Text = amtDis.ToString();
            txtTotal.Text = total.ToString();
            txtVat.Text = vat.ToString();
            txtNetTotal.Text = netTotal.ToString();
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
            String quId = "";
            if (txtQuNumber.Text.Equals(""))
            {
                MessageBox.Show("ไม่มีเลขที่ Quotation", "ป้อนข้อมูลไม่ครบ");
                return;
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
                if (qu.NetTotal.Equals(oldNetTotal))
                {
                    qu.QuoNumberCnt = doc1[1];
                }
                else
                {
                    qu.QuoNumberCnt = String.Concat(int.Parse(doc1[1])+1);
                }
            }
            quId = cc.qudb.insertQuotation(qu);
            if (quId.Length >= 1)
            {
                for (int i = 0; i < dgvAdd.RowCount; i++)
                {
                    QuotationItem qui = new QuotationItem();
                    if (dgvAdd[colAmount, i].Value == null)
                    {
                        continue;
                    }
                    if (dgvAdd[colAmount, i].Value.ToString().Equals(""))
                    {
                        continue;
                    }
                    qui.RowNumber = dgvAdd[colRow, i].Value.ToString();
                    qui.PriceSale = cc.cf.NumberNull1(dgvAdd[colPrice, i].Value.ToString());
                    qui.Qty = cc.cf.NumberNull1(dgvAdd[colQty, i].Value.ToString());
                    qui.Amount = cc.cf.NumberNull1(dgvAdd[colAmount, i].Value.ToString());
                    qui.ItemDescription = dgvAdd[colItem, i].Value.ToString();
                    qui.MethodDescription = dgvAdd[colMethod, i].Value.ToString();
                    qui.Id = dgvAdd[colId, i].Value.ToString();
                    qui.Active = "1";
                    qui.QuoId = quId;
                    if (dgvAdd[colDel, i].Value.ToString().Equals("1"))
                    {
                        cc.quidb.VoidQuotationItem(dgvAdd[colId, i].Value.ToString());
                    }
                    else
                    {
                        cc.quidb.insertQuotationItem(qui);
                    }
                    
                }
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
            Cursor.Current = cursor;
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer cu = new Customer();
            if (!pageLoad)
            {
                cu = cc.cudb.selectByPk(cc.getValueCboItem(cboCust));
                txtCustId.Text = cu.Id;
                txtCustAddress.Text = cu.AddressT;
                txtCustEmail.Text = cu.Email;
                txtCustFax.Text = cu.Fax;
                txtCustTel.Text = cu.Tele;
                cboContact.Text = cu.ContactName1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int row= dgvAdd.Rows.Add(1);
            dgvAdd[colRow, row].Value = (row+1);
            dgvAdd[colItem, row].Value = cboItem.Text;
            dgvAdd[colMethod, row].Value = cboMethod.Text;
            dgvAdd[colQty, row].Value = txtItemQty.Text;
            dgvAdd[colPrice, row].Value = txtItemPrice.Text;
            dgvAdd[colAmount, row].Value = txtItemAmount.Text;
            dgvAdd[colId, row].Value = "";
            dgvAdd[colDel, row].Value = "";
            calAmount();
            calNetTotal();
        }

        private void dgvAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRow.Text = dgvAdd[colRow, e.RowIndex].Value.ToString();
            txtItemPrice.Text = dgvAdd[colPrice, e.RowIndex].Value.ToString();
            txtItemQty.Text = dgvAdd[colQty, e.RowIndex].Value.ToString();
            txtItemAmount.Text = dgvAdd[colAmount, e.RowIndex].Value.ToString();
            cboItem.Text = dgvAdd[colItem, e.RowIndex].Value.ToString();
            cboMethod.Text = dgvAdd[colMethod, e.RowIndex].Value.ToString();
        }

        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            txtItemAmount.Text = String.Concat(Double.Parse(cc.cf.NumberNull1(txtItemQty.Text)) * Double.Parse(cc.cf.NumberNull1(txtItemPrice.Text)));
            btnAdd.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtRow.Text.Equals(""))
            {
                return;
            }
            dgvAdd[colDel, int.Parse(txtRow.Text)].Value = "1";
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            calNetTotal();
        }

        private void txtPlus1_Leave(object sender, EventArgs e)
        {
            calNetTotal();
        }
    }
}
