using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Auction.UI.Helpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, int numberPage, int countPage, Func<int, string> url)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= countPage; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.InnerHtml = i.ToString();

                if (i == numberPage)
                {
                    a.MergeAttribute("href", "#");
                    builder.AppendLine("<li>" + a.ToString() + "</li>");
                }
                else
                {
                    a.MergeAttribute("class", "button button-mini");
                    a.MergeAttribute("href", url(i));
                    builder.AppendLine("<li>" + a.ToString() + "</li>");
                }
            }

            return new MvcHtmlString("<ul class=\"navigate\"> " + builder.ToString() + "</ul>");
        }

        
    }
}