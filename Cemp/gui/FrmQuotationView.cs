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
     * */
    public partial class FrmQuotationView : Form
    {
        CnviControl cc;
        int colCnt = 9;
        int colRow = 0, colQuoNumber = 1,colCustName = 2, colQudate=3, colContactName = 4, colId = 5,  colStaffName = 6,colStatusQuo = 7, colNetTotal=8 ;
        Boolean pageLoad = false;
        public FrmQuotationView(String sfId, CnviControl c)
        {
            InitializeComponent();
            cc = c;
            initConfig(sfId);
        }
        private void initConfig(String sfId)
        {
            pageLoad = true;
            cboYear = cc.qudb.getCboYear(cboYear);
            //cc = c;
            setGrd();
            dgvView.ReadOnly = true;
            pageLoad = false;
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 80-btnAdd.Width;
            dgvView.Height = this.Height - 150;
            btnAdd.Left = dgvView.Width + 20;
            label1.Left = btnAdd.Left;
            cboYear.Left = btnAdd.Left;
            btnNewCopy.Left = btnAdd.Left;
            //groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        private void setGrd()
        {
            Double net = 0, netwait=0, netapprove=0;     //58.01.22.01 +
            DataTable dt = new DataTable();
            dt = cc.qudb.selectAll(cboYear.Text);
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
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
                dgvView[colNetTotal, dgvView.RowCount - 1].Value = String.Format("{0:#,###,###.00}", net);        //58.01.22.01 +
                dgvView[colNetTotal, dgvView.RowCount - 2].Value = String.Format("{0:#,###,###.00}", netwait);        //58.01.22.01 +
                dgvView[colNetTotal, dgvView.RowCount - 3].Value = String.Format("{0:#,###,###.00}", netapprove);        //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 1].Value = "รวมทั้งหมด";     //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 2].Value = "รวมสถานะ รออนุมัติ";     //58.01.22.01 +
                dgvView[colStaffName, dgvView.RowCount - 3].Value = "รวมสถานะ อนุมัติแล้ว";     //58.01.22.01 +
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
