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
    /**
     * 57.12.17.02  ให้ย้าย เครื่องมือ, วิธีการตรวจวัด ไปไว้ใน grid แทน และเปลี่ยน value เป็น หมายเหตุ
     * 
     * */
    public partial class FrmResultAdd : Form
    {
        CnviControl cc;
        Boolean pageLoad = false;
        Result rs;
        int colRow = 0, colItemCode=1, colParameter = 2, colMethod = 3, colResultMax = 4, colRemark=5, colId = 6, colDel=7;
        int colCnt = 8;
        ComboBox cboR = new ComboBox();
        ComboBox cboPara = new ComboBox();
        ComboBox cboMethod = new ComboBox();
        public FrmResultAdd(String rsId, CnviControl c)
        {
            InitializeComponent();
            cc = c;
            initConfig(rsId);
        }
        private void initConfig(String rsId)
        {
            pageLoad = true;
            rs = new Result();
            dtpDateResult.Format = DateTimePickerFormat.Short;
            cboCust = cc.moidb.getCboCustomerMOUnoResult(cboCust);
            dgvResult.Controls.Add(cboR);
            dgvResult.Controls.Add(cboPara);
            dgvResult.Controls.Add(cboMethod);
            cboMethod.SelectedValueChanged += new EventHandler(cboMethodChanged);
            cboR.SelectedValueChanged += new EventHandler(cboRemarkChanged);
            cboR = cc.rsidb.getCboRemark(cboR);
            cboR.Visible = false;
            //cboPara = cc.itydb.getCboDocType(cboPara, "mou");
            cboPara.Visible = false;
            cc.setCboMethod(cboMethod);
            cboMethod.Visible = false;
            setControl(rsId);
            //setGrd();
            pageLoad = false;
        }
        void cboMethodChanged(object sender, EventArgs e)
        {
            dgvResult.CurrentCell.Value = cboMethod.Text;
            cboMethod.Visible = false;
        }
        void cboRemarkChanged(object sender, EventArgs e)
        {
            dgvResult.CurrentCell.Value = cboR.Text;
            cboR.Visible = false;
        }
        private void setControl(String rsId)
        {
            rs = cc.rsdb.selectByPk(rsId);
            txtResultId.Text = rs.Id;
            cboCust.Text = rs.CustNameT;
            cboMOU.Text = rs.MouNumber+"-"+rs.MouNumberCnt;
            txtCustAddress.Text = rs.CustAddressT;
            //cboCust.Text = cc.getTextCboItem(cboCust, rs.CustId);
            //txtMachinery.Text = rs.Machinery;
            //cboMachinery.Text = cc.getTextCboItem(cboMachinery, rs.Machinery);
            //txtMeasurement.Text = rs.Measurement;
            //cboMesaurement.Text = cc.getTextCboItem(cboMesaurement, rs.Measurement);
            txtCompName.Text = rs.MethodMeasure;
            txtSummary.Text = rs.Summary;
            if (rs.MeasureDate.Equals(""))
            {
                dtpDateResult.Value = DateTime.Now;
            }
            else
            {
                try
                {
                    dtpDateResult.Value = DateTime.Parse(rs.MeasureDate);
                }
                catch (Exception ex)
                {
                    dtpDateResult.Value = DateTime.Parse(cc.cf.dateDBtoShow( rs.MeasureDate));
                }
                
            }
            if (!rs.MouNumber.Equals(""))
            {
                cboMOU.Enabled = false;
                cboCust.Enabled = false;
            }
            btnUnActive.Visible = false;
            setGrd(rsId);
        }
        private void getResult()
        {
            rs.Active = "1";
            rs.CustAddressT = txtCustAddress.Text;
            rs.CustId = cc.getValueCboItem(cboCust);
            rs.CustNameT = cboCust.Text;
            rs.Machinery = "";
            rs.MeasureDate = cc.cf.datetoDB(dtpDateResult.Value);
            rs.Measurement = "";
            rs.MethodMeasure = txtCompName.Text;
            rs.Summary = txtSummary.Text;
            String[] tmp = cboMOU.Text.Split('-');
            if (tmp.Length > 0)
            {
                rs.MouNumber = tmp[0];
                rs.MouNumberCnt = tmp[1];
            }
        }
        private void setGrd(String rsId)
        {
            dgvResult.ColumnCount = colCnt;

            dgvResult.RowCount = 1;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.Columns[colRow].Width = 50;
            dgvResult.Columns[colParameter].Width = 350;
            dgvResult.Columns[colMethod].Width = 200;
            dgvResult.Columns[colResultMax].Width = 80;
            dgvResult.Columns[colRemark].Width = 300;
            dgvResult.Columns[colId].Width = 350;
            dgvResult.Columns[colDel].Width = 120;

            dgvResult.Columns[colRow].HeaderText = "ลำดับ";
            dgvResult.Columns[colParameter].HeaderText = "Parameter";
            dgvResult.Columns[colMethod].HeaderText = "Method";
            dgvResult.Columns[colResultMax].HeaderText = "Max";
            //dgvResult.Columns[colPrice].HeaderText = "Price";
            dgvResult.Columns[colRemark].HeaderText = "Remark";
            dgvResult.Columns[colId].HeaderText = " ";
            dgvResult.Columns[colDel].HeaderText = " ";
            //dgvResult.Columns[colId].HeaderText = "  ";

            //dgvResult.Columns[colSample].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvResult.Columns[colPrice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvResult.Columns[colPlace].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvResult.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvResult.Font = font;
            dgvResult.Columns[colId].Visible = false;
            dgvResult.Columns[colDel].Visible = false;
            dgvResult.Columns[colResultMax].Visible = false;
            dgvResult.Columns[colItemCode].Visible = false;
            DataTable dt = cc.rsidb.selectRsId(rsId);
            if (dt.Rows.Count > 0)
            {
                dgvResult.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvResult[colRow, i].Value = (i + 1);
                    dgvResult[colParameter, i].Value = dt.Rows[i][cc.rsidb.rsi.ItemDescription].ToString();
                    dgvResult[colMethod, i].Value = dt.Rows[i][cc.rsidb.rsi.ItemMethodDescription].ToString();
                    //dgvResult[colResultMax, i].Value = dt.Rows[i][cc.rsidb.rsi.ResultMax].ToString();
                    dgvResult[colItemCode, i].Value = dt.Rows[i][cc.rsidb.rsi.ItemCode].ToString();
                    dgvResult[colRemark, i].Value = dt.Rows[i][cc.rsidb.rsi.Remark].ToString();
                    dgvResult[colId, i].Value = dt.Rows[i][cc.rsidb.rsi.Id].ToString();

                    dgvResult[colDel, i].Value = "";
                    //dgvResult[colEdit, i].Value = "";
                    if ((i % 2) != 0)
                    {
                        dgvResult.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void setGrdMOU(String moiNumber)
        {
            dgvResult.ColumnCount = colCnt;

            dgvResult.RowCount = 1;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResult.Columns[colRow].Width = 50;
            dgvResult.Columns[colParameter].Width = 350;
            dgvResult.Columns[colMethod].Width = 350;
            dgvResult.Columns[colResultMax].Width = 80;
            dgvResult.Columns[colRemark].Width = 350;
            dgvResult.Columns[colId].Width = 350;
            dgvResult.Columns[colDel].Width = 120;

            dgvResult.Columns[colRow].HeaderText = "ลำดับ";
            dgvResult.Columns[colParameter].HeaderText = "Parameter";
            dgvResult.Columns[colMethod].HeaderText = "Method";
            dgvResult.Columns[colResultMax].HeaderText = "Max";
            //dgvResult.Columns[colPrice].HeaderText = "Price";
            dgvResult.Columns[colRemark].HeaderText = "Remark";
            dgvResult.Columns[colId].HeaderText = " ";
            dgvResult.Columns[colDel].HeaderText = " ";
            DataTable dt = new DataTable();
            dgvResult.Columns[colId].Visible = false;
            dgvResult.Columns[colDel].Visible = false;
            dgvResult.Columns[colResultMax].Visible = false;
            dt = cc.moidb.selectByMoNumber1(moiNumber, "");

            Item it = new Item();
            if (dt.Rows.Count > 0)
            {
                dgvResult.RowCount = dt.Rows.Count + 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    it = cc.getItemByList(dt.Rows[i][cc.moidb.moi.ItemId].ToString());
                    dgvResult[colRow, i].Value = (i + 1);
                    dgvResult[colItemCode, i].Value = it.Code;
                    dgvResult[colItemCode, i].ToolTipText = it.NameT;
                    dgvResult[colParameter, i].Value = dt.Rows[i][cc.moidb.moi.ItemDescription].ToString();      //57.12.17.02
                    dgvResult[colMethod, i].Value = dt.Rows[i][cc.moidb.moi.MethodDescription].ToString();      //57.12.17.02
                    //dgvResult[colResultMax, i].Value = it.ValueMax;
                    //dgvAdd[colPrice, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.quidb.qui.PriceSale]);
                    dgvResult[colRemark, i].Value = "";
                    dgvResult[colId, i].Value = "";

                    dgvResult[colDel, i].Value = "";
                    //dgvResult[colEdit, i].Value = "";
                    if ((i % 2) != 0)
                    {
                        dgvResult.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    if ((i % 2) != 0)
                    {
                        dgvResult.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }

                }
            }
        }
        private void setResize()
        {
            //dgvResult.Left = this.Width + 40;
            dgvResult.Height = this.Height - txtSummary.Height- 220;
            dgvResult.Width = this.Width - 50;
            groupBox1.Width = dgvResult.Width;
            //label7.Left = dgvResult.Left;
            txtSummary.Top = this.Height - txtSummary.Height - 50;
            label8.Top = txtSummary.Top;
            btnSave.Left = this.Width - 300;
            btnPrint.Left = btnSave.Left ;

        }
        private void FrmResultAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String rsId = "", datePlaceRecordTemp = "";
            int rowOld = 0, row = 0;
            if (cboMOU.Text.Equals(""))
            {
                MessageBox.Show("ไม่เลือก ข้อตกลง", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (txtCompName.Text.Equals(""))
            {
                MessageBox.Show("ไม่มี ตรวจวัดโดย", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            //if (txtMachinery.Text.Equals(""))
            //{
            //    MessageBox.Show("ไม่ป้อน เครื่องมือ", "ป้อนข้อมูลไม่ครบ");
            //    return;
            //}
            //if (txtMeasurement.Text.Equals(""))
            //{
            //    MessageBox.Show("ไม่ป้อน วิธีการตรวจวัด", "ป้อนข้อมูลไม่ครบ");
            //    return;
            //}
            if (txtSummary.Text.Equals(""))
            {
                MessageBox.Show("ไม่ป้อน สรุปผลการตรวจวัด", "ป้อนข้อมูลไม่ครบ");
                return;
            }

            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            getResult();
            //if (mo.Id.Equals("") && (!MOUSplit))

            rsId = cc.rsdb.insertResult(rs);
            if (rsId.Length >= 1)
            {
                try
                {
                    for (int i = 0; i < dgvResult.RowCount; i++)
                    {
                        if (dgvResult[colParameter, i].Value == null)
                        {
                            continue;
                        }
                        if (dgvResult[colParameter, i].Value.ToString().Equals(""))
                        {
                            continue;
                        }
                        ResultItem rsi = new ResultItem();
                        rsi.RowNumber = String.Concat(i + 1);

                        //moi.RowNumber = dgvAdd[colRow, i].Value.ToString();
                        //Item it = cc.itdb.selectByPk(dgvResult[colItemId, i].Value.ToString());
                        //ItemGroup itg = cc.itgdb.selectByPk(it.ItemGroupId);
                        if (dgvResult[colId, i].Value != null)
                        {
                            rsi.Id = dgvResult[colId, i].Value.ToString();
                        }
                        else
                        {
                            rsi.Id = "";
                        }
                        //rsi.Id = dgvResult[colResultMax, i].Value.ToString();
                        rsi.Active = "1";
                        rsi.ItemDescription = dgvResult[colParameter, i].Value.ToString();      //57.12.17.02
                        rsi.ResultId = rsId;
                        rsi.ResultMax = dgvResult[colResultMax, i].Value.ToString();
                        rsi.ItemMethodDescription = dgvResult[colMethod, i].Value.ToString();       //57.12.17.02
                        rsi.ItemCode = dgvResult[colItemCode, i].Value.ToString();
                        rsi.Remark = dgvResult[colRemark, i].Value.ToString();      //57.12.17.02

                        if ((dgvResult[colDel, i].Value != null) && dgvResult[colDel, i].Value.ToString().Equals("1"))
                        {
                            cc.moidb.VoidMOUItem(dgvResult[colId, i].Value.ToString());
                        }
                        else
                        {
                            cc.rsidb.insertResultItem(rsi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    cc.lw.WriteLog("Error FrmResultAdd btnSave_Click " + ex.Message);
                    MessageBox.Show(" " + ex.Message, "Error FrmResultAdd btnSave_Click");
                    return;
                }
                
                Result rs1 = cc.rsdb.selectByPk(rsId);

                txtResultId.Text = rs1.Id;
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                btnPrint.Visible = true;
                //UnLockSplit();
            }
            Cursor.Current = cursor;
        }

        private void FrmResultAdd_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            String sql = "";
            //OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = cc.rsidb.selectRsId(txtResultId.Text);
            Result rs1 = cc.rsdb.selectByPk(txtResultId.Text);
            //inv.CustName = inv.ContactName;
            //inv.CustAddress = "ที่อยู่ :   " + inv.CustAddress;
            //inv.CustTel = "เบอร์โทร : " + inv.CustTel + " Mobile : " + inv.CustMobile;
            //inv.CustEmail = " Email : " + inv.CustEmail;
            //inv.Line1 = cc.cp.mouLine1;
            //inv.QuoNumber = "เลขที่ : " + inv.MOUNumber + "-" + inv.MOUNumberCnt;
            //inv.DatePeriod = "วันที่ :  " + inv.DatePeriod;
            //inv.StaffQuoName = "ผู้เสนอราคา :  " + inv.StaffQuoName;
            //inv.StaffMOUTel = "เบอร์โทร : " + inv.StaffMOUTel + " Mobile : " + inv.StaffMOUMobile;
            //inv.StaffMOUEmail = "Email : " + inv.StaffMOUEmail;
            //inv.MOUNumber = "เลขที่ : " + inv.MOUNumber + "-" + inv.MOUNumberCnt;

            FrmReport frm = new FrmReport(cc);
            frm.setReportResult(rs1, dt);
            frm.ShowDialog(this);
            Cursor.Current = cursor;
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                cboMOU = cc.moidb.getCboMOUNumbernoResult(cboMOU, cc.getValueCboItem(cboCust));
            }
        }

        private void cboMOU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGrdMOU(cc.getValueCboItem(cboMOU));
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;
            }
            else
            {

            }
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;
            }
            else
            {

            }
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //cc.modb.VoidMOU(txtMOUId.Text);
                cc.rsdb.VoidResult(txtResultId.Text);
                this.Dispose();
            }
        }

        private void dgvResult_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvResult.CurrentCell.ColumnIndex == colMethod)
            {
                Rectangle tempRect = this.dgvResult.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cboMethod.Location = tempRect.Location;
                cboMethod.Width = tempRect.Width;
                try
                {
                    //cbo.Text = "11";
                }
                catch
                {
                    cboMethod.Text = "22";
                }
                cboMethod.Visible = true;
            }
            else if (dgvResult.CurrentCell.ColumnIndex == colRemark)
            {
                Rectangle tempRect = this.dgvResult.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cboR.Location = tempRect.Location;
                cboR.Width = tempRect.Width;
                try
                {
                    //cbo.Text = "11";
                }
                catch
                {
                    cboR.Text = "22";
                }
                cboR.Visible = true;
            }
        }

        private void dgvResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResult.CurrentCell.ColumnIndex == colRemark)
            {

            }
        }

        private void dgvResult_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            cboR.Visible = false;
            //cboMethod.Visible = false;
        }
    }
}
