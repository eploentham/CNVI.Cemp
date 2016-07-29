using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*
 * 58.01.13.01  คุณกรณ์ แจ้งขอแก้ไข     หน้าView ให้กรองปี 
 * 59.07.29.01  คุณกรณ์แจ้งว่า save ไม่แสดง แต่check ดูแล้ว เลขที่เอกสาร "000" เต็ม แก้ไข เพิ่ม "0000" คิดว่าพอ
 
 * */
namespace Cemp.objdb
{
    public class QuotationDB
    {
        ConnectDB conn;
        public Quotation qu;
        public QuotationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            qu = new Quotation();
            qu.Amount = "amount";
            qu.AmountDiscount = "amount_discount";
            qu.CompAddress1 = "comp_address1";
            qu.CompAddress2 = "comp_address2";
            qu.CompId = "comp_id";
            qu.CompName = "comp_name";
            qu.CompTaxId = "comp_tax_id";
            qu.ContactName = "contact_name";
            qu.CustAddress = "cust_address";
            qu.CustEmail = "cust_email";
            qu.CustFax = "cust_fax";
            qu.CustId = "cust_id";
            qu.CustName = "cust_name";
            qu.CustTel = "cust_tel";
            qu.DiscountPer = "discount_per";
            qu.Discount = "discount";
            qu.Id = "quo_id";
            qu.Line1 = "line1";
            qu.Line2 = "line2";
            qu.Line3 = "line3";
            qu.Line4 = "line4";
            qu.Line5 = "line5";
            qu.Line6 = "line6";
            qu.NetTotal = "nettotal";
            qu.Plus1 = "plus1";
            qu.Plus1Name = "plus1_name";
            qu.Active = "quo_active";
            qu.QuoDate = "quo_date";
            qu.QuoNumber = "quo_number";
            qu.Remark1 = "remark1";
            qu.Remark2 = "remark2";
            qu.Remark3 = "remark3";
            qu.StaffEmail = "staff_email";
            qu.StaffId = "staff_id";
            qu.StaffName = "staff_name";
            qu.StaffTel = "staff_tel";
            qu.StatusQuo = "status_quo";
            qu.Total = "total";
            qu.Vat = "vat";
            qu.VatRate = "vat_rate";
            qu.StaffApproveId = "staff_approve_id";
            qu.StaffApproveName = "staff_approve_name";
            qu.QuoNumberCnt = "quo_number_cnt";
            qu.StatusMOU = "status_mou";
            qu.Remark4 = "remark4";
            qu.Remark5 = "remark5";
            qu.Remark6 = "remark6";
            qu.Remark7 = "remark7";
            qu.dateCancel = "date_cancel";
            qu.dateCreate = "date_create";
            qu.dateModi = "date_modi";

            qu.userCancel = "user_cancel";
            qu.userCreate = "user_create";
            qu.userModi = "user_modi";
            qu.PathPicConfirm = "pathpicconfirm";

            qu.YearId = "year_id";
            qu.QuExId = "quo_ex_id";

