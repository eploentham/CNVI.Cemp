using Cemp.Control;
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
    /*
     * 61.05.17 คุณกรณ์ แจ้งแก้ไข ให้จอย แจ้ง แก้โปรแกรม ส่งตรวจกับบริษัท  : ให้เพิ่มได้ btnCusAdd
     */
    public partial class FrmItemAdd : Form
    {
        CnviControl cc;
        Item it;
        int colRow = 0, colPeriodStart = 1, colPeriodEnd = 2, colPrice = 3, colRemark = 4, colActive=5;
        int colCnt = 5;

        public FrmItemAdd(String itId,CnviControl c)
        {
            InitializeComponent();
            initConfig(itId, c);
        }
        private void initConfig(String itId, CnviControl c)
        {
            cc = c;
            it = new Item();
            setControl(itId);
            if (itId.Equals(""))
            {
                label9.Text = cc.itdb.getMaxCode();
            }
            else
            {
                label9.Visible = false;
            }
            
            btnUnActive.Visible = false;
            //setGrd();
        }
        private void setControl(String itId)
        {
            it = cc.itdb.selectByPk(itId);
            txtCode.Text = it.Code;
            txtId.Text = it.Id;
            txtNameE.Text = it.NameE;
            txtNameT.Text = it.NameT;
            txtRemark.Text = it.Remark;
            txtPriceCost.Text = it.PriceCost;
            txtPriceSale.Text = it.PriceSale;
            txtPriceCostReal.Text = it.PriceCostReal;
            if (it.Active.Equals("1"))
            {
                chkActive.Checked = true;
                ChkUnActive.Checked = false;
                btnUnActive.Visible = false;
            }
            else
            {
                chkActive.Checked = false;
                ChkUnActive.Checked = true;
                btnUnActive.Visible = true;
            }
            if (it.Active.Equals(""))
            {
                chkActive.Checked = true;
                ChkUnActive.Checked = false;
                btnUnActive.Visible = false;
            }
            cboMethod = cc.medb.getCboMethod(cboMethod);
            cboGroup = cc.itgdb.getCboItemGroup(cboGroup);
            cboAnalysis = cc.anadb.getCboAnalysis(cboAnalysis);
            cboMethod.Text = it.MethodNameT;
            cboGroup.Text = it.ItemGroupNameT;
            cboAnalysis.Text = it.AnalysisNameT;
            cc.CloneItemType(cboDocType);
            cboDocType.Text = it.ItemType;
            cboCustPO = cc.cudb.getCboVendor(cboCustPO);
            cboCustPO.Text = cc.getVendorNamet(it.CustId);
            txtSort1.Text = it.Sort1;
            txtValueMax.Text = it.ValueMax;
            txtValueMin.Text = it.ValueMin;

            if (it.StatusReal.Equals("1"))
            {
                chkItemReal.Checked = true;
                chkItemFail.Checked = false;
            }
            else
            {
                chkItemFail.Checked = true;
                chkItemReal.Checked = false;
            }
            if (it.StatusStock.Equals("1"))
            {
                chkStock.Checked = true;
                chkStatusNoStock.Checked = false;
            }
            else
            {
                chkStock.Checked = false;
                chkStatusNoStock.Checked = true;
            }
            if (it.StatusPrice.Equals("1"))
            {
                chkPriceNormal.Checked = true;
                chkPricePeriod.Checked = false;
                chkPriceFree.Checked = false;
            }
            else if (it.StatusPrice.Equals("2"))
            {
                chkPriceNormal.Checked = false;
                chkPricePeriod.Checked = false;
                chkPriceFree.Checked = true;
            }
            else if (it.StatusPrice.Equals("4"))
            {
                chkPriceNormal.Checked = false;
                chkPricePeriod.Checked = true;
                chkPriceFree.Checked = false;
            }
            else
            {
                chkPriceNormal.Checked = true;
                chkPricePeriod.Checked = false;
                chkPriceFree.Checked = false;
            }
        }
        private void getItem()
        {
            it.Code = txtCode.Text;
            it.Id = txtId.Text;
            it.NameE = txtNameE.Text;
            it.NameT = txtNameT.Text;
            it.Remark = txtRemark.Text;
            it.PriceSale = txtPriceSale.Text;
            it.PriceCost = txtPriceCost.Text;
            it.PriceCostReal = txtPriceCostReal.Text;
            it.ItemGroupId = cc.getValueCboItem(cboGroup);
            it.MethodId = cc.getValueCboItem(cboMethod);
            it.ItemGroupNameT = cboGroup.Text;
            it.MethodNameT = cboMethod.Text;

            it.userCreate = cc.sf.Id;
            it.userModi = cc.sf.Id;
            it.ItemType = cboDocType.Text;
            it.CustId = cc.getValueCboItem(cboCustPO);
            it.CustNameT = cboCustPO.Text;
            it.AnalysisId = cc.getValueCboItem(cboAnalysis);
            it.AnalysisNameT = cboAnalysis.Text;
            it.Sort1 = txtSort1.Text;
            it.ValueMax = txtValueMax.Text;
            it.ValueMin = txtValueMin.Text;

            if (chkItemReal.Checked)
            {
                it.StatusReal = "1";
            }
            else
            {
                it.StatusReal = "3";
            }
            if (chkStock.Checked)
            {
                it.StatusStock = "1";
            }
            else
            {
                it.StatusStock = "3";
            }
            if (chkPriceNormal.Checked)
            {
                it.StatusPrice = "1";
            }
            else if (chkPriceFree.Checked)
            {
                it.StatusPrice = "2";
            }
            else if (chkPricePeriod.Checked)
            {
                it.StatusPrice = "4";
            }
            else
            {
                it.StatusPrice = "1";
            }
        }
        //private void setGrd(String itId)
        //{
        //    DataTable dt;

        //    dt = cc.modb.selectByNoBilling(itId);

        //    dgvAdd.ColumnCount = colCnt;
        //    dgvAdd.Rows.Clear();
        //    dgvAdd.RowCount = dt.Rows.Count + 1;
        //    dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvAdd.Columns[colRow].Width = 50;
        //    dgvAdd.Columns[colRemark].Width = 120;
        //    dgvAdd.Columns[colPeriodEnd].Width = 150;
        //    dgvAdd.Columns[colPrice].Width = 300;
        //    dgvAdd.Columns[colNetTotal].Width = 120;
        //    dgvAdd.Columns[colRemark].Width = 150;
        //    //dgvAdd.Columns[colAmount].Width = 180;

        //    dgvAdd.Columns[colRow].HeaderText = "ลำดับ";
        //    dgvAdd.Columns[colRemark].HeaderText = "เลขที่ข้อตกลง";
        //    dgvAdd.Columns[colPrice].HeaderText = "ลูกค้า บริษัท";
        //    dgvAdd.Columns[colPeriodEnd].HeaderText = "วันที่เริ่มข้อตกลง";
        //    dgvAdd.Columns[colSample].HeaderText = "จน.sample";
        //    dgvAdd.Columns[colNetTotal].HeaderText = "มูลค่าทั้งหมด";
        //    dgvAdd.Columns[colRemark].HeaderText = "หมายเหตุ";

        //    dgvAdd.Columns[colNetTotal].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    //dgvAdd.Columns[colPriceSale].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    //dgvAdd.Columns[colAmount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvAdd.Columns[colPeriodStart].Visible = false;
        //    dgvAdd.Columns[colMOUId].Visible = false;
        //    dgvAdd.Columns[colAdd].Visible = false;
        //    //dgvAdd.Columns[colId].HeaderText = "id";
        //    Font font = new Font("Microsoft Sans Serif", 12);

        //    dgvAdd.Font = font;

        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            dgvAdd[colRow, i].Value = (i + 1);
        //            dgvAdd[colMOUId, i].Value = dt.Rows[i][cc.modb.mo.Id].ToString();
        //            dgvAdd[colRemark, i].Value = dt.Rows[i][cc.modb.mo.MOUNumberMain].ToString();
        //            dgvAdd[colPeriodEnd, i].Value = dt.Rows[i][cc.modb.mo.MOUDate].ToString();
        //            dgvAdd[colPrice, i].Value = dt.Rows[i][cc.modb.mo.CustName].ToString();
        //            dgvAdd[colNetTotal, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i]["amount1"]);
        //            dgvAdd[colRemark, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][cc.modb.mo.Remark]);
        //            dgvAdd[colSample, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i]["cnt"]);
        //            dgvAdd[colAdd, i].Value = "0";
        //            if ((i % 2) != 0)
        //            {
        //                dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
        //            }
        //        }
        //    }
        //}
        private void FrmItemAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                cc.itdb.VoidItem(txtId.Text);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameE.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้ป้อนชื่อ", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboMethod.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้เลือก Method", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (cboGroup.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้เลือก Group", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (txtId.Text.Equals(""))
            {
                it = cc.itdb.selectByCode(txtCode.Text);
                if (!it.Code.Equals(""))
                {
                    MessageBox.Show("ป้อนรหัสซ้ำ\nรหัส " + it.Code + " ชื่อ " + it.NameT, "รหัสซ้ำ");
                    return;
                }
                //if (!cu.Code.Equals(""))
                //{
                //    MessageBox.Show("ป้อนชื่อซ้ำ\nรหัส " + cu.Code + " ชื่อ " + cu.NameT, "ชื่อซ้ำ");
                //    return;
                //}
            }
            getItem();

            if (it.Code.Equals(""))
            {
                it.Code = cc.itdb.getItemCode();
            }
            if (cc.itdb.insertItem(it).Length >= 1)
            {
                cc.quidb.UpdateGroupNameT(txtId.Text,it.ItemGroupId, cboGroup.Text, txtSort1.Text);
                cc.moidb.UpdateGroupNameT(txtId.Text, it.ItemGroupId, cboGroup.Text, txtSort1.Text);
                cc.quidb.UpdateDocType(txtId.Text, cboDocType.Text);
                cc.moidb.UpdateDocType(txtId.Text, cboDocType.Text);
                cc.itdb.getListItem(cc.lit);
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Item it = cc.itdb.selectByCode(txtCode.Text);

            if (!it.Code.Equals(""))
            {
                if (!txtId.Text.Equals(it.Id))
                {
                    label8.Text = "รหัสซ้ำ" + it.Code + " ชื่อ " + it.NameT;
                    MessageBox.Show("ป้อนรหัสซ้ำ\nรหัส " + it.Code + " ชื่อ " + it.NameT, "รหัสซ้ำ");
                    return;
                }
            }
            else
            {
                label8.Text = "ok";
            }
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            FrmAnalysisAdd frm = new FrmAnalysisAdd("",cc);
            frm.ShowDialog(this);
            //cboMethod = cc.medb.getCboMethod(cboMethod);
            cboGroup = cc.itgdb.getCboItemGroup(cboGroup);
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.LightYellow;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.White;
            btnSearch_Click(null,null);
        }

        private void txtNameT_Enter(object sender, EventArgs e)
        {
            txtNameT.BackColor = Color.LightYellow;
        }

        private void txtNameT_Leave(object sender, EventArgs e)
        {
            txtNameT.BackColor = Color.White;
        }

        private void txtNameE_Enter(object sender, EventArgs e)
        {
            txtNameE.BackColor = Color.LightYellow;
        }

        private void txtNameE_Leave(object sender, EventArgs e)
        {
            txtNameE.BackColor = Color.White;
        }

        private void cboGroup_Enter(object sender, EventArgs e)
        {
            cboGroup.BackColor = Color.LightYellow;
        }

        private void cboGroup_Leave(object sender, EventArgs e)
        {
            cboGroup.BackColor = Color.White;
        }

        private void cboMethod_Enter(object sender, EventArgs e)
        {
            cboMethod.BackColor = Color.LightYellow;
        }

        private void cboMethod_Leave(object sender, EventArgs e)
        {
            cboMethod.BackColor = Color.White;
        }

        private void txtPriceSale_Enter(object sender, EventArgs e)
        {
            txtPriceSale.BackColor = Color.LightYellow;
        }

        private void txtPriceSale_Leave(object sender, EventArgs e)
        {
            txtPriceSale.BackColor = Color.White;
        }

        private void txtPriceCost_Enter(object sender, EventArgs e)
        {
            txtPriceCost.BackColor = Color.LightYellow;
        }

        private void txtPriceCost_Leave(object sender, EventArgs e)
        {
            txtPriceCost.BackColor = Color.White;
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.LightYellow;
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.White;
        }

        private void btnMethodAdd_Click(object sender, EventArgs e)
        {
            FrmMethodAdd frm = new FrmMethodAdd("", cc);
            frm.ShowDialog(this);
            cboMethod = cc.medb.getCboMethod(cboMethod);
            //cboGroup = cc.itgdb.getCboItemGroup(cboGroup);
        }

        private void txtPriceSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar==46);
        }

        private void txtPriceCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == 46);
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNameT.SelectAll();
                txtNameT.Focus();
            }
        }

        private void txtNameT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNameE.SelectAll();
                txtNameE.Focus();
            }
        }

        private void txtNameE_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGroup.SelectAll();
                cboGroup.Focus();
            }
        }

        private void cboGroup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMethod.SelectAll();
                cboMethod.Focus();
            }
        }

        private void cboMethod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboDocType.SelectAll();
                cboDocType.Focus();
            }
        }

        private void txtPriceSale_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPriceCost.SelectAll();
                txtPriceCost.Focus();
            }
        }

        private void txtPriceCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPriceCostReal.SelectAll();
                txtPriceCostReal.Focus();
            }
        }

        private void cboCustPO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemark.SelectAll();
                txtRemark.Focus();
            }
        }

        private void cboCustPO_Enter(object sender, EventArgs e)
        {
            cboCustPO.BackColor = Color.LightYellow;
        }

        private void cboCustPO_Leave(object sender, EventArgs e)
        {
            cboCustPO.BackColor = Color.White;
        }

        private void txtRemark_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnSave.SelectAll();
                btnSave.Focus();
            }
        }

        private void txtPriceCostReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == 46);
        }

        private void txtPriceCostReal_Enter(object sender, EventArgs e)
        {
            txtPriceCostReal.BackColor = Color.LightYellow;
        }

        private void txtPriceCostReal_Leave(object sender, EventArgs e)
        {
            txtPriceCostReal.BackColor = Color.White;
        }

        private void btnCusAdd_Click(object sender, EventArgs e)
        {
            //61.05.17
            FrmCusAddS frm = new FrmCusAddS("", cc);
            frm.ShowDialog(this);
            cboCustPO.Items.Clear();
            cboCustPO = cc.cudb.getCboVendor(cboCustPO);
        }

        private void txtPriceCostReal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCustPO.SelectAll();
                cboCustPO.Focus();
            }
        }

        private void cboDocType_Enter(object sender, EventArgs e)
        {
            cboDocType.BackColor = Color.LightYellow;
        }

        private void cboDocType_Leave(object sender, EventArgs e)
        {
            cboDocType.BackColor = Color.White;
        }

        private void cboDocType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPriceSale.SelectAll();
                txtPriceSale.Focus();
            }
        }

        private void btnAnalysisAdd_Click(object sender, EventArgs e)
        {
            FrmAnalysisAdd frm = new FrmAnalysisAdd("", cc);
            frm.ShowDialog(this);
            cboAnalysis = cc.anadb.getCboAnalysis(cboAnalysis);
        }
    }
}
