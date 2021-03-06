﻿using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class ResultItemDB
    {
        ConnectDB conn;
        public ResultItem rsi;
        public ResultItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rsi = new ResultItem();
            rsi.Active = "result_item_active";
            rsi.Id = "result_item_id";
            rsi.PlaceMeasure = "place_measure";
            rsi.ResultId = "result_id";
            rsi.ResultMax = "result_max";
            rsi.ResultMin = "result_min";
            rsi.ResultValue = "result_value";
            rsi.RowNumber = "row_number";
            rsi.ItemCode = "item_code";

            rsi.ItemDescription = "item_description";
            rsi.ItemMethodDescription = "item_method_description";
            rsi.ItemMethodId = "item_method_id";
            rsi.Remark = "remark";

            rsi.pkField = "result_item_id";
            rsi.table = "t_result_item";
        }
        private ResultItem setData(ResultItem item, DataTable dt)
        {
            item.Active = dt.Rows[0][rsi.Active].ToString();
            item.Id = dt.Rows[0][rsi.Id].ToString();
            item.PlaceMeasure = dt.Rows[0][rsi.PlaceMeasure].ToString();
            item.ResultId = dt.Rows[0][rsi.ResultId].ToString();
            item.ResultMax = dt.Rows[0][rsi.ResultMax].ToString();
            item.ResultMin = dt.Rows[0][rsi.ResultMin].ToString();
            item.ResultValue = dt.Rows[0][rsi.ResultValue].ToString();
            item.RowNumber = dt.Rows[0][rsi.RowNumber].ToString();
            item.ItemCode = dt.Rows[0][rsi.ItemCode].ToString();

            item.ItemDescription = dt.Rows[0][rsi.ItemDescription].ToString();
            item.ItemMethodDescription = dt.Rows[0][rsi.ItemMethodDescription].ToString();
            item.ItemMethodId = dt.Rows[0][rsi.ItemMethodId].ToString();
            item.Remark = dt.Rows[0][rsi.Remark].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rsi.table + " Where " + rsi.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectRemark()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct "+rsi.Remark+" From " + rsi.table + " Where " + rsi.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }

        public ResultItem selectByPk(String saleId)
        {
            ResultItem item = new ResultItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rsi.table + " Where " + rsi.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectRsId(String rsId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rsi.table + " Where " + rsi.ResultId + "='" + rsId + "' and " + rsi.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(ResultItem p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "rsi" + p.getGenID();
            }
            p.PlaceMeasure = p.PlaceMeasure.Replace("'", "''");
            p.ResultValue = p.ResultValue.Replace("'", "''");
            p.ResultMax = p.ResultMax.Replace("'", "'");
            p.ResultMin = p.ResultMin.Replace("'", "''");

            p.ItemMethodDescription = p.ItemMethodDescription.Replace("'", "''");
            p.ItemDescription = p.ItemDescription.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");

            sql = "Insert Into " + rsi.table + " (" + rsi.pkField + "," + rsi.Active + "," + rsi.PlaceMeasure + "," +
                rsi.ResultId + "," + rsi.ResultMax + "," + rsi.ResultMin + "," +
                rsi.ResultValue + "," + rsi.RowNumber + "," + rsi.ItemCode + "," + rsi.ItemMethodDescription + "," + rsi.ItemDescription + "," + rsi.Remark + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.PlaceMeasure + "','" +
                p.ResultId + "','" + p.ResultMax + "','" + p.ResultMin + "','" +
                p.ResultValue + "'," + p.RowNumber + ",'" + p.ItemCode + ",'" + p.ItemMethodDescription + ",'" + p.ItemDescription + ",'" + p.Remark + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert ResultItem");
            }
            finally
            {
            }
            return chk;
        }
        private String update(ResultItem p)
        {
            String sql = "", chk = "";

            p.PlaceMeasure = p.PlaceMeasure.Replace("'", "''");
            p.ResultValue = p.ResultValue.Replace("'", "''");
            p.ResultMax = p.ResultMax.Replace("'", "'");
            p.ResultMin = p.ResultMin.Replace("'", "''");

            p.ItemMethodDescription = p.ItemMethodDescription.Replace("'", "''");
            p.ItemDescription = p.ItemDescription.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");

            sql = "Update " + rsi.table + " Set " + rsi.PlaceMeasure + "='" + p.PlaceMeasure + "', " +
                rsi.ResultId + "='" + p.ResultId + "', " +
                rsi.ResultMax + "='" + p.ResultMax + "', " +
                rsi.ResultMin + "='" + p.ResultMin + "', " +
                rsi.ResultValue + "='" + p.ResultValue + "', " +
                rsi.RowNumber + "=" + p.RowNumber + ", " +
                rsi.ItemCode + "='" + p.ItemCode + "', " +
                rsi.ItemMethodDescription + "='" + p.ItemMethodDescription + "', " +
                rsi.ItemDescription + "='" + p.ItemDescription + "', " +
                rsi.Remark + "='" + p.Remark + "' " +

                "Where " + rsi.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update ResultItem");
            }
            finally
            {
            }
            return chk;
        }
        public String insertResultItem(ResultItem p)
        {
            ResultItem item = new ResultItem();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
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
            sql = "Delete From " + rsi.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public List<ResultItem> getListMethod(List<ResultItem> item)
        {
            //ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectRemark();
            //c.Items.Clear();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ResultItem me1 = new ResultItem();
                me1.Active = dt.Rows[i][rsi.Active].ToString();
                me1.Id = dt.Rows[i][rsi.Id].ToString();
                me1.PlaceMeasure = dt.Rows[i][rsi.PlaceMeasure].ToString();
                me1.ResultId = dt.Rows[i][rsi.ResultId].ToString();
                me1.ResultMax = dt.Rows[i][rsi.ResultMax].ToString();
                me1.ResultMin = dt.Rows[i][rsi.ResultMin].ToString();
                me1.ResultValue = dt.Rows[i][rsi.ResultValue].ToString();
                me1.RowNumber = dt.Rows[i][rsi.RowNumber].ToString();
                me1.ItemCode = dt.Rows[i][rsi.ItemCode].ToString();

                me1.ItemDescription = dt.Rows[i][rsi.ItemDescription].ToString();
                me1.ItemMethodDescription = dt.Rows[i][rsi.ItemMethodDescription].ToString();
                me1.ItemMethodId = dt.Rows[i][rsi.ItemMethodId].ToString();
                me1.Remark = dt.Rows[i][rsi.Remark].ToString();
                item.Add(me1);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return item;
        }
        public ComboBox getCboRemark(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectRemark();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][rsi.Remark].ToString();
                item.Text = dt.Rows[i][rsi.Remark].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
    }
}