            qu.table = "t_quotation";
            qu.pkField = "quo_id";
        }
        private Quotation setData(Quotation item, DataTable dt)
        {
            item.Amount = dt.Rows[0][qu.Amount].ToString();
            item.AmountDiscount = dt.Rows[0][qu.AmountDiscount].ToString();
            item.CompAddress1 = dt.Rows[0][qu.CompAddress1].ToString();
            item.CompAddress2 = dt.Rows[0][qu.CompAddress2].ToString();
            item.CompId = dt.Rows[0][qu.CompId].ToString();
            item.CompName = dt.Rows[0][qu.CompName].ToString();
            item.CompTaxId = dt.Rows[0][qu.CompTaxId].ToString();
            item.ContactName = dt.Rows[0][qu.ContactName].ToString();
            item.CustAddress = dt.Rows[0][qu.CustAddress].ToString();
            item.CustEmail = dt.Rows[0][qu.CustEmail].ToString();
            item.CustFax = dt.Rows[0][qu.CustFax].ToString();
            item.CustId = dt.Rows[0][qu.CustId].ToString();
            item.CustName = dt.Rows[0][qu.CustName].ToString();
            item.CustTel = dt.Rows[0][qu.CustTel].ToString();
            item.DiscountPer = dt.Rows[0][qu.DiscountPer].ToString();
            item.Id = dt.Rows[0][qu.Id].ToString();
            item.Line1 = dt.Rows[0][qu.Line1].ToString();
            item.Line2 = dt.Rows[0][qu.Line2].ToString();
            item.Line3 = dt.Rows[0][qu.Line3].ToString();
            item.Line4 = dt.Rows[0][qu.Line4].ToString();
            item.Line5 = dt.Rows[0][qu.Line5].ToString();
            item.Line6 = dt.Rows[0][qu.Line6].ToString();
            item.NetTotal = dt.Rows[0][qu.NetTotal].ToString();
            item.Plus1 = dt.Rows[0][qu.Plus1].ToString();
            item.Plus1Name = dt.Rows[0][qu.Plus1Name].ToString();
            item.Active = dt.Rows[0][qu.Active].ToString();
            item.QuoDate = dt.Rows[0][qu.QuoDate].ToString();
            item.QuoNumber = dt.Rows[0][qu.QuoNumber].ToString();
            item.Remark1 = dt.Rows[0][qu.Remark1].ToString();
            item.Remark2 = dt.Rows[0][qu.Remark2].ToString();
            item.Remark3 = dt.Rows[0][qu.Remark3].ToString();
            item.StaffEmail = dt.Rows[0][qu.StaffEmail].ToString();
            item.StaffId = dt.Rows[0][qu.StaffId].ToString();
            item.StaffName = dt.Rows[0][qu.StaffName].ToString();
            item.StaffTel = dt.Rows[0][qu.StaffTel].ToString();
            item.StatusQuo = dt.Rows[0][qu.StatusQuo].ToString();
            item.Total = dt.Rows[0][qu.Total].ToString();
            item.Vat = dt.Rows[0][qu.Vat].ToString();
            item.VatRate = dt.Rows[0][qu.VatRate].ToString();
            item.Discount = dt.Rows[0][qu.Discount].ToString();
            item.StaffApproveId = dt.Rows[0][qu.StaffApproveId].ToString();
            item.StaffApproveName = dt.Rows[0][qu.StaffApproveName].ToString();
            item.QuoNumberCnt = dt.Rows[0][qu.QuoNumberCnt].ToString();
            item.StatusMOU = dt.Rows[0][qu.StatusMOU].ToString();
            item.Remark4 = dt.Rows[0][qu.Remark4].ToString();
            item.Remark5 = dt.Rows[0][qu.Remark5].ToString();
            item.Remark6 = dt.Rows[0][qu.Remark6].ToString();
            item.Remark7 = dt.Rows[0][qu.Remark7].ToString();
            item.dateCancel = dt.Rows[0][qu.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][qu.dateCreate].ToString();
            item.dateModi = dt.Rows[0][qu.dateModi].ToString();

            item.userCancel = dt.Rows[0][qu.userCancel].ToString();
            item.userCreate = dt.Rows[0][qu.userCreate].ToString();
            item.userModi = dt.Rows[0][qu.userModi].ToString();

            item.PathPicConfirm = dt.Rows[0][qu.PathPicConfirm].ToString();
            item.PathPicConfirm = item.PathPicConfirm.Replace("@","\\");
            item.YearId = dt.Rows[0][qu.YearId].ToString();

            item.QuExId = dt.Rows[0][qu.QuExId].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qu.table + " Where " + qu.Active + "='1' Order By " + qu.QuoNumber + " desc," + qu.QuoNumberCnt + " desc";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectAll(String YearId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            //if (YearId.Equals(""))
            //{
            //    sql = "Select * From " + qu.table + " Where " + qu.Active + "='1' Order By " + qu.QuoNumber + " desc," + qu.QuoNumberCnt + " desc";
            //}
            //else
            //{
                sql = "Select * From " + qu.table + " Where " + qu.Active + "='1' and " + qu.YearId + "='" + YearId + "' Order By " + qu.QuoNumber + " desc," + qu.QuoNumberCnt + " desc";
            //}
            
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectQuoConfirmNoMOU()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qu.table + " Where " + qu.Active + "='1' and " + qu.StatusQuo + "='2' and "+qu.StatusMOU+" = '1' Order By " + qu.QuoNumber + " desc," + qu.QuoNumberCnt + " desc";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectQuoConfirm()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qu.table + " Where " + qu.Active + "='1' and "+qu.StatusQuo+"='2' Order By " + qu.QuoNumber + " desc," + qu.QuoNumberCnt + " desc";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark1()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct "+qu.Remark1+" From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark2()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark2 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark3()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark3 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark4()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark4 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark5()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark5 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark6()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark6 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctRemark7()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.Remark7 + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Quotation selectByPk(String saleId)
        {
            Quotation item = new Quotation();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qu.table + " Where " + qu.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Quotation selectByNumber(String quId)
        {
            Quotation item = new Quotation();
            String sql = "";

            sql = "Select * From " + qu.table + " Where " + qu.QuoNumber + "='" + quId + "'" ;
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, conn.dt);
            }
            return item;
        }
        public DataTable selectPrintById(String quId)
        {
            //Quotation item = new Quotation();
            String sql = "";

            sql = "Select * From " + qu.table + "  Where " + qu.pkField + "='" + quId + "'";
                //" Where qu." + qu.Id + "='" + quId + "'";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            dt.TableName = qu.table;
            return dt;
        }
        public DataTable selectPrintById1(String quId)
        {
            //Quotation item = new Quotation();
            String sql = "";

            sql = "Select qu.*,qui.* "+
                "From " + qu.table + " as qu "+
                "inner join t_quotation_item qui on qu.quo_id = qui.quo_id "+
                " Where qu." + qu.Id + "='" + quId + "'";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectYearId()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qu.YearId + " From " + qu.table + " Where " + qu.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(Quotation p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "qu"+p.getGenID();
            }
            p.CompAddress1 = p.CompAddress1.Replace("'", "''");
            p.Remark1 = p.Remark1.Replace("'", "''");
            p.Remark2 = p.Remark2.Replace("'", "''");
            p.Remark3 = p.Remark3.Replace("'", "''");
            p.CompAddress2 = p.CompAddress2.Replace("'", "''");
            p.CompName = p.CompName.Replace("'", "''");
            p.ContactName = p.ContactName.Replace("'", "''");
            p.CustAddress = p.CustAddress.Replace("'", "''");
            p.CustName = p.CustName.Replace("'", "''");
            p.Plus1Name = p.Plus1Name.Replace("'", "''");
            p.StaffName = p.StaffName.Replace("'", "''");
            p.StaffApproveName = p.StaffApproveName.Replace("'", "''");

            p.Line1 = p.Line1.Replace("'", "''");
            p.Line2 = p.Line2.Replace("'", "''");
            p.Line3 = p.Line3.Replace("'", "''");
            p.Line4 = p.Line4.Replace("'", "''");
            p.Line5 = p.Line5.Replace("'", "''");
            p.Line6 = p.Line6.Replace("'", "''");

            p.Remark4 = p.Remark4.Replace("'", "''");
            p.Remark5 = p.Remark5.Replace("'", "''");
            p.Remark6 = p.Remark6.Replace("'", "''");
            p.Remark7 = p.Remark7.Replace("'", "''");

            p.QuoNumberCnt = "1";
            p.StatusMOU = "1";
            
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + qu.table + " (" + qu.pkField + "," + qu.Amount + "," + qu.AmountDiscount + "," +
                qu.CompAddress1 + "," + qu.CompAddress2 + "," + qu.CompId + "," +
                qu.CompName + "," + qu.CompTaxId + "," + qu.ContactName + "," +
                qu.CustAddress + "," + qu.CustEmail + "," + qu.CustFax + "," +
                qu.CustId + "," + qu.CustName + "," + qu.CustTel + "," +
                qu.DiscountPer + "," + qu.Line1 + "," + qu.Line2 + "," +
                qu.Line3 + "," + qu.Line4 + "," + qu.Line5 + "," +
                qu.Line6 + "," + qu.NetTotal + "," + qu.Plus1 + "," +
                qu.Plus1Name + "," + qu.Active + "," + qu.QuoDate + "," +
                qu.QuoNumber + "," + qu.Remark1 + "," + qu.Remark2 + "," +
                qu.Remark3 + "," + qu.StaffEmail + "," + qu.StaffId + "," +
                qu.StaffName + "," + qu.StaffTel + "," + qu.StatusQuo + "," +
                qu.Total + "," + qu.Vat + "," + qu.VatRate + "," +
                qu.StaffApproveId + "," + qu.StaffApproveName + "," + qu.Discount + "," +
                qu.QuoNumberCnt + "," + qu.StatusMOU + "," + qu.Remark4 + "," + 
                qu.Remark5 + "," + qu.Remark6 + "," + qu.Remark7 + "," + 
                qu.dateCreate + "," + qu.YearId + ") " +
                "Values('" + p.Id + "'," + NumberNull1(p.Amount) + "," + NumberNull1(p.AmountDiscount) + ",'" +
                p.CompAddress1 + "','" + p.CompAddress2 + "','" + p.CompId + "','" +
                p.CompName + "','" + p.CompTaxId + "','" + p.ContactName + "','" +
                p.CustAddress + "','" + p.CustEmail + "','" + p.CustFax + "','" +
                p.CustId + "','" + p.CustName + "','" + p.CustTel + "'," +
                NumberNull1(p.DiscountPer) + ",'" + p.Line1 + "','" + p.Line2 + "','" +
                p.Line3 + "','" + p.Line4 + "','" + p.Line5 + "','" +
                p.Line6 + "'," + NumberNull1(p.NetTotal) + "," + NumberNull1(p.Plus1) + ",'" +
                p.Plus1Name + "','" + p.Active + "','" + p.QuoDate + "','" +
                p.QuoNumber + "','" + p.Remark1 + "','" + p.Remark2 + "','" +
                p.Remark3 + "','" + p.StaffEmail + "','" + p.StaffId + "','" +
                p.StaffName + "','" + p.StaffTel + "','" + p.StatusQuo + "'," +
                NumberNull1(p.Total) + "," + NumberNull1(p.Vat) + "," + NumberNull1(p.VatRate) + ",'" +
                p.StaffApproveId + "','" + p.StaffApproveName + "'," + NumberNull1(p.Discount) + "," +
                NumberNull1(p.QuoNumberCnt) + ",'" + p.StatusMOU + "','" + p.Remark4 + "','" + 
                p.Remark5 + "','" + p.Remark6 + "','" + p.Remark7 + "'," + 
                p.dateGenDB + ",'" + p.YearId + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Quotation");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Quotation p)
        {
            String sql = "", chk = "";

            p.CompAddress1 = p.CompAddress1.Replace("''", "'");
            p.Remark1 = p.Remark1.Replace("''", "'");
            p.Remark2 = p.Remark2.Replace("''", "'");
            p.Remark3 = p.Remark3.Replace("''", "'");
            p.CompAddress2 = p.CompAddress2.Replace("''", "'");
            p.CompName = p.CompName.Replace("''", "'");
            p.ContactName = p.ContactName.Replace("''", "'");
            p.CustAddress = p.CustAddress.Replace("''", "'");
            p.CustName = p.CustName.Replace("''", "'");
            p.Plus1Name = p.Plus1Name.Replace("''", "'");
            p.StaffName = p.StaffName.Replace("''", "'");
            p.StaffApproveName = p.StaffApproveName.Replace("''", "'");

            p.Line1 = p.Line1.Replace("''", "'");
            p.Line2 = p.Line2.Replace("''", "'");
            p.Line3 = p.Line3.Replace("''", "'");
            p.Line4 = p.Line4.Replace("''", "'");
            p.Line5 = p.Line5.Replace("''", "'");
            p.Line6 = p.Line6.Replace("''", "'");

            p.Remark4 = p.Remark4.Replace("''", "'");
            p.Remark5 = p.Remark5.Replace("''", "'");
            p.Remark6 = p.Remark6.Replace("''", "'");
            p.Remark7 = p.Remark7.Replace("''", "'");

            sql = "Update " + qu.table + " Set " + qu.Amount + "=" + NumberNull1(p.Amount) + ", " +
                qu.AmountDiscount + "=" + NumberNull1(p.AmountDiscount) + ", " +
                qu.CompAddress1 + "='" + p.CompAddress1 + "', " +
                qu.CompAddress2 + "='" + p.CompAddress2 + "', " +
                qu.CompId + "='" + p.CompId + "', " +
                qu.CompName + "='" + p.CompName + "', " +
                qu.CompTaxId + "='" + p.CompTaxId + "', " +
                qu.ContactName + "='" + p.ContactName + "', " +
                qu.CustAddress + "='" + p.CustAddress + "', " +
                qu.CustEmail + "='" + p.CustEmail + "', " +
                qu.CustFax + "='" + p.CustFax + "', " +
                qu.CustId + "='" + p.CustId + "', " +
                qu.CustName + "='" + p.CustName + "', " +
                qu.CustTel + "='" + p.CustTel + "', " +
                qu.DiscountPer + "=" + NumberNull1(p.DiscountPer) + ", " +
                qu.Line1 + "='" + p.Line1 + "', " +
                qu.Line2 + "='" + p.Line2 + "', " +
                qu.Line3 + "='" + p.Line3 + "', " +
                qu.Line4 + "='" + p.Line4 + "', " +
                qu.Line5 + "='" + p.Line5 + "', " +
                qu.Line6 + "='" + p.Line6 + "', " +
                qu.NetTotal + "=" + NumberNull1(p.NetTotal) + ", " +
                qu.Plus1 + "=" + NumberNull1(p.Plus1) + ", " +
                qu.Plus1Name + "='" + p.Plus1Name + "', " +
                qu.QuoDate + "='" + p.QuoDate + "', " +
                qu.QuoNumber + "='" + p.QuoNumber + "', " +
                qu.Remark1 + "='" + p.Remark1 + "', " +
                qu.Remark2 + "='" + p.Remark2 + "', " +
                qu.Remark3 + "='" + p.Remark3 + "', " +
                qu.StaffEmail + "='" + p.StaffEmail + "', " +
                qu.StaffId + "='" + p.StaffId + "', " +
                qu.StaffName + "='" + p.StaffName + "', " +
                qu.StaffTel + "='" + p.StaffTel + "', " +
                qu.StatusQuo + "='" + p.StatusQuo + "', " +
                qu.Total + "=" + NumberNull1(p.Total) + ", " +
                qu.Vat + "=" + NumberNull1(p.Vat) + ", " +
                qu.VatRate + "=" + NumberNull1(p.VatRate) + ", " +
                qu.StaffApproveId + "='" + p.StaffApproveId + "', " +
                qu.StaffApproveName + "='" + p.StaffApproveName + "', " +
                qu.Discount + "=" + NumberNull1(p.Discount) + ", " +
                qu.QuoNumberCnt + "='" + p.QuoNumberCnt + "', " +
                qu.Remark4 + "='" + p.Remark4 + "', " +
                qu.Remark5 + "='" + p.Remark5 + "', " +
                qu.Remark6 + "='" + p.Remark6 + "', " +
                qu.Remark7 + "='" + p.Remark7 + "', " +
                qu.YearId + "='" + p.YearId + "' " +            //58.01.13.01 +
                "Where " + qu.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Quotation");
            }
            finally
            {
            }
            return chk;
        }
        public String insertQuotation(Quotation p)
        {
            Quotation item = new Quotation();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
                p.StatusQuo = "1";
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
            sql = "Delete From " + qu.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboQuoConfirmNoMOU(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectQuoConfirmNoMOU();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Id].ToString();
                item.Text = dt.Rows[i][qu.QuoNumber].ToString() + "-" + dt.Rows[i][qu.QuoNumberCnt].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboQuotation(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Id].ToString();
                item.Text = dt.Rows[i][qu.QuoNumber].ToString() + "-" + dt.Rows[i][qu.QuoNumberCnt].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public String VoidQuotation(String quId)
        {
            String sql = "", chk = "";

            sql = "Update " + qu.table + " Set " + qu.Active + "='3' " +
                "Where " + qu.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
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
        public String getQuoNumber(String quoNumber)
        {
            String sql = "", doc="", cnt="",year="", month="";
            String[] doc1 = quoNumber.Split('-');
            if (!quoNumber.Equals(""))
            {
                if (doc[0].ToString().Length > 5)
                {
                    year = doc[0].ToString().Substring(1, 2);
                    month = doc[0].ToString().Substring(3, 2);
                }
            }
            else
            {
                year = getYear();
                month = System.DateTime.Now.Month.ToString("00");
            }
            sql = "Select count("+qu.QuoNumber+") as cnt From "+qu.table+" Where +"+qu.QuoNumber+"='"+doc1[0]+"'";
            DataTable dt = conn.selectData(sql);
            if ((dt.Rows.Count > 0)&&(!doc1[0].Equals("")))
            {
                cnt = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString())+1);
                doc = doc1[0];
            }
            else
            {
                //if (!System.DateTime.Now.Year.ToString().Equals(year))
                //{
                //year = getYear();
                //    year = year.Substring(2);
                //}
                sql = "Select count(" + qu.QuoNumber + ") as cnt From " + qu.table ;
                dt = conn.selectData(sql);
                doc = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                //doc = "000" + doc; 59.07.29.01  -1
                //doc = doc.Substring(doc.Length - 3);//59.07.29.01  -1
                doc = "0000" + doc;//59.07.29.01  +1
                doc = doc.Substring(doc.Length - 4);//59.07.29.01 +1
                cnt = "1";
                //doc = "00001";
            }
            return "Q" + year + month + doc + "-" + cnt;
        }
        public ComboBox getCboRemark1(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark1();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark1].ToString();
                item.Text = dt.Rows[i][qu.Remark1].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark2(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark2();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark2].ToString();
                item.Text = dt.Rows[i][qu.Remark2].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark3(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark3();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark3].ToString();
                item.Text = dt.Rows[i][qu.Remark3].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark4(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark4();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark4].ToString();
                item.Text = dt.Rows[i][qu.Remark4].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark5(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark5();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark5].ToString();
                item.Text = dt.Rows[i][qu.Remark5].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark6(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark6();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark6].ToString();
                item.Text = dt.Rows[i][qu.Remark6].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboRemark7(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctRemark7();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.Remark7].ToString();
                item.Text = dt.Rows[i][qu.Remark7].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboYear(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectYearId();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qu.YearId].ToString();
                item.Text = dt.Rows[i][qu.YearId].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            c.Text = System.DateTime.Now.Year.ToString();
            return c;
        }
        public String getYear()
        {
            String year = "";
            if (System.DateTime.Now.Year > 2550)
            {
                year = System.DateTime.Now.Year.ToString().Substring(2);
            }
            else
            {
                year = String.Concat(System.DateTime.Now.Year + 543);
            }
            year = year.Substring(2);
            return year;
        }
        public String updateQuoNumberCnt(String quId, String quoNumberCnt)
        {
            String sql = "", chk = "";

            sql = "Update " + qu.table + " Set " + qu.QuoNumberCnt + "=" + quoNumberCnt + " " +
                "Where " + qu.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updatePathPicConfirm(String quId, String path)
        {
            String sql = "", chk = "", path1="";
            path1 = path.Replace("\\", "@");
            sql = "Update " + qu.table + " Set " + qu.PathPicConfirm + "='" + path1 + "' " +
                "Where " + qu.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateStatusConfirm(String quId)
        {
            String sql = "", chk = "";

            sql = "Update " + qu.table + " Set " + qu.StatusQuo + "='2' " +
                "Where " + qu.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateQuExId(String quId, String quExId)
        {
            String sql = "", chk = "";

            sql = "Update " + qu.table + " Set " + qu.QuExId + "='" + quExId + "' " +
                "Where " + qu.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
