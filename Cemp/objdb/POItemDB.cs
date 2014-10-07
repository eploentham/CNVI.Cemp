﻿using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class POItemDB
    {
        public POItem poi;
        ConnectDB conn;
        public POItemDB(ConnectDB c)
        {
            conn = c;
        }
        private void initConfig()
        {
            poi = new POItem();
            poi.Active = "po_item_active";
            poi.DateCancel = "date_cancel";
            poi.DateCreate = "date_create";
            poi.DateModi = "date_modi";
            poi.ItemAmount = "item_amount";
            poi.ItemId = "item_id";
            poi.ItemNameT = "item_name_t";
            poi.ItemPrice = "item_price";
            poi.ItemQty = "item_qty";
            poi.POId = "po_id";
            poi.Id = "po_item_id";
            poi.Remark = "remark";
            poi.UserCancel = "user_cancel";
            poi.UserCreate = "user_create";
            poi.UserModi = "user_modi";
            poi.ItemType = "item_type";

            poi.pkField = "po_item_id";
            poi.table = "";
        }
        private POItem setData(POItem item, DataTable dt)
        {
            item.Active = dt.Rows[0][poi.Active].ToString();
            item.DateCancel = dt.Rows[0][poi.DateCancel].ToString();
            item.DateCreate = dt.Rows[0][poi.DateCreate].ToString();
            item.DateModi = dt.Rows[0][poi.DateModi].ToString();
            item.ItemAmount = dt.Rows[0][poi.ItemAmount].ToString();
            item.ItemId = dt.Rows[0][poi.ItemId].ToString();
            item.ItemNameT = dt.Rows[0][poi.ItemNameT].ToString();
            item.ItemPrice = dt.Rows[0][poi.ItemPrice].ToString();
            item.ItemQty = dt.Rows[0][poi.ItemQty].ToString();
            item.POId = dt.Rows[0][poi.POId].ToString();
            item.Id = dt.Rows[0][poi.Id].ToString();
            item.Remark = dt.Rows[0][poi.Remark].ToString();
            item.UserCancel = dt.Rows[0][poi.UserCancel].ToString();
            item.UserCreate = dt.Rows[0][poi.UserCreate].ToString();
            item.UserModi = dt.Rows[0][poi.UserModi].ToString();
            item.ItemType = dt.Rows[0][poi.ItemType].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + poi.table + " Where " + poi.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByName(String name)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + poi.table + " Where " + poi.Active + "='1' and "+poi.ItemNameT+"='"+name+"%'";
            dt = conn.selectData(sql);

            return dt;
        }
        public POItem selectByPk(String saleId)
        {
            POItem item = new POItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + poi.table + " Where " + poi.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(POItem p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "poi" + p.getGenID();
            }
            p.ItemNameT = p.ItemNameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");
            //p.CuNametT = p.CuNametT.Replace("'", "'");
            //p.SfName = p.SfName.Replace("'", "''");
            //p.MethodMeasure = p.MethodMeasure.Replace("'", "''");
            //p.Summary = p.Summary.Replace("'", "''");

            sql = "Insert Into " + poi.table + " (" + poi.pkField + "," + poi.Active + "," + poi.DateCancel + "," +
                poi.DateCreate + "," + poi.DateModi + "," + poi.ItemAmount + "," +
                poi.ItemId + "," + poi.ItemNameT + "," + poi.ItemPrice + "," +
                poi.ItemQty + "," + poi.POId + "," + poi.Remark + "," +
                poi.UserCancel + "," + poi.UserCreate + "," + poi.UserModi + "," + poi.ItemType + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.DateCancel + "'," +
                p.dateGenDB + ",'" + p.DateModi + "'," + p.ItemAmount + ",'" +
                p.ItemId + "','" + p.ItemNameT + "'," + p.ItemPrice + "," +
                p.ItemQty + ",'" + p.POId + "'," + p.Remark + ",'" +
                p.UserCancel + "','" + p.UserCreate + "','" + p.UserModi + "','" + p.ItemType + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert POItem");
            }
            finally
            {
            }
            return chk;
        }
        private String update(POItem p)
        {
            String sql = "", chk = "";

            p.ItemNameT = p.ItemNameT.Replace("'", "''");
            p.Remark = p.Remark.Replace("'", "''");

            sql = "Update " + poi.table + " Set " + poi.DateModi + "=" + p.dateGenDB + ", " +
                poi.ItemAmount + "=" + p.ItemAmount + ", " +
                poi.ItemId + "='" + p.ItemId + "', " +
                poi.ItemNameT + "='" + p.ItemNameT + "', " +
                poi.ItemPrice + "=" + p.ItemPrice + ", " +
                poi.ItemQty + "=" + p.ItemQty + ", " +
                poi.POId + "='" + p.POId + "', " +
                poi.Remark + "='" + p.Remark + "', " +
                poi.UserModi + "='" + p.UserModi + "', " +
                poi.ItemType + "='" + p.ItemType + "' " +
                "Where " + poi.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update POItem");
            }
            finally
            {
            }
            return chk;
        }
        public String insertPOItem(POItem p)
        {
            POItem item = new POItem();
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
            sql = "Delete From " + poi.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}