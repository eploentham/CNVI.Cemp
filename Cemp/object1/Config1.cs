using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cemp.object1
{
    public class Config1
    {
        public String dateGenDB = "Format(Now(),'yyyy')+'-'+Format(Now(),'mm')+'-'+Format(Now(),'dd')+' '+Format(Now(),'hh:nn:ss')";
        public ComboBox setCboYear(ComboBox c)
        {
            c.Items.Clear();
            c.Items.Add(System.DateTime.Now.Year+543);
            c.Items.Add(System.DateTime.Now.Year+543 - 1);
            c.Items.Add(System.DateTime.Now.Year+543 - 2);
            c.SelectedIndex = c.FindStringExact( String.Concat(System.DateTime.Now.Year+543));
            return c;
        }
        public ComboBox setCboYear1(ComboBox c)
        {
            c.Items.Clear();
            c.Items.Add(System.DateTime.Now.Year );
            c.Items.Add(System.DateTime.Now.Year - 1);
            c.Items.Add(System.DateTime.Now.Year - 2);
            c.SelectedIndex = c.FindStringExact(String.Concat(System.DateTime.Now.Year ));
            return c;
        }
        public ComboBox setCboMonth(ComboBox c)
        {
            c.Items.Clear();
            var items = new[]{
                new{Text = "มกราคม", Value="01"},
                new{Text = "กุมภาพันธ์", Value="02"},
                new{Text = "มีนาคม", Value="03"},
                new{Text = "เมษายน", Value="04"},
                new{Text = "พฤษภาคม", Value="05"},
                new{Text = "มิถุนายน", Value="06"},
                new{Text = "กรกฎาคม", Value="07"},
                new{Text = "สิงหาคม", Value="08"},
                new{Text = "กันยายน", Value="09"},
                new{Text = "ตุลาคม", Value="10"},
                new{Text = "พฤศจิกายน", Value="11"},
                new{Text = "ธันวาคม", Value="12"}
            };
            c.DataSource = items;
            c.DisplayMember = "Text";

            c.ValueMember = "Value";
            //c.SelectedIndex = c.FindStringExact(getMonth(System.DateTime.Now.Month.ToString("00")));
            return c;
        }
        public ComboBox setCboPeriod(ComboBox c)
        {
            var items = new[]{
                new{Text = "งวด วันที่1", Value="01"},
                new{Text = "งวด วันที่16", Value="02"}
            };
            c.Items.Clear();
            c.DataSource = items;
            c.DisplayMember = "Text";

            c.ValueMember = "Value";
            return c;
        }
        public ComboBox setCboBranch(ComboBox c)
        {
            var items = new[]{
                new{Text = "bangna1", Value="001"},
                new{Text = "bangna2", Value="002"},
                new{Text = "bangna5", Value="005"}
            };
            c.Items.Clear();
            c.DataSource = items;
            c.DisplayMember = "Text";

            c.ValueMember = "Value";
            return c;
        }
        //public ComboBox setCboLab(ComboBox c)
        //{
        //    var items = new[] { 
        //        new { Text = "", Value = "" }, 
        //        new { Text = "SUGAR (FBS)", Value = "ch002" }, 
        //        new { Text = "Sugar <BS> : NaF tube 2.5 ml", Value = "ch250" }, 
        //        new { Text = "BUN", Value = "ch003" },
        //        new { Text = "CREATININE", Value = "ch004" },
        //        new { Text = "Free T3(FT3) (Outlab/Medica lab)", Value = "ch040" },
        //        new { Text = "Free T4(FT4) (Out lab/Medica LAB)", Value = "ch037" },
        //        new { Text = "TSH (Out lab/ MEDICA LAB)", Value = "ch039" },
        //        new { Text = "T4 (Outlab/Medica)", Value = "ch036" },
        //        new { Text = "T3 (Outlab/Medica)", Value = "ch038" },
        //        new { Text = "ANTI HIV  (Screening  Method)", Value = "se005" },
        //        new { Text = "HBsAg", Value = "se038" },
        //        new { Text = "ANTI HCV", Value = "se047" },
        //        new { Text = "CHOLESTEROL", Value = "ch006" },
        //        new { Text = "TRIGLYCERIDE", Value = "ch007" },
        //        new { Text = "HDL-C", Value = "ch008" },
        //        new { Text = "LDL-C", Value = "ch009" },
        //        new { Text = "CD4 (Out lab / MEDICA LAB)", Value = "se165" }
        //    };
        //    c.Items.Clear();
        //    c.DataSource = items;
        //    c.DisplayMember = "Text";
        //    c.ValueMember = "Value";
        //    return c;
        //}
        public String getMonth(String monthId)
        {
            if (monthId == "01")
            {
                return "มกราคม";
            }
            else if (monthId == "02")
            {
                return "กุมภาพันธ์";
            }
            else if (monthId == "03")
            {
                return "มีนาคม";
            }
            else if (monthId == "04")
            {
                return "เมษายน";
            }
            else if (monthId == "05")
            {
                return "พฤษาคม";
            }
            else if (monthId == "06")
            {
                return "มิถุนายน";
            }
            else if (monthId == "07")
            {
                return "กรกฎาคม";
            }
            else if (monthId == "08")
            {
                return "สิงหาคม";
            }
            else if (monthId == "09")
            {
                return "กันยายน";
            }
            else if (monthId == "10")
            {
                return "ตุลาคม";
            }
            else if (monthId == "11")
            {
                return "พฤศจิกายน";
            }
            else if (monthId == "12")
            {
                return "ธันวาคม";
            }
            else
            {
                return "";
            }
        }
        public String stringNull(String txt)
        {
            if (txt == null)
            {
                return "";
            }
            else
            {
                return txt;
            }
        }
        public String stringNull1(Object txt)
        {
            if (txt == null)
            {
                return "";
            }
            else
            {
                return txt.ToString();
            }
        }
        public String dateTimetoDB()
        {
            return datetoDB(System.DateTime.Now) + " "+System.DateTime.Now.ToShortTimeString();
        }
        public String datetoDB()
        {
            return datetoDB(System.DateTime.Now);
        }
        public String datetoDB(object dt)
        {
            DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return "";
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    dt1 = DateTime.Parse(dt.ToString());
                    if (dt1.Year <= 2500)
                    {
                        return String.Concat((dt1.Year+543), "-") + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }
                    else
                    {
                        return dt1.Year.ToString() + "-" + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String datetoDB(DateTime dt)
        {
            return dt.Year.ToString() + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00");
        }
        public String datetoDBChk25(DateTime dt)
        {
            if (dt.Year <= 2500)
            {
                return String.Concat((dt.Year + 543), "-") + dt.Month.ToString("00") + "-" + dt.Day.ToString("00");
            }
            else
            {
                return dt.Year.ToString() + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00");
            }
        }
        public String datetoDBChk25(String dt)
        {
            if (int.Parse(dt.Substring(6)) >= 2500)
            {
                return String.Concat((int.Parse(dt.Substring(6)) - 543), "-") + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
            }
            else
            {
                return dt.Substring(6) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
            }
        }
        public String datetoDB1(String dt)
        {
            //DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return dt;
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    //return String.Concat(int.Parse(dt.Substring(6))+543) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                    return dt.Substring(6) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String datetoDB3(String dt)
        {
            //DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return dt;
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    //return String.Concat(int.Parse(dt.Substring(6))+543) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                    if (dt.Length >= 8)
                    {
                        if (dt.Substring(6).Length == 2)
                        {
                            if (int.Parse(dt.Substring(6)) > 50)
                            {
                                return (int.Parse("25"+dt.Substring(6)) - 543) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                            }
                            else
                            {
                                return int.Parse("20"+dt.Substring(6)) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                            }
                            
                        }
                        else //if (dt.Substring(6).Length == 4)
                        {
                            return dt.Substring(6) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                        }
                    }
                    else
                    {
                        return dt.Substring(6) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String datetoDB2(String dt)
        {
            //DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return dt;
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    return String.Concat(int.Parse(dt.Substring(6)) + 543) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                    //return dt.Substring(6) + "-" + dt.Substring(3, 2) + "-" + dt.Substring(0, 2);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String dateDBtoShow(String dt)
        {
            if (dt != "")
            {
                return dt.Substring(8,2)+"-"+dt.Substring(5,2) + "-" + String.Concat(Int16.Parse(dt.Substring(0, 4))+543);
            }
            else
            {
                return dt;
            }
        }
        public String dateDBtoShow1(String dt)
        {
            if (dt != "")
            {
                return dt.Substring(8, 2) + "-" + dt.Substring(5, 2) + "-" + dt.Substring(0, 4);
            }
            else
            {
                return dt;
            }
        }
        public String dateDBtoShow25(String dt)
        {
            if (dt != "")
            {
                return dt.Substring(8, 2) + "-" + dt.Substring(5, 2) + "-" + dt.Substring(0, 4);
            }
            else
            {
                return dt;
            }
        }
        public String dateInputMOU(String dt)
        {
            if (dt != "")
            {
                String tmp = "";
                tmp = dt.Replace("/","-");
                String[] tmp1 = tmp.Split('-');
                if (tmp1.Length == 3)
                {
                    tmp = tmp1[2] + tmp1[1] + tmp1[0];
                }
                return tmp;
            }
            else
            {
                return dt;
            }
        }
        public String dateShowMOU(String dt)
        {
            if (dt != "")
            {
                String tmp = "";
                tmp = dt.Replace("/", "-");
                String[] tmp1 = tmp.Split('-');
                if (tmp1.Length == 3)
                {
                    tmp = tmp1[2]+"-" + tmp1[1]+"-" + tmp1[0];
                }
                return tmp;
            }
            else
            {
                return dt;
            }
        }
        public String ObjectNull(object o)
        {
            if (o == null)
            {
                return "";
            }
            else
            {
                return o.ToString();
            }
        }
        public String getValueCboItem(ComboBox c)
        {
            ComboBoxItem iSale;
            iSale = (ComboBoxItem)c.SelectedItem;
            if (iSale == null)
            {
                return "";
            }
            else
            {
                return iSale.Value;
            }
        }

        public String LottoNull(object o)
        {
            String chk = "";
            if (o == null)
            {
                chk = "0";
            }
            else if (o.ToString().Equals(""))
            {
                chk = "0";
            }
            else
            {
                chk = o.ToString();
            }
            return chk;
        }
        public String NumberNull(object o)
        {
            float a = new float();
            try
            {
                a = float.Parse(o.ToString());
            }
            catch (Exception ex)
            {
                a = 0;
            }
            return a.ToString();

        }
        public String NumberNull1(String o)
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
        public String NumberNull11(String o)
        {
            if (o.Equals(""))
            {
                return "1";
            }
            else
            {
                return o;
            }
        }
        public String NumberNullSort(object o)
        {
            float a = new float();
            try
            {
                a = float.Parse(o.ToString());
            }
            catch (Exception ex)
            {
                a = 99;
            }
            return a.ToString();

        }
        //public String shortPaidName(String name)
        //{
        //    if (name == "ประกันสังคม (บ.1)")
        //    {
        //        return "ปกส(บ.1)";
        //    }
        //    else if (name == "ประกันสังคม (บ.2)")
        //    {
        //        return "ปกส(บ.2)";
        //    }
        //    else if (name == "ประกันสังคม (บ.5)")
        //    {
        //        return "ปกส(บ.5)";
        //    }
        //    else if (name == "ประกันสังคมอิสระ (บ.1)")
        //    {
        //        return "ปกต(บ.1)";
        //    }
        //    else if (name == "ประกันสังคมอิสระ (บ.5)")
        //    {
        //        return "ปกต(บ.5)";
        //    }
        //    else if (name == "ตรวจสุขภาพ (เงินสด)")
        //    {
        //        return "ตส(เงินสด)";
        //    }
        //    else if (name == "ตรวจสุขภาพ (บริษัท)")
        //    {
        //        return "ตส(บริษัท)";
        //    }
        //    else if (name == "ตรวจสุขภาพ (PACKAGE)")
        //    {
        //        return "ตส(PACKAGE)";
        //    }
        //    else if (name == "ลูกหนี้ประกันสังคม รพ.เมืองสมุทรปากน้ำ")
        //    {
        //        return "ลูกหนี้(ปากน้ำ)";
        //    }
        //    else if (name == "ลูกหนี้บางนา 1")
        //    {
        //        return "ลูกหนี้(บ.1)";
        //    }
        //    else if (name == "บริษัทประกัน")
        //    {
        //        return "บ.ประกัน";
        //    }
        //    else if (name == "ลูกหนี้ประกันสังคม รพ.เมืองสมุทรปู่เจ้า")
        //    {
        //        return "ลูกหนี้(ปู่เจ้า)";
        //    }
        //    else
        //    {
        //        return name;
        //    }
        //}
    }
}
