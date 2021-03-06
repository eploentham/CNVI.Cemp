﻿using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class MethodDB
    {
        public Method me;
        ConnectDB conn;
        public MethodDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            me = new Method();
            me.Active = "method_active";
            me.Code = "method_code";
            me.Id = "method_id";
            me.NameE = "method_name_e";
            me.NameT = "method_name_t";
            me.Remark = "remark";
            me.Sort1 = "sort1";
            me.dateCancel = "date_cancel";
            me.dateCreate = "date_create";
            me.dateModi = "date_modi";
            //me.DatePlaceRecord = "date_place_record";
            me.userCancel = "user_cancel";
            me.userCreate = "user_create";
            me.userModi = "user_modi";

            me.table = "b_method";
            me.pkField = "method_id";
        }
        private Method setData(Method item, DataTable dt)
        {
            item.Active = dt.Rows[0][me.Active].ToString();
            item.Code = dt.Rows[0][me.Code].ToString();
            item.Id = dt.Rows[0][me.Id].ToString();
            item.NameE = dt.Rows[0][me.NameE].ToString();
            item.NameT = dt.Rows[0][me.NameT].ToString();
            item.Remark = dt.Rows[0][me.Remark].ToString();
            item.Sort1 = dt.Rows[0][me.Sort1].ToString();
            item.dateCancel = dt.Rows[0][me.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][me.dateCreate].ToString();
            item.dateModi = dt.Rows[0][me.dateModi].ToString();
            //item.DatePlaceRecord = dt.Rows[0][mo.DatePlaceRecord].ToString();
            item.userCancel = dt.Rows[0][me.userCancel].ToString();
            item.userCreate = dt.Rows[0][me.userCreate].ToString();
            item.userModi = dt.Rows[0][me.userModi].ToString();

            return item;
        }
        public List<Method> getListMethod(List<Method> item)
        {
            //ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //c.Items.Clear();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Method me1 = new Method();
                me1.Active = dt.Rows[i][me.Active].ToString();
                me1.Code = dt.Rows[i][me.Code].ToString();
                me1.Id = dt.Rows[i][me.Id].ToString();
                me1.NameE = dt.Rows[i][me.NameE].ToString();
                me1.NameT = dt.Rows[i][me.NameT].ToString();
                me1.Remark = dt.Rows[i][me.Remark].ToString();
                me1.Sort1 = dt.Rows[i][me.Sort1].ToString();
                me1.dateCancel = dt.Rows[i][me.dateCancel].ToString();
                me1.dateCreate = dt.Rows[i][me.dateCreate].ToString();
                me1.dateModi = dt.Rows[i][me.dateModi].ToString();
                //item.DatePlaceRecord = dt.Rows[0][mo.DatePlaceRecord].ToString();
                me1.userCancel = dt.Rows[i][me.userCancel].ToString();
                me1.userCreate = dt.Rows[i][me.userCreate].ToString();
                me1.userModi = dt.Rows[i][me.userModi].ToString();
                item.Add(me1);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + me.table + " Where " + me.Active + "='1' Order By "+me.Sort1;
            dt = conn.selectData(sql);

            return dt;
        }
        public String selectMax()
        {
            String sql = "", cnt = "999";
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt  From " + me.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = "000" + String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                cnt = cnt.Substring(cnt.Length - 3); ;
            }
            return cnt;
        }
        public String selectSortMax()
        {
            String sql = "";
            int cnt = 0;
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt  From " + me.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = (100 + int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                //cnt = cnt.Substring(cnt.Length - 3); ;
            }
            return cnt.ToString();
        }
        public Method selectByPk(String cuId)
        {
            Method item = new Method();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + me.table + " Where " + me.pkField + "='" + cuId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Method selectByCode(String cuId)
        {
            Method item = new Method();
            String sql = "";

            sql = "Select * From " + me.table + " Where " + me.Code + "='" + cuId + "' and " + me.Active + "='1' ";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public String selectByNameT1(String cuId)
        {
            ItemGroup item = new ItemGroup();
            String sql = "";
            DataTable dt = new DataTable();

            sql = "Select " + me.Id + " From " + me.table + " Where " + me.NameT + "='" + cuId.Replace("'","''") + "'";
            dt = conn.selectData(sql);
            sql = "";
            if (dt.Rows.Count > 0)
            {
                sql = dt.Rows[0][me.Id].ToString();
            }
            return sql;
        }
        private String insert(Method p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "me" + p.getGenID();
            }
            //p.dateCreate = p.dateGenDB;
            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            if (p.Sort1.Equals(""))
            {
                p.Sort1 = "999";
            }
            p.dateCreate = p.dateGenDB;
            sql = "Insert Into " + me.table + " (" + me.pkField + "," + me.Active + "," + me.Code + "," +
                me.NameE + "," + me.NameT + "," + me.Remark + "," +
                me.Sort1 + "," + me.dateCancel + "," + me.dateCreate + "," +
                me.dateModi + "," + me.userCancel + "," + me.userCreate + "," +
                me.userModi + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.Code + "','" +
                p.NameE + "','" + p.NameT + "','" + p.Remark + "','" +
                p.Sort1 + "','" + p.dateCancel + "'," + p.dateCreate + ",'" + 
                p.dateModi + "','" + p.userCancel + "','" + p.userCreate + "','" + 
                p.userModi + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Method");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Method p)
        {
            String sql = "", chk = "";

            p.NameE = p.NameE.Replace("'", "''");
            p.NameT = p.NameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            if (p.Sort1.Equals(""))
            {
                p.Sort1 = "999";
            }
            sql = "Update " + me.table + " Set " + me.Code + "='" + p.Code + "', " +
                me.NameE + "='" + p.NameE + "', " +
                me.NameT + "='" + p.NameT + "', " +
                me.Remark + "='" + p.Remark + "', " +
                me.Sort1 + "='" + p.Sort1 + "', " +
                me.userModi + "='" + p.userModi + "', " +
                me.dateModi + "=" + p.dateGenDB + " " +
                "Where " + me.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Method");
            }
            finally
            {
            }
            return chk;
        }
        public String insertMethod(Method p)
        {
            Method item = new Method();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
                p.Active = "1";
                if (p.Sort1.Equals(""))
                {
                    p.Sort1 = selectMax();
                }
                
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
            sql = "Delete From " + me.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboMethod(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            c.Items.Clear();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][me.Id].ToString();
                item.Text = dt.Rows[i][me.NameT].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidMethod(String saleId)
        {
            String sql = "", chk = "";
            sql = "Update " + me.table + " Set " + me.Active + "='3' " +
                "Where " + me.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String getMaxCode()
        {
            String sql = "", cnt = "", year = "";
            sql = "Select count(1) as cnt From " + me.table;
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
        public String getMethodCode()
        {
            String sql = "", cnt="", year ="";
            sql = "Select count(1) as cnt From "+me.table;
            DataTable dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString()) + 1);
                cnt = "00000" + cnt;
                cnt = cnt.Substring(cnt.Length - 5);
                year = getYear();
            }
            //return "me" + year + cnt;
            return cnt;
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
    }
}
