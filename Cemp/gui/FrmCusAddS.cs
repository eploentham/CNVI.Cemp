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
    public partial class FrmCusAddS : Form
    {
        CnviControl cc;
        Customer cu;

        public FrmCusAddS(String cuId, CnviControl c)
        {
            InitializeComponent();
            initConfig(cuId, c);
        }
        private void initConfig(String cuId, CnviControl c)
        {
            cc = c;
            cu = new Customer();
            //setControl(cuId);
        }
        private void setCustomer()
        {
            cu.Id = txtId.Text;
            cu.Code = cc.cudb.selectCodeMax();
            cu.NameT = txtNameT.Text;
            cu.NameE = "";
            cu.Addr = "";
            cu.AddressE = "";
            cu.AddressT = "";
            cu.Email = "";
            cu.Fax = "";
            //cu.NameE = "";
            //cu.NameT = "";
            cu.TaxId = "";
            cu.Tele = "";
            cu.Zipcode = "";
            cu.amphurId = "";
            cu.districtId = "";
            cu.provinceId = "";
            cu.ContactName1 = "";
            cu.ContactName1Tel = "";
            cu.ContactName2 = "";
            cu.ContactName2Tel = "";
            cu.Remark = txtRemark.Text;
            cu.PODuePeriod = "";
            
            cu.StatusCompany = "1";
            
            
            cu.StatusVendor = "2";
            
            cu.Mobile ="";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            setCustomer();
            if (cc.cudb.insertCustomer(cu).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }
    }
}
