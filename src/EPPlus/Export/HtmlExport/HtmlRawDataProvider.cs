﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  11/07/2021         EPPlus Software AB       Added Html Export
 *************************************************************************************************/
using OfficeOpenXml.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Export.HtmlExport
{
    internal static class HtmlRawDataProvider
    {
        private static readonly DateTime JsBaseDate = new DateTime(1970, 1, 1);
        internal static string GetRawValue(ExcelRangeBase cell, string jsDataType)
        {
            switch(jsDataType)
            {
                case ColumnDataTypeManager.HtmlDataTypes.Boolean:
                    return (ConvertUtil.GetTypedCellValue<bool?>(cell.Value, true)??false) ? "1" : "0";
                case ColumnDataTypeManager.HtmlDataTypes.Number:
                    var v = ConvertUtil.GetTypedCellValue<double?>(cell.Value, true)?.ToString(CultureInfo.InvariantCulture);
                    return v;
                case ColumnDataTypeManager.HtmlDataTypes.DateTime:
                    var dt = ConvertUtil.GetTypedCellValue<DateTime?>(cell.Value, true);
                    if(dt != null && dt.HasValue)
                    {
                        return dt.Value.Subtract(JsBaseDate).TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                    }
                    return string.Empty;
                default:
                    return cell.GetValue<string>();

            }
        }
    }
}