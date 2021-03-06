﻿using Cemp.Control;
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
    public partial class FrmCustView : Form
    {
        CnviControl cc;
        int colRow = 0, colNameT = 1, colAddr = 2, colTel = 3, colFax=4, colRemark=5, colId=6, colStatusVendor=7, colVendor=8;
        int colCnt = 9;
        public FrmCustView(CnviControl c)
        {
            InitializeComponent();
            initConfig(c);
        }
        private void initConfig(CnviControl c)
        {
            cc = c;
            setGrd();
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 80 - btnAdd.Width;
            dgvView.Height = this.Height - 150;
            btnAdd.Left = dgvView.Width + 20;
            btnPrint.Left = dgvView.Width + 20;
            //groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        private void setGrd()
        {
            DataTable dt = new DataTable();
            dt = cc.cudb.selectAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colNameT].Width = 350;
            dgvView.Columns[colAddr].Width = 350;
            dgvView.Columns[colTel].Width = 150;
            dgvView.Columns[colFax].Width = 150;
            dgvView.Columns[colRemark].Width = 180;
            dgvView.Columns[colVendor].Width = 180;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colNameT].HeaderText = "ชื่อ";
            dgvView.Columns[colAddr].HeaderText = "ที่อยู่";
            dgvView.Columns[colTel].HeaderText = "เบอร์";
            dgvView.Columns[colFax].HeaderText = "Fax";
            dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";
            dgvView.Columns[colVendor].HeaderText = "  ";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            dgvView.Columns[colStatusVendor].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    if (dt.Rows[i][cc.cudb.cu.StatusCompany].ToString().Equals("1"))
                    {
                        dgvView[colNameT, i].Value = "บริษัท " + dt.Rows[i][cc.cudb.cu.NameT].ToString() + " จำกัด";
                    }
                    else if (dt.Rows[i][cc.cudb.cu.StatusCompany].ToString().Equals("2"))
                    {
                        dgvView[colNameT, i].Value = "บริษัท " + dt.Rows[i][cc.cudb.cu.NameT].ToString() + " จำกัด (มหาชน)";
                    }
                    else
                    {
                        dgvView[colNameT, i].Value = dt.Rows[i][cc.cudb.cu.NameT].ToString();
                    }
                    //dgvView[colNameT, i].Value = dt.Rows[i][cc.cudb.cu.NameT].ToString();
                    dgvView[colAddr, i].Value = dt.Rows[i][cc.cudb.cu.AddressT].ToString();
                    dgvView[colTel, i].Value = dt.Rows[i][cc.cudb.cu.Tele].ToString();
                    dgvView[colFax, i].Value = dt.Rows[i][cc.cudb.cu.Fax].ToString();
                    dgvView[colRemark, i].Value = dt.Rows[i][cc.cudb.cu.Remark].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][cc.cudb.cu.Id].ToString();
                    dgvView[colStatusVendor, i].Value = dt.Rows[i][cc.cudb.cu.StatusVendor].ToString();
                    if (dt.Rows[i][cc.cudb.cu.StatusVendor].ToString().Equals("2"))
                    {
                        dgvView[colVendor, i].Value = "Vendor";
                    }
                    else
                    {
                        dgvView[colVendor, i].Value = "Customer";
                    }
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            dgvView.ReadOnly = true;
        }
        private void FrmCustView_Load(object sender, EventArgs e)
        {

        }

        private void FrmCustView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustAdd frm = new FrmCustAdd("",cc);
            frm.ShowDialog(this);
            setGrd();
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvView[colId, e.RowIndex].Value == null)
            {
                return;
            }
            FrmCustAdd frm = new FrmCustAdd(dgvView[colId, e.RowIndex].Value.ToString(), cc);
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setGrd();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String sql = "";
            DataTable dt = cc.cudb.selectAll();
            FrmReport frm = new FrmReport(cc);
            frm.setReport("CustomerList", "รายงานรายละเอียด ลูกค้า", "เงื่อนไข ทั้งหมด", dt);
            frm.Show(this);
        }
    }
}
