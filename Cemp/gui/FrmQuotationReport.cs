using Cemp.Control;
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
    public partial class FrmQuotationReport : Form
    {
        CnviControl cc;

        int colCnt = 9;
        int colRow = 0, colQuoNumber = 1, colCustName = 2, colQudate = 3, colContactName = 4, colId = 5, colStaffName = 6, colStatusQuo = 7, colNetTotal = 8;

        Boolean pageLoad = false;
        Color grdColor;
        public FrmQuotationReport(String sfId, CnviControl c)
        {
            InitializeComponent();
            cc = c;
            initConfig(sfId);
        }
        private void initConfig(String sfId)
        {
            pB1.Visible = false;
            pageLoad = true;
            grdColor = ColorTranslator.FromHtml(cc.initC.grdQuoColor);
            cboYear = cc.qudb.getCboYear(cboYear);

            //cc = c;
            setGrd();
            dgvView.ReadOnly = true;
            pageLoad = false;
        }
        private void setGrd()
        {
            pB1.Visible = true;
            Double net = 0, netwait = 0, netapprove = 0;     
            DataTable dt = new DataTable();
            //dt = cc.qudb.selectAll(cboYear.Text, cboCust.Text, cboContact.Text);
            dgvView.Rows.Clear();
            dgvView.ColumnCount = colCnt;

            //dgvView.RowCount = dt.Rows.Count + 1;       
            dgvView.RowCount = dt.Rows.Count + 3;       
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colQuoNumber].Width = 150;
            dgvView.Columns[colCustName].Width = 350;
            dgvView.Columns[colContactName].Width = 200;
            dgvView.Columns[colId].Width = 80;
            dgvView.Columns[colStatusQuo].Width = 80;
            dgvView.Columns[colStaffName].Width = 180;
            dgvView.Columns[colQudate].Width = 140;
            dgvView.Columns[colNetTotal].Width = 180;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colQuoNumber].HeaderText = "เลขที่";
            dgvView.Columns[colCustName].HeaderText = "ชื่อลูกค้า";
            dgvView.Columns[colContactName].HeaderText = "ชื่อผู้ติดต่อ";
            dgvView.Columns[colId].HeaderText = "id";
            dgvView.Columns[colStaffName].HeaderText = "ผู้เสนอราคา";
            dgvView.Columns[colStatusQuo].HeaderText = "สถานะ";
            dgvView.Columns[colQudate].HeaderText = "วันที่ Quotation";
            dgvView.Columns[colNetTotal].HeaderText = "Nettotal";

            dgvView.Columns[colNetTotal].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
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
                            netwait += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));    
                        }
                        else if (dt.Rows[i][cc.qudb.qu.StatusQuo].ToString().Equals("2"))
                        {
                            dgvView[colStatusQuo, i].Value = "อนุมัติแล้ว";
                            netapprove += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));     
                        }
                        dgvView[colNetTotal, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.qudb.qu.NetTotal]);
                        dgvView[colQudate, i].Value = cc.cf.dateDBtoShow(dt.Rows[i][cc.qudb.qu.QuoDate].ToString());
                        net += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));     
                        //dgvView[colStatusQuo, i].Value = dt.Rows[i][cc.qudb.qu.StatusQuo].ToString();
                    }
                    catch (Exception ex)
                    {

                    }

                    if ((i % 2) != 0)
                    {
                        //dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        dgvView.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(cc.initC.grdQuoColor);
                    }
                }
                //dgvView[colNetTotal, dgvView.RowCount - 1].Value = String.Format("{0:#,###,###.00}", net);        
                //dgvView[colNetTotal, dgvView.RowCount - 2].Value = String.Format("{0:#,###,###.00}", netwait);       
                //dgvView[colNetTotal, dgvView.RowCount - 3].Value = String.Format("{0:#,###,###.00}", netapprove);        
                //dgvView[colStaffName, dgvView.RowCount - 1].Value = "รวมทั้งหมด";     
                //dgvView[colStaffName, dgvView.RowCount - 2].Value = "รวมสถานะ รออนุมัติ";     
                //dgvView[colStaffName, dgvView.RowCount - 3].Value = "รวมสถานะ อนุมัติแล้ว";    
                //txtTotal.Text = String.Format("{0:#,###,###.00}", net); 
                //txtWaiting.Text = String.Format("{0:#,###,###.00}", netwait); 
                //txtApprove.Text = String.Format("{0:#,###,###.00}", netapprove); 
            }
            pB1.Visible = false;
        }
        private void FrmQuotationReport_Load(object sender, EventArgs e)
        {

        }
    }
}
