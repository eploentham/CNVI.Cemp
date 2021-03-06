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
    public partial class FrmQuoConfirmView : Form
    {
        CnviControl cc;
        int colCnt = 7;
        int colRow = 0, colQuoNumber = 1, colCustName = 2, colContactName = 3, colId = 4, colStaffName = 5, colStatusQuo = 6;
        public FrmQuoConfirmView(String sfId, CnviControl c)
        {
            InitializeComponent();
            initConfig(sfId, c);
        }
        private void initConfig(String sfId, CnviControl c)
        {
            cc = c;
            setGrd();
            dgvView.ReadOnly = true;
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 80 ;
            dgvView.Height = this.Height - 150;
            //btnAdd.Left = dgvView.Width + 20;
            //groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        private void setGrd()
        {
            DataTable dt = new DataTable();
            dt = cc.qudb.selectAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colQuoNumber].Width = 150;
            dgvView.Columns[colCustName].Width = 350;
            dgvView.Columns[colContactName].Width = 200;
            dgvView.Columns[colId].Width = 80;
            dgvView.Columns[colStatusQuo].Width = 80;
            dgvView.Columns[colStaffName].Width = 180;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colQuoNumber].HeaderText = "เลขที่";
            dgvView.Columns[colCustName].HeaderText = "ชื่อลูกค้า";
            dgvView.Columns[colContactName].HeaderText = "ชื่อผู้ติดต่อ";
            dgvView.Columns[colId].HeaderText = "id";
            dgvView.Columns[colStaffName].HeaderText = "ผู้เสนอราคา";
            dgvView.Columns[colStatusQuo].HeaderText = "สถานะ";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colQuoNumber, i].Value = dt.Rows[i][cc.qudb.qu.QuoNumber].ToString() + "-" + dt.Rows[i][cc.qudb.qu.QuoNumberCnt].ToString();
                    dgvView[colCustName, i].Value = dt.Rows[i][cc.qudb.qu.CustName].ToString();
                    dgvView[colContactName, i].Value = dt.Rows[i][cc.qudb.qu.ContactName].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][cc.qudb.qu.Id].ToString();
                    dgvView[colStaffName, i].Value = dt.Rows[i][cc.qudb.qu.StaffName].ToString();
                    if (dt.Rows[i][cc.qudb.qu.StatusQuo].ToString().Equals("1"))
                    {
                        dgvView[colStatusQuo, i].Value = "รออนุมัติ";
                    }
                    else if (dt.Rows[i][cc.qudb.qu.StatusQuo].ToString().Equals("2"))
                    {
                        dgvView[colStatusQuo, i].Value = "อนุมัติแล้ว";
                    }

                    //dgvView[colStatusQuo, i].Value = dt.Rows[i][cc.qudb.qu.StatusQuo].ToString();
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }

        private void FrmQuoConfirmView_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuoConfirmView_Resize(object sender, EventArgs e)
        {
            setResize();
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

            FrmQuoConfirmAdd frm = new FrmQuoConfirmAdd(dgvView[colId, e.RowIndex].Value.ToString(),cc);
            frm.ShowDialog(this);
            setGrd();
        }
    }
}
