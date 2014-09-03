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
    public partial class FrmCustAdd : Form
    {
        CnviControl cc;
        Customer cu;
        Boolean pageLoad = false, keyDistrict = false;
        public FrmCustAdd(String cuId,CnviControl c)
        {
            InitializeComponent();
            initConfig(cuId,c);
        }
        private void initConfig(String cuId, CnviControl c)
        {
            pageLoad = true;
            cc = c;
            //sf = cc.sfdb.selectByPk(sfId);
            cu = new Customer();
            setControl(cuId);
            txtCode.ReadOnly = true;
            pageLoad = false;
        }
        private void setControl(String cuId)
        {
            cu = cc.cudb.selectByPk(cuId);
            txtId.Text = cu.Id;
            txtCode.Text = cu.Code;
            txtAddr.Text = cu.Addr;
            txtAddressE.Text = cu.AddressE;
            txtAddressT.Text = cu.AddressT;
            txtEmail.Text = cu.Email;
            TxtFax.Text = cu.Fax;
            txtNameE.Text = cu.NameE;
            txtNameT.Text = cu.NameT;
            txtTaxID.Text = cu.TaxId;
            txtTele.Text = cu.Tele;
            txtZipcode.Text = cu.Zipcode;
            //cboAmphur.SelectedItem = cu.amphurId;
            //cboDistrict.SelectedItem = cu.districtId;
            //cboProvince.SelectedItem = cu.provinceId;
            txtContactName1.Text = cu.ContactName1;
            txtContactName1Tel.Text = cu.ContactName1Tel;
            txtContactName2.Text = cu.ContactName2;
            txtContactName2Tel.Text = cu.ContactName2Tel;
            txtRemark.Text = cu.Remark;
            if (cu.Active.Equals("1"))
            {
                chkActive.Checked = true;
                ChkUnActive.Checked = false;
            }
            else
            {
                chkActive.Checked = false;
                ChkUnActive.Checked = true;
            }
            label18.Text = cu.districtId;
            if (label18.Text.Length > 4)
            {
                cboDistrict = cc.didb.getCboDist1(cboDistrict, label18.Text);
                cboAmphur = cc.amdb.getCboAmphur1(cboAmphur, label18.Text.Substring(0, 4));
                cboProvince = cc.prdb.getCboProv1(cboProvince, label18.Text.Substring(0, 2));
            }
            
        }
        private void getCustomer()
        {
            cu.Id = txtId.Text;
            cu.Code = txtCode.Text;
            cu.Addr = txtAddr.Text;
            cu.AddressE = txtAddressE.Text;
            cu.AddressT = txtAddressT.Text;
            cu.Email = txtEmail.Text;
            cu.Fax = TxtFax.Text;
            cu.NameE = txtNameE.Text;
            cu.NameT = txtNameT.Text;
            cu.TaxId = txtTaxID.Text;
            cu.Tele = txtTele.Text;
            cu.Zipcode = txtZipcode.Text;
            cu.amphurId = cc.cf.getValueCboItem(cboAmphur);
            cu.districtId = cc.cf.getValueCboItem(cboDistrict);
            cu.provinceId = cc.cf.getValueCboItem(cboProvince);
            cu.ContactName1 = txtContactName1.Text;
            cu.ContactName1Tel = txtContactName1Tel.Text;
            cu.ContactName2 = txtContactName2.Text;
            cu.ContactName2Tel = txtContactName2Tel.Text;
            cu.Remark = txtRemark.Text;
        }
        private void FrmCustAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameE.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้ป้อนชื่อ", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (txtNameT.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้ป้อนName", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (txtNameT.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้ป้อนName", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (txtId.Text.Equals(""))
            {
                cu = cc.cudb.selectByCode(txtCode.Text);
                if (!cu.Code.Equals(""))
                {
                    MessageBox.Show("ป้อนรหัสซ้ำ\nรหัส " + cu.Code + " ชื่อ " + cu.NameT, "รหัสซ้ำ");
                    return;
                }
                //if (!cu.Code.Equals(""))
                //{
                //    MessageBox.Show("ป้อนชื่อซ้ำ\nรหัส " + cu.Code + " ชื่อ " + cu.NameT, "ชื่อซ้ำ");
                //    return;
                //}
            }
            getCustomer();
            if (cc.cudb.insertCustomer(cu).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;

                txtId.Enabled = true;
                txtCode.Enabled = true;
                txtAddr.Enabled = true;
                txtAddressE.Enabled = true;
                txtAddressT.Enabled = true;
                txtEmail.Enabled = true;
                TxtFax.Enabled = true;
                txtNameE.Enabled = true;
                txtNameT.Enabled = true;
                txtTaxID.Enabled = true;
                txtTele.Enabled = true;
                txtZipcode.Enabled = true;
                cboAmphur.Enabled = true;
                cboDistrict.Enabled = true;
                cboProvince.Enabled = true;
                txtContactName1.Enabled = true;
                txtContactName1Tel.Enabled = true;
                txtContactName2.Enabled = true;
                txtContactName2Tel.Enabled = true;
            }
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;

                txtId.Enabled = false;
                txtCode.Enabled = false;
                txtAddr.Enabled = false;
                txtAddressE.Enabled = false;
                txtAddressT.Enabled = false;
                txtEmail.Enabled = false;
                TxtFax.Enabled = false;
                txtNameE.Enabled = false;
                txtNameT.Enabled = false;
                txtTaxID.Enabled = false;
                txtTele.Enabled = false;
                txtZipcode.Enabled = false;
                cboAmphur.Enabled = false;
                cboDistrict.Enabled = false;
                cboProvince.Enabled = false;
                txtContactName1.Enabled = false;
                txtContactName1Tel.Enabled = false;
                txtContactName2.Enabled = false;
                txtContactName2Tel.Enabled = false;
            }
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                cc.cudb.VoidCustomer(txtId.Text);
                this.Dispose();
            }
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                String aaa = "";
                aaa = cc.cf.getValueCboItem(cboDistrict);
                label18.Text = aaa;
            }
        }

        private void cboDistrict_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (keyDistrict))
            {
                cboDistrict = cc.didb.getCboDist1(cboDistrict, label18.Text);
                cboAmphur = cc.amdb.getCboAmphur1(cboAmphur, label18.Text.Substring(0, 4));
                cboProvince = cc.prdb.getCboProv1(cboProvince, label18.Text.Substring(0, 2));
                txtZipcode.Text = cc.didb.selectZipCodeByPk(label18.Text);
            }
            else if (e.KeyCode == Keys.Down)
            {
                keyDistrict = true;
                //    aaa = cc.cf.getValueCboItem(cboDistrict);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (cboDistrict.Text.Length >= 3)
                {
                    cboDistrict = cc.didb.getCboDistrict1(cboDistrict, cboDistrict.Text);
                }
            }
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

        private void txtAddr_Enter(object sender, EventArgs e)
        {
            txtAddr.BackColor = Color.LightYellow;
        }

        private void txtAddr_Leave(object sender, EventArgs e)
        {
            txtAddr.BackColor = Color.White;
        }

        private void cboDistrict_Enter(object sender, EventArgs e)
        {
            cboDistrict.BackColor = Color.LightYellow;
        }

        private void cboDistrict_Leave(object sender, EventArgs e)
        {
            cboDistrict.BackColor = Color.White;
        }

        private void cboAmphur_Enter(object sender, EventArgs e)
        {
            cboAmphur.BackColor = Color.LightYellow;
        }

        private void cboAmphur_Leave(object sender, EventArgs e)
        {
            cboAmphur.BackColor = Color.White;
        }

        private void cboProvince_Enter(object sender, EventArgs e)
        {
            cboProvince.BackColor = Color.LightYellow;
        }

        private void cboProvince_Layout(object sender, LayoutEventArgs e)
        {
            cboProvince.BackColor = Color.White;
        }

        private void txtZipcode_Enter(object sender, EventArgs e)
        {
            txtZipcode.BackColor = Color.LightYellow;
        }

        private void txtZipcode_Leave(object sender, EventArgs e)
        {
            txtZipcode.BackColor = Color.White;
        }

        private void txtAddressT_Enter(object sender, EventArgs e)
        {
            txtAddressT.BackColor = Color.LightYellow;
        }

        private void txtAddressT_Leave(object sender, EventArgs e)
        {
            txtAddressT.BackColor = Color.White;
        }

        private void txtAddressE_Enter(object sender, EventArgs e)
        {
            txtAddressE.BackColor = Color.LightYellow;
        }

        private void txtAddressE_Leave(object sender, EventArgs e)
        {
            txtAddressE.BackColor = Color.White;
        }

        private void txtTele_Enter(object sender, EventArgs e)
        {
            txtTele.BackColor = Color.LightYellow;
        }

        private void txtTele_Leave(object sender, EventArgs e)
        {
            txtTele.BackColor = Color.White;
        }

        private void TxtFax_Enter(object sender, EventArgs e)
        {
            TxtFax.BackColor = Color.LightYellow;
        }

        private void TxtFax_Leave(object sender, EventArgs e)
        {
            TxtFax.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightYellow;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
        }

        private void txtTaxID_Enter(object sender, EventArgs e)
        {
            txtTaxID.BackColor = Color.LightYellow;
        }

        private void txtTaxID_Leave(object sender, EventArgs e)
        {
            txtTaxID.BackColor = Color.White;
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.LightYellow;
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.White;
        }

        private void txtContactName1_Enter(object sender, EventArgs e)
        {
            txtContactName1.BackColor = Color.LightYellow;
        }

        private void txtContactName1_Leave(object sender, EventArgs e)
        {
            txtContactName1.BackColor = Color.White;
        }

        private void txtContactName1Tel_Enter(object sender, EventArgs e)
        {
            txtContactName1Tel.BackColor = Color.LightYellow;
        }

        private void txtContactName1Tel_Leave(object sender, EventArgs e)
        {
            txtContactName1Tel.BackColor = Color.White;
        }

        private void txtContactName2_Enter(object sender, EventArgs e)
        {
            txtContactName2.BackColor = Color.LightYellow;
        }

        private void txtContactName2_Leave(object sender, EventArgs e)
        {
            txtContactName2.BackColor = Color.White;
        }

        private void txtContactName2Tel_Enter(object sender, EventArgs e)
        {
            txtContactName2Tel.BackColor = Color.LightYellow;
        }

        private void txtContactName2Tel_Leave(object sender, EventArgs e)
        {
            txtContactName2Tel.BackColor = Color.White;
        }
    }
}
