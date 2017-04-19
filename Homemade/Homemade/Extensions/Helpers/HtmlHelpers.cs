using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Homemade.Extensions.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Product(this HtmlHelper helper, string productName, 
            string manufacturer, string quantity, decimal price, string imagePath, string manucaturerLogoPath)
        {
            imagePath = HostingEnvironment.MapPath("~/content/images/shoko.jpg");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div style='display: inline-block;'>");
            sb.AppendLine("<div>");
            sb.AppendLine("<a href='#'>");
            sb.AppendLine("<img src='" + imagePath + "' alt='Mountain View' style ='width: 300px; height: 228px;'>");
            sb.AppendLine("</a>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div style='text-align:center; position:relative; width: 300px'>");
            sb.AppendLine("<h2><a style='text-decoration: none' href='#' title='This is the product title'>This is the product title</a></h2>");
            sb.AppendLine("<strong>This is the product manufacturer</strong>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class='actions'></div>");
            sb.AppendLine("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string imageSource, string alternativeText)
        {
            var builder = new TagBuilder("image");

            builder.MergeAttribute("src", imageSource);
            builder.MergeAttribute("alt", alternativeText);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
