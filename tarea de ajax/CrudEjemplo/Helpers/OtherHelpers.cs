using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CrudEjemplo.Helpers
{
    public static class OtherHelpers
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

    }
}