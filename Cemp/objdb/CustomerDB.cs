using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class CustomerDB
    {
        ConnectDB conn;
        public Customer cu;
        public CustomerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cu = new Customer();
            cu.Active = "cust_active";
            cu.Addr = "addr";
            cu.AddressE = "address_e";
            cu.AddressT = "address_t";
            cu.amphurId = "amphur_id";
            cu.Code = "cust_code";
            cu.ContactName1 = "contact_name1";
            cu.ContactName1Tel = "contact_name1_tel";
            cu.ContactName2 = "contact_name2";
            cu.ContactName2Tel = "contact_name2_tel";
            cu.districtId = "district_id";
            cu.Email = "email";
            cu.Fax = "fax";
            cu.Id = "cust_id";
            cu.NameE = "cust_name_e";
            cu.NameT = "cust_name_t";
            cu.provinceId = "province_id";
            cu.Remark = "remark";
            cu.saleId = "sale_id";
            cu.saleName = "sale_name_t";
            cu.TaxId = "tax_id";
            cu.Tele = "tele";
            cu.Mobile = "mobile";
            cu.Zipcode = "zipcode";
            cu.StatusCompany = "status_company";
            cu.StatusVendor = "status_vendor";
            cu.dateCancel = "date_cancel";
            cu.dateCreate = "date_create";
            cu.dateModi = "date_modi";
            cu.userCancel = "user_cancel";
            cu.userCreate = "user_create";
            cu.userModi = "user_modi";
            cu.Remark2 = "remark2";
            cu.PODuePeriod = "po_due_period";

            cu.table = "b_customer";
            cu.pkField = "cust_id";
        }
        private Customer setData(Customer item, DataTable dt)
        {
            item.Id = dt.Rows[0][cu.Id].ToString();
            item.Active = dt.Rows[0][cu.Active].ToString();
            item.Addr = dt.Rows[0][cu.Addr].ToString();
            item.AddressE = dt.Rows[0][cu.AddressE].ToString();
            item.AddressT = dt.Rows[0][cu.AddressT].ToString();
            item.amphurId = dt.Rows[0][cu.amphurId].ToString();
            item.Code = dt.Rows[0][cu.Code].ToString();

            item.ContactName1 = dt.Rows[0][cu.ContactName1].ToString();
            item.ContactName1Tel = dt.Rows[0][cu.ContactName1Tel].ToString();
            item.ContactName2 = dt.Rows[0][cu.ContactName2].ToString();
            item.ContactName2Tel = dt.Rows[0][cu.ContactName2Tel].ToString();
            item.districtId = dt.Rows[0][cu.districtId].ToString();
            item.Email = dt.Rows[0][cu.Email].ToString();
            item.Fax = dt.Rows[0][cu.Fax].ToString();
            item.NameE = dt.Rows[0][cu.NameE].ToString();
            if (dt.Rows[0][cu.StatusCompany].ToString().Equals("1"))
            {
                item.NameT = "บริษัท "+dt.Rows[0][cu.NameT].ToString()+" จำกัด";
            }
            else if (dt.Rows[0][cu.StatusCompany].ToString().Equals("2"))
            {
                item.NameT = "บริษัท " + dt.Rows[0][cu.NameT].ToString() + " จำกัด (มหาชน)";
            }
            else
            {
                item.NameT = dt.Rows[0][cu.NameT].ToString();
            }
            
            item.provinceId = dt.Rows[0][cu.provinceId].ToString();
            item.Remark = dt.Rows[0][cu.Remark].ToString();
            item.saleId = dt.Rows[0][cu.saleId].ToString();
            item.saleName = dt.Rows[0][cu.saleName].ToString();
            item.TaxId = dt.Rows[0][cu.TaxId].ToString();
            item.Tele = dt.Rows[0][cu.Tele].ToString();
            item.Zipcode = dt.Rows[0][cu.Zipcode].ToString();
            item.StatusCompany = dt.Rows[0][cu.StatusCompany].ToString();
            item.StatusVendor = dt.Rows[0][cu.StatusVendor].ToString();
            item.dateCancel = dt.Rows[0][cu.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][cu.dateCreate].ToString();
            item.dateModi = dt.Rows[0][cu.dateModi].ToString();
            item.userCancel = dt.Rows[0][cu.userCancel].ToString();
            item.userCreate = dt.Rows[0][cu.userCreate].ToString();
            item.userModi = dt.Rows[0][cu.userModi].ToString();
            item.Remark2 = dt.Rows[0][cu.Remark2].ToString();
            item.PODuePeriod = dt.Rows[0][cu.PODuePeriod].ToString();
            item.Mobile = dt.Rows[0][cu.Mobile].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cu.table + " Where " + cu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectVendorAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cu.table + " Where " + cu.Active + "='1' and "+cu.StatusVendor+"='2'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectCustomerAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cu.table + " Where " + cu.Active + "='1' and " + cu.StatusVendor + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectCustomerAll1()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cu.table + " Where " + cu.Active + "='1' and " + cu.StatusVendor + "='1' Order By "+cu.NameT+" asc";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectCustomerList()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select "+cu.Code+","+cu.NameT+","+cu.NameE+" From " + cu.table + " Where " + cu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Customer selectByPk(String cuId)
        {
            Customer item = new Customer();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cu.table + " Where " + cu.pkField + "='" + cuId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Customer selectByCode(String cuId)
        {
            Customer item = new Customer();
            String sql = "";

            sql = "Select * From " + cu.table + " Where " + cu.Code + "='" + cuId + "' and " + cu.Active + "='1' ";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, conn.dt);
            }
            return item;
        }
        public Customer selectByNameT(String cuId)
        {
            Customer item = new Customer();
            String sql = "";

            sql = "Select * From " + cu.table + " Where " + cu.NameT + "='" + cuId + "' and " + cu.Active + "='1' ";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, conn.dt);
            }
            return item;
        }
        public String selectIdByNameT(String cuId)
        {
            Customer item = new Customer();
            String sql = "", id="";

            sql = "Select * From " + cu.table + " Where " + cu.NameT + "='" + cuId + "' and " + cu.Active + "='1' ";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0][cu.Id].ToString();
            }
            
            return id;
        }
        private String insert(Customer p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "cu"+p.getGenID();
            }

            p.Addr = p.Addr.Replace("'", "''");
            p.AddressE = p.AddressE.Replace("'", "''");
            p.AddressT = p.AddressT.Replace("'", "''");
            p.AddressE = p.AddressE.Replace("'", "''");
            p.ContactName1 = p.ContactName1.Replace("'", "''");
            p.ContactName2 = p.ContactName2.Replace("'", "''");
            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            p.saleName = p.saleName.Replace("'", "''");
            p.Remark2 = p.Remark2.Replace("'", "''");
            p.NameT = p.NameT.Replace("บริษัท", "");
            p.NameT = p.NameT.Replace("จำกัด", "");
            p.NameT = p.NameT.Replace("(มหาชน)", "");
            p.NameE = p.NameE.Replace("Co., Ltd.", "");
            p.NameT = p.NameT.Trim();

            sql = "Insert Into " + cu.table + " (" + cu.pkField + "," + cu.Active + "," + cu.Addr + "," +
                cu.AddressE + "," + cu.AddressT + "," + cu.amphurId + "," +
                cu.Code + "," + cu.ContactName1 + "," + cu.ContactName1Tel + "," +
                cu.ContactName2 + "," + cu.ContactName2Tel + "," + cu.districtId + "," +
                cu.Email + "," + cu.Fax + "," + cu.NameE + "," +
                cu.NameT + "," + cu.provinceId + "," + cu.Remark + "," +
                cu.saleId + "," + cu.saleName + "," + cu.TaxId + "," +
                cu.Tele + "," + cu.Zipcode + "," + cu.StatusCompany + "," +
                cu.StatusVendor + "," + cu.Remark2 + "," + cu.PODuePeriod + "," +
                cu.dateCreate + "," + cu.dateModi + "," + cu.dateCancel + "," +
                cu.userCancel + "," + cu.userCreate + "," + cu.userModi + "," + cu.Mobile + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.Addr + "','" +
                p.AddressE + "','" + p.AddressT + "','" + p.amphurId + "','" +
                p.Code + "','" + p.ContactName1 + "','" + p.ContactName1Tel + "','" +
                p.ContactName2 + "','" + p.ContactName2Tel + "','" + p.districtId + "','" +
                p.Email + "','" + p.Fax + "','" + p.NameE.Replace("Co., Ltd.", "").Trim() + "','" +
                p.NameT.Trim() + "','" + p.provinceId + "','" + p.Remark + "','" +
                p.saleId + "','" + p.saleName + "','" + p.TaxId + "','" +
                p.Tele + "','" + p.Zipcode + "','" + p.StatusCompany + "','" +
                p.StatusVendor + "','" + p.Remark2 + "'," + NumberNull1(p.PODuePeriod) + "," +
                p.dateGenDB + ",'" + p.dateModi + "','" + p.dateCancel + "','" +
                p.userCancel + "','" + p.userCreate + "','" + p.userModi + "','" + p.Mobile + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Customer");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Customer p)
        {
            String sql = "", chk = "";

            p.Addr = p.Addr.Replace("'", "''");
            p.AddressE = p.AddressE.Replace("'", "''");
            p.AddressT = p.AddressT.Replace("'", "''");
            p.AddressE = p.AddressE.Replace("'", "''");
            p.ContactName1 = p.ContactName1.Replace("'", "''");
            p.ContactName2 = p.ContactName2.Replace("'", "''");
            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            p.saleName = p.saleName.Replace("'", "''");
            p.Remark2 = p.Remark2.Replace("'", "''");
            p.NameT = p.NameT.Replace("บริษัท", "");
            p.NameT = p.NameT.Replace("จำกัด", "");
            p.NameE = p.NameE.Replace("Co., Ltd.", "");
            p.NameT = p.NameT.Replace("(มหาชน)", "");
            p.NameT = p.NameT.Trim();
            sql = "Update " + cu.table + " Set " + cu.Addr + "='" + p.Addr + "', " +
                cu.AddressE + "='" + p.AddressE + "', " +
                cu.AddressT + "='" + p.AddressT + "', " +
                cu.amphurId + "='" + p.amphurId + "', " +
                cu.ContactName1 + "='" + p.ContactName1 + "', " +
                cu.Code + "='" + p.Code + "', " +
                cu.ContactName1Tel + "='" + p.ContactName1Tel + "', " +
                cu.ContactName2 + "='" + p.ContactName2 + "', " +
                cu.ContactName2Tel + "='" + p.ContactName2Tel + "', " +
                cu.districtId + "='" + p.districtId + "', " +
                cu.Email + "='" + p.Email + "', " +
                cu.Fax + "='" + p.Fax + "', " +
                cu.NameE + "='" + p.NameE.Trim() + "', " +
                cu.NameT + "='" + p.NameT.Trim() + "', " +
                cu.provinceId + "='" + p.provinceId + "', " +
                cu.Remark + "='" + p.Remark + "', " +
                cu.saleId + "='" + p.saleId + "', " +
                cu.saleName + "='" + p.saleName + "', " +
                cu.TaxId + "='" + p.TaxId + "', " +
                cu.Tele + "='" + p.Tele + "', " +
                cu.Zipcode + "='" + p.Zipcode + "', " +
                cu.StatusCompany + "='" + p.StatusCompany + "', " +
                cu.StatusVendor + "='" + p.StatusVendor + "', " +
                cu.Remark2 + "='" + p.Remark2 + "', " +
                cu.PODuePeriod + "=" + NumberNull1(p.PODuePeriod) + ", " +
                cu.dateModi + "=" + p.dateGenDB + ", " +
                cu.Mobile + "='" + p.Mobile + "' " +
                "Where " + cu.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Customer");
            }
            finally
            {
            }
            return chk;
        }
        public String insertCustomer(Customer p)
        {
            Customer item = new Customer();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
                p.Active = "1";
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + cu.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        
        public ComboBox getCboCustomer(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectCustomerAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                if (dt.Rows[i][cu.StatusCompany].ToString().Equals("1"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด";
                }
                else if (dt.Rows[i][cu.StatusCompany].ToString().Equals("2"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด (มหาชน)";
                }
                else
                {
                    item.Text = dt.Rows[i][cu.NameT].ToString();
                }
                item.Value = dt.Rows[i][cu.Id].ToString();
                //item.Text = dt.Rows[i][cu.NameT].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public ComboBox getCboCustomer1(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectCustomerAll1();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                if (dt.Rows[i][cu.StatusCompany].ToString().Equals("1"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด";
                }
                else if (dt.Rows[i][cu.StatusCompany].ToString().Equals("2"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด (มหาชน)";
                }
                else
                {
                    item.Text = dt.Rows[i][cu.NameT].ToString();
                }
                item.Value = dt.Rows[i][cu.Id].ToString();
                //item.Text = dt.Rows[i][cu.NameT].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public ComboBox getCboVendor(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectVendorAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                if (dt.Rows[i][cu.StatusCompany].ToString().Equals("1"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด";
                }
                else if (dt.Rows[i][cu.StatusCompany].ToString().Equals("2"))
                {
                    item.Text = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด (มหาชน)";
                }
                else
                {
                    item.Text = dt.Rows[i][cu.NameT].ToString();
                }
                item.Value = dt.Rows[i][cu.Id].ToString();
                //item.Text = dt.Rows[i][cu.NameT].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidCustomer(String saleId)
        {
            String sql = "", chk = "";
            sql = "Update " + cu.table + " Set " + cu.Active + "='3', " + cu.dateCancel + "=" + cu.dateGenDB + " " +
                "Where " + cu.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String selectCodeMax()
        {
            //Customer item = new Customer();
            String sql = "",year="";
            if (System.DateTime.Now.Year > 2550)
            {
                year = System.DateTime.Now.Year.ToString().Substring(2);
            }
            else
            {
                year = String.Concat(System.DateTime.Now.Year + 543);
            }
            year = year.Substring(2);
            sql = "Select count(1) as cnt From " + cu.table ;
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                sql = "00000" + String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                sql = sql.Substring(sql.Length - 5);
            }
            else
            {
                sql = "00001";
            }
            return "CU" + year + sql;
        }
        private String NumberNull1(String o)
        {
            if (o.Equals(""))
            {
                return "0";
            }
            else
            {
                return o;
            }
        }
        public List<Customer> getListCustomer(List<Customer> item)
        {
            //ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Customer me1 = new Customer();
                me1.Id = dt.Rows[i][cu.Id].ToString();
                me1.Active = dt.Rows[i][cu.Active].ToString();
                me1.Addr = dt.Rows[i][cu.Addr].ToString();
                me1.AddressE = dt.Rows[i][cu.AddressE].ToString();
                me1.AddressT = dt.Rows[i][cu.AddressT].ToString();
                me1.amphurId = dt.Rows[i][cu.amphurId].ToString();
                me1.Code = dt.Rows[i][cu.Code].ToString();

                me1.ContactName1 = dt.Rows[i][cu.ContactName1].ToString();
                me1.ContactName1Tel = dt.Rows[i][cu.ContactName1Tel].ToString();
                me1.ContactName2 = dt.Rows[i][cu.ContactName2].ToString();
                me1.ContactName2Tel = dt.Rows[i][cu.ContactName2Tel].ToString();
                me1.districtId = dt.Rows[i][cu.districtId].ToString();
                me1.Email = dt.Rows[i][cu.Email].ToString();
                me1.Fax = dt.Rows[i][cu.Fax].ToString();
                me1.NameE = dt.Rows[i][cu.NameE].ToString();
                if (dt.Rows[i][cu.StatusCompany].ToString().Equals("1"))
                {
                    me1.NameT = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด";
                }
                else if (dt.Rows[i][cu.StatusCompany].ToString().Equals("2"))
                {
                    me1.NameT = "บริษัท " + dt.Rows[i][cu.NameT].ToString() + " จำกัด (มหาชน)";
                }
                else
                {
                    me1.NameT = dt.Rows[i][cu.NameT].ToString();
                }

                me1.provinceId = dt.Rows[i][cu.provinceId].ToString();
                me1.Remark = dt.Rows[i][cu.Remark].ToString();
                me1.saleId = dt.Rows[i][cu.saleId].ToString();
                me1.saleName = dt.Rows[i][cu.saleName].ToString();
                me1.TaxId = dt.Rows[i][cu.TaxId].ToString();
                me1.Tele = dt.Rows[i][cu.Tele].ToString();
                me1.Zipcode = dt.Rows[i][cu.Zipcode].ToString();
                me1.StatusCompany = dt.Rows[i][cu.StatusCompany].ToString();
                me1.StatusVendor = dt.Rows[i][cu.StatusVendor].ToString();
                me1.dateCancel = dt.Rows[i][cu.dateCancel].ToString();
                me1.dateCreate = dt.Rows[i][cu.dateCreate].ToString();
                me1.dateModi = dt.Rows[i][cu.dateModi].ToString();
                me1.userCancel = dt.Rows[i][cu.userCancel].ToString();
                me1.userCreate = dt.Rows[i][cu.userCreate].ToString();
                me1.userModi = dt.Rows[i][cu.userModi].ToString();
                me1.Remark2 = dt.Rows[i][cu.Remark2].ToString();
                me1.PODuePeriod = dt.Rows[i][cu.PODuePeriod].ToString();
                me1.Mobile = dt.Rows[i][cu.Mobile].ToString();

                item.Add(me1);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return item;
        }
    }
}
