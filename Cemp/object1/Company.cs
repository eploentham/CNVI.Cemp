﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemp.object1
{
    public class Company:Persistent
    {
        public String Id = "", NameT = "", NameE = "", amphurId = "", districtId = "", provinceId = "", AddressT = "", AddressE = "";
        public String Fax = "", Tele = "", Email = "", TaxId = "", Zipcode = "", vat="", logo="", Code="";
        public String Addr = "", WebSite="", Spec1="";
        public String dateCreate = "", dateModi = "", dateCancel = "", userCreate = "", userModi = "", userCancel = "";
        public String quLine1 = "", quLine2 = "", quLine3 = "", quLine4 = "", quLine5 = "", quLine6 = "";
    }
}
