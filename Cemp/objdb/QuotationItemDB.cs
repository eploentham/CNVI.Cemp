﻿using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class QuotationItemDB
    {
        ConnectDB conn;
        public QuotationItem qui;
        public QuotationItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            qui = new QuotationItem();
            qui.Active = "quo_item_active";
            qui.Amount = "amount";
            qui.Discount = "discount";
            qui.Id = "quo_item_id";
            qui.ItemDescription = "item_description";
            qui.ItemId = "item_id";
            qui.MethodDescription = "item_method_description";
            qui.MethodId = "item_method_id";
            qui.PriceSale = "price_sale";
            qui.Qty = "qty";
            qui.QuoId = "quo_id";
            qui.RowNumber = "row_number";
            qui.Remark = "remark";

            qui.table = "t_quotation_item";
            qui.pkField = "quo_item_id";
        }
        private QuotationItem setData(QuotationItem item, DataTable dt)
        {
            item.Active = dt.Rows[0][qui.Active].ToString();
            item.Amount = dt.Rows[0][qui.Amount].ToString();
            item.Discount = dt.Rows[0][qui.Discount].ToString();
            item.Id = dt.Rows[0][qui.Id].ToString();
            item.ItemDescription = dt.Rows[0][qui.ItemDescription].ToString();
            item.ItemId = dt.Rows[0][qui.ItemId].ToString();
            item.MethodDescription = dt.Rows[0][qui.MethodDescription].ToString();
            item.MethodId = dt.Rows[0][qui.MethodId].ToString();
            item.PriceSale = dt.Rows[0][qui.PriceSale].ToString();
            item.Qty = dt.Rows[0][qui.Qty].ToString();
            item.QuoId = dt.Rows[0][qui.QuoId].ToString();
            item.RowNumber = dt.Rows[0][qui.RowNumber].ToString();
            item.Remark = dt.Rows[0][qui.Remark].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qui.table + " Where " + qui.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public QuotationItem selectByPk(String quiId)
        {
            QuotationItem item = new QuotationItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + qui.table + " Where " + qui.pkField + "='" + quiId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public QuotationItem selectByQuoId(String quiId)
        {
            QuotationItem item = new QuotationItem();
            String sql = "";

            sql = "Select * From " + qui.table + " Where " + qui.QuoId + "='" + quiId + "' and " + qui.Active + "='1' ";
            //dt = conn.selectData(sql);
            conn.selectDataN(sql);
            if (conn.dt.Rows.Count > 0)
            {
                item = setData(item, conn.dt);
            }
            return item;
        }
        public DataTable selectDistinctItemDescription()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qui.ItemDescription + " From " + qui.table + " Where " + qui.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectDistinctMethodDescription()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + qui.MethodDescription + " From " + qui.table + " Where " + qui.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(QuotationItem p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "qui"+p.getGenID();
            }
            p.ItemDescription = p.ItemDescription.Replace("''", "'");
            p.MethodDescription = p.MethodDescription.Replace("''", "'");
            p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + qui.table + " (" + qui.pkField + "," + qui.Active + "," + qui.Amount + "," +
                qui.Discount + "," + qui.ItemDescription + "," + qui.ItemId + "," +
                qui.MethodDescription + "," + qui.MethodId + "," + qui.PriceSale + "," +
                qui.Qty + "," + qui.QuoId + "," + qui.RowNumber + "," +
                qui.Remark + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.Amount + "','" +
                p.Discount + "','" + p.ItemDescription + "','" + p.ItemId + "','" +
                p.MethodDescription + "','" + p.MethodId + "','" + p.PriceSale + "','" +
                p.Qty + "','" + p.QuoId + "','" + p.RowNumber + "','" +
                p.Remark + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Staff");
            }
            finally
            {
            }
            return chk;
        }
        private String update(QuotationItem p)
        {
            String sql = "", chk = "";

            p.ItemDescription = p.ItemDescription.Replace("''", "'");
            p.MethodDescription = p.MethodDescription.Replace("''", "'");
            p.Remark = p.Remark.Replace("''", "'");

            sql = "Update " + qui.table + " Set " + qui.Amount + "='" + p.Amount + "', " +
                qui.Discount + "='" + p.Discount + "', " +
                qui.ItemDescription + "='" + p.ItemDescription + "', " +
                qui.ItemId + "='" + p.ItemId + "', " +
                qui.MethodDescription + "='" + p.MethodDescription + "', " +
                qui.MethodId + "='" + p.MethodId + "', " +
                qui.PriceSale + "='" + p.PriceSale + "', " +
                qui.Qty + "='" + p.Qty + "', " +
                qui.QuoId + "='" + p.QuoId + "', " +
                qui.RowNumber + "='" + p.RowNumber + "', " +
                qui.Remark + "='" + p.Remark + "' " +
                
                "Where " + qui.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Staff");
            }
            finally
            {
            }
            return chk;
        }
        public String insertQuotationItem(QuotationItem p)
        {
            QuotationItem item = new QuotationItem();
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
            sql = "Delete From " + qui.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidQuotationItem(String quId)
        {
            String sql = "", chk = "";

            sql = "Update " + qui.table + " Set " + qui.Active + "='3' " +
                "Where " + qui.pkField + "='" + quId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboItemDescription(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctItemDescription();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qui.ItemDescription].ToString();
                item.Text = dt.Rows[i][qui.ItemDescription].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboMethodDescription(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctMethodDescription();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][qui.MethodDescription].ToString();
                item.Text = dt.Rows[i][qui.MethodDescription].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
    }
}