using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO.Packaging;
using System.Text;


namespace TTSH.ServiceLayer.Excel
{
    static class Extension
    {

        public static void StartTagWrite(this OpenXmlLeafElement runElement, StringBuilder writer)
        {
            IWriteOperation x = new HTMLWriteOperation { Writer = writer };
            x.StartTagWrite((dynamic)runElement);
        }
        public static void EndTagWrite(this OpenXmlLeafElement runElement, StringBuilder writer)
        {
            IWriteOperation x = new HTMLWriteOperation { Writer = writer };
            x.EndTagWrite((dynamic)runElement);
        }



    }

    public interface IWriteOperation
    {
        void StartTagWrite(Bold bold);
        void StartTagWrite(Italic it);
        void StartTagWrite(Underline underline);
        void StartTagWrite(Color c);
        void StartTagWrite(Font font);
        void StartTagWrite(FontSize fontSize);
        void StartTagWrite(FontFamily fontFamily);
        void StartTagWrite(FontScheme fontScheme);
        void StartTagWrite(RunFont runFont);
        void StartTagWrite(Strike strike);
        void StartTagWrite(VerticalTextAlignment vertialAlignment);
        void StartTagWrite(Shadow shadow);
        void StartTagWrite(Outline outline);
        void StartTagWrite(Condense condense);
        void StartTagWrite(Hyperlink hyperlink);

        void EndTagWrite(Bold b);
        void EndTagWrite(Italic b);
        void EndTagWrite(Underline b);
        void EndTagWrite(Color u);
        void EndTagWrite(Font u);
        void EndTagWrite(FontSize u);
        void EndTagWrite(FontFamily u);
        void EndTagWrite(RunFont u);
        void EndTagWrite(FontScheme u);
        void EndTagWrite(Strike u);
        void EndTagWrite(VerticalTextAlignment u);
        void EndTagWrite(Shadow u);
        void EndTagWrite(Outline u);
        void EndTagWrite(Condense u);
        void EndTagWrite(Hyperlink u);
    }
    public class HTMLWriteOperation : IWriteOperation
    {
        public StringBuilder Writer { get; set; }

        void IWriteOperation.StartTagWrite(Bold iThing) { Writer.AppendLine("<B>"); }
        void IWriteOperation.EndTagWrite(Bold iThing) { Writer.AppendLine("</B>"); }

        void IWriteOperation.EndTagWrite(Underline aThing) { Writer.AppendLine("</U>"); }
        void IWriteOperation.StartTagWrite(Underline aThing) { Writer.AppendLine("<U>"); }

        void IWriteOperation.StartTagWrite(Italic aThing) { Writer.AppendFormat("<I>"); }
        void IWriteOperation.EndTagWrite(Italic aThing) { Writer.AppendFormat("</I>"); }

        void IWriteOperation.StartTagWrite(Strike u) { Writer.AppendLine("<del>"); }
        void IWriteOperation.EndTagWrite(Strike aThing) { Writer.AppendLine("</del>"); }

        void IWriteOperation.StartTagWrite(Hyperlink u) { Writer.AppendLine("<a>"); }
        void IWriteOperation.EndTagWrite(Hyperlink aThing) { Writer.AppendLine("</a>"); }

        void IWriteOperation.StartTagWrite(Color u)
        {
            if (u.Rgb != null)
            {
                string colorFormat = @"<span style=""color:#{0};"">";
                string span = string.Format(colorFormat, u.Rgb.Value.Substring(2, 6));
                Writer.AppendLine(span);
            }
        }
        void IWriteOperation.EndTagWrite(Color aThing)
        {
            Writer.AppendLine("</span>");
        }
        void IWriteOperation.StartTagWrite(RunFont u)
        {
            if (u.Val.HasValue)
            {
                string fontFormat = @"<span style=""font-family:'{0}';"">";
                string span = string.Format(fontFormat, u.Val.Value);
                Writer.AppendLine(span);
            }
        }
        void IWriteOperation.EndTagWrite(RunFont aThing)
        {
            Writer.AppendLine("</span>");
        }

        void IWriteOperation.EndTagWrite(FontSize aThing)
        {
            Writer.AppendLine("</span>");
        }
        void IWriteOperation.StartTagWrite(FontSize u)
        {
            string fontSizeFormat = @"<span style=""font-size:{0}px;"">";
            string span = string.Format(fontSizeFormat, u.Val);
            Writer.AppendLine(span);
        }

        void IWriteOperation.StartTagWrite(Font u) { }
        void IWriteOperation.EndTagWrite(Font aThing) { }

        void IWriteOperation.EndTagWrite(FontScheme aThing) { }
        void IWriteOperation.StartTagWrite(FontScheme u) { }

        void IWriteOperation.EndTagWrite(Condense aThing) { }
        void IWriteOperation.StartTagWrite(Condense u) { }

        void IWriteOperation.EndTagWrite(VerticalTextAlignment aThing) { }
        void IWriteOperation.StartTagWrite(VerticalTextAlignment u) { }

        void IWriteOperation.EndTagWrite(Shadow aThing) { }
        void IWriteOperation.StartTagWrite(Shadow u) { }

        void IWriteOperation.StartTagWrite(FontFamily u) { }
        void IWriteOperation.EndTagWrite(FontFamily aThing) { }

        void IWriteOperation.StartTagWrite(Outline u) { }
        void IWriteOperation.EndTagWrite(Outline aThing) { }
    }

}