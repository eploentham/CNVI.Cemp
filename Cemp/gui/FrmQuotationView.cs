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
    /*
     * 58.01.13.02  เปาแจ้งว่า หน้าจอใบเสนอราคา อยากให้สามารถcopy จากใบเสนอราคาใบอื่น มาใช้งานได้
     * 58.01.22.01  คุณบูล แจ้งว่า อยากให้มียอดรวม ของใบเสนอราคา   
     * 59.08.08.01  คุณกรณ์ แจ้งแก้ไข สีของgrid
     * 59.08.08.02  คุณกรณ์ แจ้งแก้ไข เพิ่มการแสดง ยอดรวม ให้อยู่นอกgrid
     * 59.08.08.03  คุณกรณ์ แจ้งแก้ไข เพิ่มการค้นหา
     * */
    public partial class FrmQuotationView : Form
    {
        CnviControl cc;
        int colCnt = 9;
        int colRow = 0, colQuoNumber = 1,colCustName = 2, colQudate=3, colContactName = 4, colId = 5,  colStaffName = 6,colStatusQuo = 7, colNetTotal=8 ;
        Boolean pageLoad = false;
        Color grdColor;
        public FrmQuotationView(String sfId, CnviControl c)
        {
            InitializeComponent();
            cc = c;
            initConfig(sfId);
        }
        private void initConfig(String sfId)
        {
            pB1.Hide();
            pageLoad = true;
            grdColor = ColorTranslator.FromHtml(cc.initC.grdQuoColor);
            cboYear = cc.qudb.getCboYear(cboYear);
            cboCust = cc.cudb.getCboCustomer1(cboCust);

            //cc = c;
            setGrd();
            dgvView.ReadOnly = true;
            pageLoad = false;
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 80-btnAdd.Width;
            dgvView.Height = this.Height - 150- dgvView.Top;
            //btnAdd.Left = dgvView.Width + 20;
            //label1.Left = btnAdd.Left;
            //cboYear.Left = btnAdd.Left;
            //btnNewCopy.Left = btnAdd.Left;
            //groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        private void setGrd()
        {
            pB1.Show();
            Double net = 0, netwait=0, netapprove=0;     //58.01.22.01 +
            DataTable dt = new DataTable();
            dt = cc.qudb.selectAll(cboYear.Text, cboCust.Text, cboContact.Text);
            dgvView.Rows.Clear();
            dgvView.ColumnCount = colCnt;

            //dgvView.RowCount = dt.Rows.Count + 1;       //58.01.22.01 -
            dgvView.RowCount = dt.Rows.Count + 3;       //58.01.22.01 +
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
                            netwait += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));     //58.01.22.01 +
                        }
                        else if (dt.Rows[i][cc.qudb.qu.StatusQuo].ToString().Equals("2"))
                        {
                            dgvView[colStatusQuo, i].Value = "อนุมัติแล้ว";
                            netapprove += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));     //58.01.22.01 +
                        }
                        dgvView[colNetTotal, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.qudb.qu.NetTotal]);
                        dgvView[colQudate, i].Value = cc.cf.dateDBtoShow(dt.Rows[i][cc.qudb.qu.QuoDate].ToString());
                        net += Double.Parse(cc.cf.NumberNull1(dt.Rows[i][cc.qudb.qu.NetTotal].ToString()));     //58.01.22.01 +
                        //dgvView[colStatusQuo, i].Value = dt.Rows[i][cc.qudb.qu.StatusQuo].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    if ((i % 2) != 0)
                    {
                        //dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon; 59.08.08.01 -
                        dgvView.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(cc.initC.grdQuoColor);//59.08.08.01 +
                    }
                }
                dgvView[colNetTotal, dgvView.RowCount - 1].Value = String.Format("{0:#,###,###.00}", net);        //58.01.22.01 +
                dgvView[colNetTotal, dgvView.RowCount - 2].Value = String.Format("{0:#,###,###.00}", netwait);        //58.01.22.01 +
                dgvView[colNetTotal, dgvView.RowCount - 3].Value = String.Format("{0:#,###,###.00}", netapprove);        //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 1].Value = "รวมทั้งหมด";     //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 2].Value = "รวมสถานะ รออนุมัติ";     //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 3].Value = "รวมสถานะ อนุมัติแล้ว";     //58.01.22.01 +
                txtTotal.Text = String.Format("{0:#,###,###.00}", net); //59.08.08.02 +
                txtWaiting.Text = String.Format("{0:#,###,###.00}", netwait); //59.08.08.02 +
                txtApprove.Text = String.Format("{0:#,###,###.00}", netapprove); //59.08.08.02 +
            }
            pB1.Hide();
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {                
                cboContact = cc.qudb.getCbocontact(cboContact,cboCust.Text,cboContact.Text);
                setGrd();
            }
        }

        private void cboContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGrd();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            pB1.Show();
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            excelapp.Visible = false;
            //String visitDate = "", visitTime = "", err = "", err1 = "", pharName = "";

            Microsoft.Office.Interop.Excel._Workbook workbook = (Microsoft.Office.Interop.Excel._Workbook)(excelapp.Workbooks.Add(Type.Missing));
            Microsoft.Office.Interop.Excel._Worksheet worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            pB1.Minimum = 0;
            pB1.Maximum = dgvView.Rows.Count;
            //worksheet.Cells[0, 0] = "patient name";
            for (int i = 1; i < dgvView.Rows.Count; i++)
            {
                try
                {
                    for(int col = 1; col <= dgvView.ColumnCount; col++)
                    {
                        worksheet.Cells[i, col] = dgvView[col, i-1].Value.ToString();
                    }
            //        worksheet.Cells[i, colPatientHnno] = dgvAdd[colPatientHnno, i].Value.ToString();
            //        worksheet.Cells[i, colPatientName] = dgvAdd[colPatientName, i].Value.ToString();
            //        err = "001 " + dgvView[colPatientHnno, i].Value.ToString();
            //        //worksheet.Cells[i, colDate] = dgvAdd[colDate, i].Value.ToString();
            //        //worksheet.Cells[i, colTime] = dgvAdd[colTime, i].Value.ToString();
            //        worksheet.Cells[i, colDiaCD1] = config1.stringNull(dgvView[colDiaCD1, i].Value.ToString());
            //        if (dgvView[colDate, i].Value == null)
            //        {
            //            worksheet.Cells[i, colDate].Value = "";
            //        }
            //        else
            //        {
            //            visitDate = dgvAdd[colDate, i].Value.ToString();
            //            worksheet.Cells[i, colDate] = visitDate;
            //            visitTime = dgvAdd[colTime, i].Value.ToString();
            //            worksheet.Cells[i, colTime] = visitTime;
            //        }
            //        err = "002 Dia";
            //        if (dgvAdd[colDiaCD2, i].Value == null)
            //        {
            //            worksheet.Cells[i, colDiaCD2] = "";
            //        }
            //        else
            //        {
            //            worksheet.Cells[i, colDiaCD2] = config1.stringNull1(dgvAdd[colDiaCD2, i].Value.ToString());
            //        }
            //        err = "003 Chronic ";
            //        worksheet.Cells[i, colDiaCD3] = config1.stringNull1(dgvAdd[colDiaCD3, i].Value);
            //        worksheet.Cells[i, colDiaCD4] = config1.stringNull1(dgvAdd[colDiaCD4, i].Value);
            //        worksheet.Cells[i, colDiaCD5] = config1.stringNull1(dgvAdd[colDiaCD5, i].Value);

            //        worksheet.Cells[i, colCHRONICCODE1] = config1.stringNull1(dgvAdd[colCHRONICCODE1, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE2] = config1.stringNull1(dgvAdd[colCHRONICCODE2, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE3] = config1.stringNull1(dgvAdd[colCHRONICCODE3, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE4] = config1.stringNull1(dgvAdd[colCHRONICCODE4, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE5] = config1.stringNull1(dgvAdd[colCHRONICCODE5, i].Value);
            //        if (nudChronic.Value <= 5)
            //        {
            //            continue;
            //        }

            //        worksheet.Cells[i, colCHRONICCODE6] = config1.stringNull1(dgvAdd[colCHRONICCODE6, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE7] = config1.stringNull1(dgvAdd[colCHRONICCODE7, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE8] = config1.stringNull1(dgvAdd[colCHRONICCODE8, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE9] = config1.stringNull1(dgvAdd[colCHRONICCODE9, i].Value);
            //        worksheet.Cells[i, colCHRONICCODE10] = config1.stringNull1(dgvAdd[colCHRONICCODE10, i].Value);
            //        err = "004 Drug ";

            //        worksheet.Cells[i, colDrug1] = config1.stringNull1(dgvAdd[colDrug1, i].Value);
            //        worksheet.Cells[i, colDrug2] = config1.stringNull1(dgvAdd[colDrug2, i].Value);
            //        worksheet.Cells[i, colDrug3] = config1.stringNull1(dgvAdd[colDrug3, i].Value);
            //        worksheet.Cells[i, colDrug4] = config1.stringNull1(dgvAdd[colDrug4, i].Value);
            //        worksheet.Cells[i, colDrug5] = config1.stringNull1(dgvAdd[colDrug5, i].Value);

            //        worksheet.Cells[i, colDrug6] = config1.stringNull1(dgvAdd[colDrug6, i].Value);
            //        worksheet.Cells[i, colDrug7] = config1.stringNull1(dgvAdd[colDrug7, i].Value);
            //        worksheet.Cells[i, colDrug8] = config1.stringNull1(dgvAdd[colDrug8, i].Value);
            //        worksheet.Cells[i, colDrug9] = config1.stringNull1(dgvAdd[colDrug9, i].Value);
            //        worksheet.Cells[i, colDrug10] = config1.stringNull1(dgvAdd[colDrug10, i].Value);
            //        if (nudDrug.Value <= 10)
            //        {
            //            continue;
            //        }

            //        worksheet.Cells[i, colDrug11] = config1.stringNull1(dgvAdd[colDrug11, i].Value);
            //        worksheet.Cells[i, colDrug12] = config1.stringNull1(dgvAdd[colDrug12, i].Value);
            //        worksheet.Cells[i, colDrug13] = config1.stringNull1(dgvAdd[colDrug13, i].Value);
            //        worksheet.Cells[i, colDrug14] = config1.stringNull1(dgvAdd[colDrug14, i].Value);
            //        worksheet.Cells[i, colDrug15] = config1.stringNull1(dgvAdd[colDrug15, i].Value);

            //        worksheet.Cells[i, colDrug16] = config1.stringNull1(dgvAdd[colDrug16, i].Value);
            //        worksheet.Cells[i, colDrug17] = config1.stringNull1(dgvAdd[colDrug17, i].Value);
            //        worksheet.Cells[i, colDrug18] = config1.stringNull1(dgvAdd[colDrug18, i].Value);
            //        worksheet.Cells[i, colDrug19] = config1.stringNull1(dgvAdd[colDrug19, i].Value);
            //        worksheet.Cells[i, colDrug20] = config1.stringNull1(dgvAdd[colDrug20, i].Value);
            //        pB1.Value = i;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error " + ex.Message + "\n row " + i, "error " + err);
                }
            //    if (dgvAdd[colPatientHnno, i].Value == null)
            //    {
            //        continue;
            //    }

            }


            ////worksheet.Cells[1, 1] = "Name";
            ////worksheet.Cells[1, 2] = "Bid";

            ////worksheet.Cells[2, 1] = txbName.Text;
            ////worksheet.Cells[2, 2] = txbResult.Text;
            pB1.Hide();
            excelapp.UserControl = true;
            excelapp.Visible = true;
        }

        private void cboCust_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!pageLoad)
                {
                    setGrd();
                }
            }
        }

        private void FrmQuotationView_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuotationView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmQuotationAdd frm = new FrmQuotationAdd("",false,false, cc);
            this.Hide();
            frm.ShowDialog(this);
            this.Hide();
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

            FrmQuotationAdd frm = new FrmQuotationAdd(dgvView[colId, e.RowIndex].Value.ToString(),false,false, cc);
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
            setGrd();
        }
        private void mnuCost_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvView.SelectedRows[0].Index.ToString(), "aaa");
            if (dgvView.SelectedRows[0].Index == -1)
            {
                return;
            }
            if (dgvView[colId, dgvView.SelectedRows[0].Index].Value == null)
            {
                return;
            }

            FrmQuotationAdd frm = new FrmQuotationAdd(dgvView[colId, dgvView.SelectedRows[0].Index].Value.ToString(),true,false, cc);
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setGrd();
        }
        private void dgvView_MouseClick(object sender, MouseEventArgs e)
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
                int currentMouseOverRow = dgvView.HitTest(e.X, e.Y).RowIndex;
                
                m.Show(dgvView, new Point(e.X, e.Y));
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGrd();
            }
            
        }

        private void btnNewCopy_Click(object sender, EventArgs e)       //58.01.13.02 +
        {
            FrmQuotationAdd frm = new FrmQuotationAdd(dgvView[colId, dgvView.CurrentCell.RowIndex].Value.ToString(), false, true, cc);
            this.Hide();
            frm.ShowDialog(this);
            this.Hide();
            setGrd();
        }
    }
}
