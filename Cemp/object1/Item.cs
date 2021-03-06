﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemp.object1
{
    public class Item:Persistent
    {
        public String Id = "", Code = "", NameT = "", NameE = "", PriceSale = "", PriceCost = "", Remark = "", Active = "";
        public String MeasuringPoint = "", MethodId = "", MethodNameT = "", ItemGroupId = "", ItemGroupNameT = "", Sort1 = "";
        public String dateCreate = "", dateModi = "", dateCancel = "", userCreate = "", userModi = "", userCancel = "", PriceCostReal = "";
        public String ItemType = "", CustId="", CustNameT="", AnalysisId="", AnalysisNameT="", StatusReal="", StatusStock="", StatusPrice="", ValueMin="", ValueMax="";
        public override string ToString()
        {
            return Code + "." + NameT;
        }
    }
}
