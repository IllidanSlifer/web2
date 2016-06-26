using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CrudEjemplo.Helpers
{
    public static class OwnHelpers
    {
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