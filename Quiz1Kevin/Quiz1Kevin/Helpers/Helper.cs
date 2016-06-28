using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Quiz1Kevin.Helpers
{
    public static class Helper
    {
        public static string Label(string target, string text)
        {
            return string.Format("<label for='{0}'>{1}</label>", target, text);
        }
        public static string TextArea(string target, string text)
        {
            return string.Format("<textarea for='{0}'>{1}</textarea>", target, text);

        }

        public static string CheckBox(string target, string text)
        {
            return string.Format("<checkbox for='{0}'>{1}</checkbox>", target, text);
        }


        public static string Textbox(string target, string text)
        {
            return string.Format("<textbox for='{0}'>{1}</textbox>", target, text);
        }
        public static MvcHtmlString List(this HtmlHelper helper, IEnumerable<string> items)
        {
            var result = "<ul>";
            foreach (var item in items)
            {
                result += string.Format("<li>{0}</li>", item);
            }
            result += "<ul>";
            return new MvcHtmlString(result);
        }
    }
}