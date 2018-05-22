using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class ItemDB
    {
        ConnectDB conn;
        public Item it;
        public ItemDB(ConnectDB c)
        {
            conn = c;                       
            initConfig();
        }
        private void initConfig()
        {
            it = new Item();
            it.Active = "item_active";
            it.Code = "item_code";
            it.Id = "item_id";
            it.NameE = "item_name_e";
            it.NameT = "item_name_t";
            it.PriceCost = "price_cost";
            it.PriceSale = "price_sale";
            it.Remark = "item_remark";
            it.ItemGroupId = "item_group_id";
            it.ItemGroupNameT = "item_group_name_t";
            it.MeasuringPoint = "measuring_point";
            it.MethodId = "method_id";
            it.MethodNameT = "method_name_t";
            it.Sort1 = "sort1";
            it.dateCancel = "date_cancel";
            it.dateCreate = "date_create";
            it.dateModi = "date_modi";
            it.userCancel = "user_cancel";
            it.userCreate = "user_create";
            it.userModi = "user_modi";
            it.PriceCostReal = "price_cost_real";
            it.ItemType = "item_type";
            it.CustId = "cust_id";
            it.CustNameT = "cust_name_t";
            it.AnalysisId = "analysis_id";
            it.AnalysisNameT = "analysis_name_t";
            it.StatusReal = "status_real";//0=default 1= itemที่ใช้งานจริง 3=เป็นพวกของแถม ค่าจัดทำเอกสาร
            it.StatusStock = "status_stock";//0=default 1= stock 3=no stock
            it.StatusPrice = "status_price";//0=default, 1=normal,2=price period
            if (conn.initc.connectDatabaseServer.Equals("yes"))
            {
                it.dateGenDB = "Now()";
            }
            it.ValueMax = "value_max";
            it.ValueMin = "value_min";
            it.table = "b_item";
            it.pkField = "item_id";
        }
        private Item setData(Item item, DataTable dt)
        {
            item.Active = dt.Rows[0][it.Active].ToString();
            item.Code = dt.Rows[0][it.Code].ToString();
            item.Id = dt.Rows[0][it.Id].ToString();
            item.NameE = dt.Rows[0][it.NameE].ToString();
            item.NameT = dt.Rows[0][it.NameT].ToString();
            item.PriceCost = dt.Rows[0][it.PriceCost].ToString();
            item.PriceSale = dt.Rows[0][it.PriceSale].ToString();
            item.Remark = dt.Rows[0][it.Remark].ToString();
            item.ItemGroupId = dt.Rows[0][it.ItemGroupId].ToString();
            item.ItemGroupNameT = dt.Rows[0][it.ItemGroupNameT].ToString();
            item.MethodNameT = dt.Rows[0][it.MethodNameT].ToString();
            item.MethodId = dt.Rows[0][it.MethodId].ToString();
            item.MeasuringPoint = dt.Rows[0][it.MeasuringPoint].ToString();
            item.Sort1 = dt.Rows[0][it.Sort1].ToString();
            item.dateCancel = dt.Rows[0][it.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][it.dateCreate].ToString();
            item.dateModi = dt.Rows[0][it.dateModi].ToString();
            item.userCancel = dt.Rows[0][it.userCancel].ToString();
            item.userCreate = dt.Rows[0][it.userCreate].ToString();
            item.userModi = dt.Rows[0][it.userModi].ToString();
            item.PriceCostReal = dt.Rows[0][it.PriceCostReal].ToString();
            item.ItemType = dt.Rows[0][it.ItemType].ToString();

            item.CustId = dt.Rows[0][it.CustId].ToString();
            item.CustNameT = dt.Rows[0][it.CustNameT].ToString();

            item.AnalysisId = dt.Rows[0][it.AnalysisId].ToString();
            item.AnalysisNameT = dt.Rows[0][it.AnalysisNameT].ToString();

            item.StatusReal = dt.Rows[0][it.StatusReal].ToString();
            item.StatusStock = dt.Rows[0][it.StatusStock].ToString();

            item.StatusPrice = dt.Rows[0][it.StatusPrice].ToString();

            item.ValueMax = dt.Rows[0][it.ValueMax].ToString();
            item.ValueMin = dt.Rows[0][it.ValueMin].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + it.table + " Where " + it.Active + "='1' Order By "+it.Code;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByItGroupMethodType(String itgId, String meId, String ityId, String itName)
        {
            String sql = "", whereitg = "", wheremeid = "", whereityid = "", whereitName = "";
            DataTable dt = new DataTable();
            if (!itgId.Equals(""))
            {
                whereitg = " and "+it.ItemGroupNameT+" like '"+itgId+"%'";
            }
            if (!meId.Equals(""))
            {
                wheremeid = " and " + it.MethodNameT + " like '" + meId + "%'";
            }
            if (!ityId.Equals(""))
            {
                whereityid = " and " + it.ItemType + " like '" + ityId + "%'";
            }
            if (!itName.Equals(""))
            {
                whereitName = " and (" + it.NameT + " like '" + itName + "%' or "+it.Code+" like '"+itName+"%')";
            }
            sql = "Select * From " + it.table + " Where " + it.Active + "='1'" + whereitg + wheremeid + whereityid + whereitName;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByItGroupMethod(String nameT,String itgId, String meId)
        {
            String sql = "", whereitg = "", wheremeid = "", whereitnamet = "";
            DataTable dt = new DataTable();
            if (!nameT.Equals(""))
            {
                whereitnamet = " (" + it.NameT + " like '" + nameT + "%' or "+it.Code+" like '"+nameT+"%') ";
            }
            if (!itgId.Equals(""))
            {
                whereitg = " and " + it.ItemGroupNameT + " like '" + itgId + "%'";
            }
            if (!meId.Equals(""))
            {
                wheremeid = " and " + it.MethodNameT + " like '" + meId + "%'";
            }
            if (nameT.Equals(""))
            {
                whereitg = whereitg.Replace("and", "");
            }
            if (nameT.Equals("") && itgId.Equals(""))
            {
                wheremeid = wheremeid.Replace("and", "");
            }
            sql = "Select " + it.Id + "," + it.Code + "," + it.NameT + "," + it.NameE + "," + it.ItemGroupNameT + "," + it.MethodNameT + "," + it.Active + "," + it.Remark + "," + it.PriceSale + 
                " From " + it.table + 
                " Where " + whereitnamet + whereitg + wheremeid+ " and item_active = '1' " +
                "Order By "+it.Code;
            dt = conn.selectData(sql);

            return dt;
        }
        public Item selectByPk(String cuId)
        {
            Item item = new Item();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + it.table + " Where " + it.pkField + "='" + cuId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Item selectByCode(String cuId)
        {
            Item item = new Item();
            String sql = "";

            sql = "Select * From " + it.table + " Where " + it.Code + "='" + cuId + "' and " + it.Active + "='1' ";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public String selectSortMax()
        {
            String sql = "";
            int cnt = 0;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt  From " + it.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = (100 + int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                //cnt = cnt.Substring(cnt.Length - 3); ;
            }
            return cnt.ToString();
        }
        private String insert(Item p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "it" + p.getGenID();
            }

            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            p.ItemGroupNameT = p.ItemGroupNameT.Replace("'", "''");
            p.MethodNameT = p.MethodNameT.Replace("'", "''");
            p.CustNameT = p.CustNameT.Replace("'", "''");
            p.AnalysisNameT = p.AnalysisNameT.Replace("'", "''");
            if (p.Sort1.Equals(""))
            {
                p.Sort1 = "9999";
            }
            if (p.StatusReal.Equals(""))
            {
                p.StatusReal = "1";
            }
            if (p.StatusStock.Equals(""))
            {
                p.StatusStock = "1";
            }
            if (p.StatusPrice.Equals(""))
            {
                p.StatusPrice = "1";
            }
            sql = "Insert Into " + it.table + " (" + it.pkField + "," + it.Active + "," + it.Code + "," +
                it.NameE + "," + it.NameT + "," + it.Remark + "," +
                it.PriceCost + "," + it.PriceSale + "," + it.ItemGroupId + "," +
                it.ItemGroupNameT + "," + it.MethodNameT + "," + it.MethodId + "," +
                it.Sort1 + "," + it.dateCancel + "," + it.dateCreate + "," +
                it.dateModi + "," + it.userCancel + "," + it.userCreate + "," +
                it.userModi + "," + it.PriceCostReal + "," + it.ItemType + "," + 
                it.CustNameT + "," + it.CustId + "," + it.AnalysisId + "," +
                it.AnalysisNameT + "," + it.StatusReal + "," + it.StatusStock + "," + 
                it.StatusPrice + "," + it.ValueMin + "," + it.ValueMax + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.Code + "','" +
                p.NameE + "','" + p.NameT + "','" + p.Remark + "'," +
                NumberNull1(p.PriceCost) + "," + NumberNull1(p.PriceSale) + ",'" + p.ItemGroupId + "','" +
                p.ItemGroupNameT + "','" + p.MethodNameT + "','" + p.MethodId + "','" +
                p.Sort1 + "','" +p.dateCancel + "'," + p.dateGenDB + ",'" + 
                p.dateModi + "','" +p.userCancel + "','" + p.userCreate + "','" +
                p.userModi + "'," + NumberNull1(p.PriceCostReal) + ",'" + p.ItemType + "','" + 
                p.CustNameT + "','" + p.CustId + "','" + p.AnalysisId + "','" +
                p.AnalysisNameT + "','" + p.StatusReal + "','" + p.StatusStock + "','" + 
                p.StatusPrice + "','" + p.ValueMin + "','" + p.ValueMax + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Item");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Item p)
        {
            String sql = "", chk = "";

            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            p.ItemGroupNameT = p.ItemGroupNameT.Replace("'", "''");
            p.MethodNameT = p.MethodNameT.Replace("'", "''");
            p.CustNameT = p.CustNameT.Replace("'", "''");
            p.AnalysisNameT = p.AnalysisNameT.Replace("'", "''");
            if (p.Sort1.Equals(""))
            {
                p.Sort1 = "9999";
            }
            if (p.StatusPrice.Equals(""))
            {
                p.StatusPrice = "1";
            }
            sql = "Update " + it.table + " Set " + it.Code + "='" + p.Code + "', " +
                it.NameE + "='" + p.NameE + "', " +
                it.NameT + "='" + p.NameT + "', " +
                it.Remark + "='" + p.Remark + "', " +
                it.ItemGroupId + "='" + p.ItemGroupId + "', " +
                it.ItemGroupNameT + "='" + p.ItemGroupNameT + "', " +
                it.MethodNameT + "='" + p.MethodNameT + "', " +
                it.MethodId + "='" + p.MethodId + "', " +
                it.PriceCost + "=" + NumberNull1(p.PriceCost) + ", " +
                it.PriceSale + "=" + NumberNull1(p.PriceSale) + ", " +
                it.Sort1 + "='" + p.Sort1 + "', " +
                it.userModi + "='" + p.userModi + "'," +
                it.dateModi + "=" + it.dateGenDB + ", " +
                it.PriceCostReal + "=" + NumberNull1(p.PriceCostReal) + ", " +
                it.ItemType + "='" + p.ItemType + "', " +
                it.CustNameT + "='" + p.CustNameT + "', " +
                it.CustId + "='" + p.CustId + "', " +
                it.AnalysisId + "='" + p.AnalysisId + "', " +
                it.AnalysisNameT + "='" + p.AnalysisNameT + "', " +
                it.StatusReal + "='" + p.StatusReal + "', " +
                it.StatusStock + "='" + p.StatusStock + "', " +
                it.StatusPrice + "='" + p.StatusPrice + "', " +
                it.ValueMax + "='" + p.ValueMax + "', " +
                it.ValueMin + "='" + p.ValueMin + "' " +
                "Where " + it.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Item");
            }
            finally
            {
            }
            return chk;
        }
        public String insertItem(Item p)
        {
            Item item = new Item();
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
            sql = "Delete From " + it.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboItem(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][it.Id].ToString();
                item.Text = dt.Rows[i][it.NameT].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public ComboBox getCboItemQuotation(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][it.Id].ToString();
                item.Text = dt.Rows[i][it.Code].ToString() + " " + dt.Rows[i][it.NameT].ToString() + " [" + dt.Rows[i][it.MethodNameT].ToString()+"]";
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidItem(String saleId)
        {
            String sql = "", chk = "";
            sql = "Update " + it.table + " Set " + it.Active + "='3' " +
                "Where " + it.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String getMaxCode()
        {
            String sql = "", cnt = "", year = "";
            sql = "Select count(1) as cnt From " + it.table;
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                cnt = "000" + cnt;
                cnt = cnt.Substring(cnt.Length - 3);
                //year = getYear();
            }
            //return "me" + year + cnt;
            return cnt;
        }
        public String getItemCode()
        {
            String sql = "", cnt = "", year = "";
            sql = "Select count(1) as cnt From " + it.table;
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                cnt = "00000" + cnt;
                cnt = cnt.Substring(cnt.Length - 5);
                //year = getYear();
            }
            //return "me" + year + cnt;
            return cnt;
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
        public String UpdateGroupNameT(String id, String itgId, String itgNameT)
        {
            String sql = "", chk = "";
            sql = "Update " + it.table + " Set " + it.ItemGroupNameT + "='" + itgNameT + "' " +
                //it.ItemGroupNameT + "='" + itgNameT + "' " +
                "Where " + it.pkField + "='" + id + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public List<Item> getListItem(List<Item> item)
        {
            //ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //c.Items.Clear();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item it1 = new Item();
                it1.Active = dt.Rows[i][it.Active].ToString();
                it1.Code = dt.Rows[i][it.Code].ToString();
                it1.Id = dt.Rows[i][it.Id].ToString();
                it1.NameE = dt.Rows[i][it.NameE].ToString();
                it1.NameT = dt.Rows[i][it.NameT].ToString();
                it1.PriceCost = dt.Rows[i][it.PriceCost].ToString();
                it1.PriceSale = dt.Rows[i][it.PriceSale].ToString();
                it1.Remark = dt.Rows[i][it.Remark].ToString();
                it1.ItemGroupId = dt.Rows[i][it.ItemGroupId].ToString();
                it1.ItemGroupNameT = dt.Rows[i][it.ItemGroupNameT].ToString();
                it1.MethodNameT = dt.Rows[i][it.MethodNameT].ToString();
                it1.MethodId = dt.Rows[i][it.MethodId].ToString();
                it1.MeasuringPoint = dt.Rows[i][it.MeasuringPoint].ToString();
                it1.Sort1 = dt.Rows[i][it.Sort1].ToString();
                it1.dateCancel = dt.Rows[i][it.dateCancel].ToString();
                it1.dateCreate = dt.Rows[i][it.dateCreate].ToString();
                it1.dateModi = dt.Rows[i][it.dateModi].ToString();
                it1.userCancel = dt.Rows[i][it.userCancel].ToString();
                it1.userCreate = dt.Rows[i][it.userCreate].ToString();
                it1.userModi = dt.Rows[i][it.userModi].ToString();
                it1.PriceCostReal = dt.Rows[i][it.PriceCostReal].ToString();
                it1.ItemType = dt.Rows[i][it.ItemType].ToString();

                it1.CustId = dt.Rows[i][it.CustId].ToString();
                it1.CustNameT = dt.Rows[i][it.CustNameT].ToString();

                it1.AnalysisId = dt.Rows[i][it.AnalysisId].ToString();
                it1.AnalysisNameT = dt.Rows[i][it.AnalysisNameT].ToString();

                it1.StatusReal = dt.Rows[i][it.StatusReal].ToString();
                it1.StatusStock = dt.Rows[i][it.StatusStock].ToString();

                it1.StatusPrice = dt.Rows[i][it.StatusPrice].ToString();

                it1.ValueMax = dt.Rows[i][it.ValueMax].ToString();
                it1.ValueMin = dt.Rows[i][it.ValueMin].ToString();
                item.Add(it1);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return item;
        }
        public ComboBox getCboItemByList(ComboBox c, List<Item> lit)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            c.Items.Clear();
            //String aaa = "";
            foreach (Item i in lit)
            {
                item = new ComboBoxItem();
                item.Value = i.Id;
                item.Text = i.NameT;
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public Item getItemByList(String itId, List<Item> lit)
        {
            Item it1 = new Item();
            foreach (Item i in lit)
            {
                if (i.Id.Equals(itId))
                {
                    it1 = i;
                    return i;
                }
            }
            return it1;
        }
    }
}
