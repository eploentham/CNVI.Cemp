﻿using Cemp.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.objdb
{
    public class MOUItemDB
    {
        ConnectDB conn;
        public MOUItem moi;
        public MOUItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            moi = new MOUItem();
            moi.Active = "";
            moi.Id = "";
            moi.ItemDescription = "";
            moi.ItemId = "";
            moi.MethodDescription = "";
            moi.MethodId = "";
            moi.MOUId = "";
            moi.PlaceRecord = "";
            moi.RowNumber = "";
            moi.Sample = "";

            moi.pkField = "";
            moi.table = "";
        }
        private MOUItem setData(MOUItem item, DataTable dt)
        {
            item.Active = dt.Rows[0][moi.Active].ToString();
            item.Id = dt.Rows[0][moi.Id].ToString();
            item.ItemDescription = dt.Rows[0][moi.ItemDescription].ToString();
            item.ItemId = dt.Rows[0][moi.ItemId].ToString();
            item.MethodDescription = dt.Rows[0][moi.MethodDescription].ToString();
            item.MethodId = dt.Rows[0][moi.MethodId].ToString();
            item.MOUId = dt.Rows[0][moi.MOUId].ToString();
            item.PlaceRecord = dt.Rows[0][moi.PlaceRecord].ToString();
            item.RowNumber = dt.Rows[0][moi.RowNumber].ToString();
            item.Sample = dt.Rows[0][moi.Sample].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + moi.table + " Where " + moi.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }

        public MOUItem selectByPk(String saleId)
        {
            MOUItem item = new MOUItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + moi.table + " Where " + moi.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectByMoId(String moId)
        {
            //MOUItem item = new MOUItem();
            String sql = "";

            sql = "Select * From " + moi.table + " Where " + moi.MOUId + "='" + moId + "'";
            //dt = conn.selectData(sql);
            DataTable dt = conn.selectData(sql);

            return dt;
        }
        private String insert(MOUItem p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = "mo" + p.getGenID();
            }

            p.MethodDescription = p.MethodDescription.Replace("''", "'");
            p.ItemDescription = p.ItemDescription.Replace("''", "'");
            p.PlaceRecord = p.PlaceRecord.Replace("''", "'");

            sql = "Insert Into " + moi.table + " (" + moi.pkField + "," + moi.Active + "," + moi.ItemDescription + "," +
                moi.ItemId + "," + moi.MethodDescription + "," + moi.MethodId + "," +
                moi.MOUId + "," + moi.PlaceRecord + "," + moi.RowNumber + "," +
                moi.Sample + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.ItemDescription + "','" +
                p.ItemId + "','" + p.MethodDescription + "','" + p.MethodId + "','" +
                p.MOUId + "','" + p.PlaceRecord + "','" + p.RowNumber + "','" +
                p.Sample + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert MOUItem");
            }
            finally
            {
            }
            return chk;
        }
        private String update(MOUItem p)
        {
            String sql = "", chk = "";

            p.MethodDescription = p.MethodDescription.Replace("''", "'");
            p.ItemDescription = p.ItemDescription.Replace("''", "'");
            p.PlaceRecord = p.PlaceRecord.Replace("''", "'");

            sql = "Update " + moi.table + " Set " + moi.ItemDescription + "='" + p.ItemDescription + "', " +
                moi.ItemId + "='" + p.ItemId + "', " +
                moi.MethodDescription + "='" + p.MethodDescription + "', " +
                moi.MethodId + "='" + p.MethodId + "', " +
                moi.MOUId + "='" + p.MOUId + "', " +
                moi.PlaceRecord + "='" + p.PlaceRecord + "', " +
                moi.RowNumber + "=" + p.RowNumber + ", " +
                moi.Sample + "='" + p.Sample + "' " +

                "Where " + moi.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update MOU");
            }
            finally
            {
            }
            return chk;
        }
        public String insertMOU(MOUItem p)
        {
            MOUItem item = new MOUItem();
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
            sql = "Delete From " + moi.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidMOU(String mod)
        {
            String sql = "", chk = "";

            sql = "Update " + moi.table + " Set " + moi.Active + "='3' " +
                "Where " + moi.pkField + "='" + mod + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}