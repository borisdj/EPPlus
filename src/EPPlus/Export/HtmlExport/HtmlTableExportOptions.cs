﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  05/11/2021         EPPlus Software AB           ExcelTable Html Export
 *************************************************************************************************/
using OfficeOpenXml.Export.HtmlExport.Accessibility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Export.HtmlExport
{
    /// <summary>
    /// Settings for the 
    /// </summary>
    public class HtmlTableExportSettings
    {
        /// <summary>
        /// If set to true the rendered html will be formatted with indents and linebreaks.
        /// </summary>
        public bool Minify { get; set; } = true;
        /// <summary>
        /// If true hidden rows will be included. 
        /// </summary>
        public bool IncludeHiddenRows { get; set; } = false;
        /// <summary>
        /// Settings for usage of accessibility (aria, role) attributes of the table
        /// </summary>
        public AccessibilitySettings Accessibility
        {
            get; private set;
        } = new AccessibilitySettings();
        /// <summary>
        /// If set to true classes that identifies Excel table styling will be included in the html. Default value is true.
        /// </summary>
        public bool IncludeDefaultClasses { get; set; } = true;
        /// <summary>
        /// The html id attribute for the exported table. The id attribute is only added to the table if this property is not null or empty.
        /// </summary>
        public string TableId { get; set; }

        /// <summary>
        /// Use this property to set additional class names that will be set on the exported html-table.
        /// </summary>
        public IList<string> AdditionalTableClassNames
        {
            get;
            private set;
        } = new List<string>();

        /// <summary>
        /// The culture used to 
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

        /// <summary>
        /// If true data-* attributes will be rendered
        /// </summary>
        public bool RenderDataAttributes { get; set; } = true;

        public CssTableExportSettings Css { get; } = new CssTableExportSettings();
    }
    public class CssTableExportSettings
    {
        internal CssTableExportSettings()
        {

        }
        /// <summary>
        /// Include Css for the current table style
        /// </summary>
        public bool IncludeTableStyles { get; set; } = true;
        /// <summary>
        /// Include Css for cell styling.
        /// </summary>
        public bool IncludeCellStyles { get; set; } = true;
        /// <summary>
        /// Css elements added to the table.
        /// </summary>
        internal Dictionary<string, string> AdditionalCssElements
        {
            get;
            private set;
        } = new Dictionary<string, string>()
            {
                { "border-spacing", "0" },
                { "border-collapse", "collapse" },
                { "word-wrap", "break-word"},
                { "white-space", "nowrap"}
            };
        /// <summary>
        /// The value used in the stylesheet for an indentation in a cell
        /// </summary>
        public float IndentValue { get; set; } = 2;
        /// <summary>
        /// The unit used in the stylesheet for an indentation in a cell
        /// </summary>
        public string IndentUnit { get; set; } = "em";
        /// <summary>
        /// Exclude flags for styles
        /// </summary>
        public CssExcludeStyle Exclude
        {
            get;
        } = new CssExcludeStyle();
    }
    [Flags]
    public enum eFontExclude
    {
        Name = 0x01,
        Size = 0x02,
        Color = 0x04,
        Bold = 0x08,
        Italic = 0x10,
        Strike = 0x20,
        Underline = 0x40,
    }
    [Flags]
    public enum eBorderExclude
    {
        Top = 0x01,
        Bottom = 0x02,
        Left = 0x04,
        Right = 0x08
    }

    public class CssExcludeStyle
    {
        public CssExclude TableStyle { get; } = new CssExclude();
        public CssExclude CellStyle { get; } = new CssExclude();
    }
    public class CssExclude
    {
        public eFontExclude Font { get; set; }
        public eBorderExclude Border { get; set; }
        public bool Fill { get; set; }
        public bool VerticalAlignment { get; set; }
        public bool HorizontalAlignment { get; set; }
        public bool WrapText { get; set; }
        public bool TextRotation { get; set; }
        public bool Indent { get; set; }
    }
}