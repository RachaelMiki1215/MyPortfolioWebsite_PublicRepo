using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyPortfolioWebsite.Other
{
    public static class PageHelper
    {
        private static readonly Dictionary<string, string> _iconDict = new Dictionary<string, string>()
        {
            { "c#" , @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg"" alt=""C#"" title=""C#"" />" },
            { "asp.net", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg"" alt=""ASP.NET"" title=""ASP.NET"" />" },
            { "postgresql", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/postgresql/postgresql-original.svg"" alt=""PostgreSQL"" title=""PostgreSQL"" />" },
            { "html5", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original.svg"" alt=""HTML5"" title=""HTML5"" />" },
            { "css", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/css3/css3-original.svg"" alt=""CSS3"" title=""CSS3"" />" },
            { "javascript", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg"" alt=""JavaScript"" title=""JavaScript"" />" },
            { "jquery", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/jquery/jquery-original.svg"" alt=""jQuery"" title=""jQuery"" />" },
            { "node.js", @"<img src=""https://cdn.jsdelivr.net/gh/devicons/devicon/icons/nodejs/nodejs-original.svg"" alt=""Node.js"" title=""Node.js"" />" }
        };

        private static readonly Dictionary<string, string> _platformIconDict = new Dictionary<string, string>()
        {
            {"web", @"<i class=""fa-solid fa-globe"" title=""Web""></i>" },
            {"desktop", @"<i class=""fa-solid fa-computer"" title=""Desktop""></i>" },
            {"library", @"<i class=""fa-solid fa-book"" title=""Library""></i>" }
        };

        public static IHtmlContent GetLangIcon(this IHtmlHelper htmlHelper, string langName)
        {
            if (_iconDict.ContainsKey(langName.ToLower()))
                return new HtmlString(_iconDict[langName.ToLower()]);

            return new HtmlString(string.Format("<span>{0}</span>", langName));
        }

        public static IHtmlContent MenuItem(this IHtmlHelper htmlHelper, string displayText, 
            string matchText, string linkUrl)
        {
            TagBuilder menuItem = new TagBuilder("a");
            string currArea = ((string)htmlHelper.ViewContext.RouteData.Values["page"]).Split('/')[1];

            if (string.Equals(matchText, currArea, StringComparison.CurrentCultureIgnoreCase))
            {
                menuItem.AddCssClass("selected");
            }
            menuItem.Attributes.Add("href", linkUrl);
            menuItem.InnerHtml.AppendHtml(displayText);

            string htmlOutput;
            using (StringWriter writer = new StringWriter())
            {
                menuItem.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                htmlOutput = writer.ToString();
            }

            return new HtmlString(htmlOutput);
        }

        public static IHtmlContent StatIndicator(this IHtmlHelper htmlHelper, string stat)
        {
            TagBuilder item = new TagBuilder("span");
            item.AddCssClass("status-indicator");

            switch (stat.ToLower())
            {
                case "active":
                    item.AddCssClass("active");
                    break;
                case "complete":
                    item.AddCssClass("complete");
                    break;
                case "discontinued":
                    item.AddCssClass("discontinued");
                    break;
                default:
                    break;
            }

            string htmlOutput;
            using (StringWriter writer = new StringWriter())
            {
                item.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                htmlOutput = writer.ToString();
            }

            return new HtmlString(htmlOutput);
        }

        public static IHtmlContent PlatformIndicator(this IHtmlHelper htmlHelpter, string platform)
        {
            if (_platformIconDict.ContainsKey(platform.ToLower()))
                return new HtmlString(_platformIconDict[platform.ToLower()]);

            return new HtmlString("");
        }
    }
}
