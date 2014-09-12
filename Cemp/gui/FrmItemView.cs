﻿using Cemp.Control;
using Cemp.object1;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FrmItemView : Form
    {
        CnviControl cc;
        Item it;
        int colRow = 0, colNameT = 1, colNameE = 2, colMethod = 3, colGroup = 4, colRemark = 5, colId = 6;
        int colCnt = 7;
        public FrmItemView(CnviControl c)
        {
            InitializeComponent();
            cc = c;
            initConfig();
        }
        private void initConfig()
        {
            //cc = c;
            it = new Item();
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
            try
            {
                DataTable dt = new DataTable();
                dt = cc.itdb.selectAll();
                dgvView.ColumnCount = colCnt;

                dgvView.RowCount = dt.Rows.Count + 1;
                dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvView.Columns[colRow].Width = 50;
                dgvView.Columns[colNameT].Width = 200;
                dgvView.Columns[colNameE].Width = 200;
                dgvView.Columns[colMethod].Width = 200;
                dgvView.Columns[colGroup].Width = 200;
                dgvView.Columns[colRemark].Width = 200;

                dgvView.Columns[colRow].HeaderText = "ลำดับ";
                dgvView.Columns[colNameT].HeaderText = "ชื่อ";
                dgvView.Columns[colNameE].HeaderText = "Name";
                dgvView.Columns[colMethod].HeaderText = "วิธีการตรวจ";
                dgvView.Columns[colGroup].HeaderText = "กลุ่ม";
                dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";
                //dgvView.Columns[colPassword].HeaderText = "  ";

                dgvView.Columns[colId].HeaderText = "id";
                Font font = new Font("Microsoft Sans Serif", 12);

                dgvView.Font = font;
                dgvView.Columns[colId].Visible = false;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvView[colRow, i].Value = (i + 1);
                        dgvView[colNameT, i].Value = dt.Rows[i][cc.itdb.it.NameT].ToString();
                        dgvView[colNameE, i].Value = dt.Rows[i][cc.itdb.it.NameE].ToString();
                        dgvView[colMethod, i].Value = dt.Rows[i][cc.itdb.it.MethodNameT].ToString();
                        dgvView[colGroup, i].Value = dt.Rows[i][cc.itdb.it.ItemGroupNameT].ToString();
                        dgvView[colRemark, i].Value = dt.Rows[i][cc.itdb.it.Remark].ToString();
                        dgvView[colId, i].Value = dt.Rows[i][cc.itdb.it.Id].ToString();

                        if ((i % 2) != 0)
                        {
                            dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
                dgvView.ReadOnly = true;
            }
            catch (Exception ex)
            {
            }
            
        }
        private void FrmItemView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmItemAdd frm = new FrmItemAdd("",cc);
            //frm.ShowDialog(this);
            frm.Show();
            setGrd();
        }

        private void FrmItemView_Resize(object sender, EventArgs e)
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
            FrmItemAdd frm = new FrmItemAdd(dgvView[colId, e.RowIndex].Value.ToString(), cc);
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setGrd();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String sql = "";
            DataTable dt = cc.itdb.selectAll();
            FrmReport frm = new FrmReport(cc);
            frm.setReport("ItemList", "รายการ Parameter", "เงื่อนไข ทั้งหมด", dt);
            frm.ShowDialog(this);
        }

        private void FrmItemView_Activated(object sender, EventArgs e)
        {
            setGrd();
        }
    }
}
