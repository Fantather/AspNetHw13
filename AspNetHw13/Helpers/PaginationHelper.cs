using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace AspNetHw13.Helpers
{
    public static class PaginationHelper
    {
        public static HtmlString RenderPagination(this IHtmlHelper htmlHelper, int currentPage, int totalPages, string urlTemplate)
        {
            if (totalPages <= 1) return HtmlString.Empty;


            TagBuilder container = new TagBuilder("ul");
            container.AddCssClass("pagination");
            container.InnerHtml.AppendHtml(BuildPrevButton(currentPage, urlTemplate));

            for (int i = 1; i <= totalPages; i++)
            {
                string pageUrl = urlTemplate.Replace("{page}", i.ToString());
                container.InnerHtml.AppendHtml(BuildPageItem(i.ToString(), pageUrl, i == currentPage, false));
            }

            container.InnerHtml.AppendHtml(BuildNextButton(currentPage, totalPages, urlTemplate));

            using var writer = new System.IO.StringWriter();
            container.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        private static TagBuilder BuildPrevButton(int currentPage, string urlTemplate)
        {
            int prevPage = currentPage - 1;
            bool isDisabled = prevPage <= 0;
            string url = urlTemplate.Replace("{page}", isDisabled ? "1" : prevPage.ToString());

            return BuildPageItem("Prev", url, false, isDisabled);
        }

        private static TagBuilder BuildNextButton(int currentPage, int totalPages, string urlTemplate)
        {
            int nextPage = currentPage + 1;
            bool isDisabled = nextPage > totalPages;
            string url = urlTemplate.Replace("{page}", isDisabled ? totalPages.ToString() : nextPage.ToString());

            return BuildPageItem("Next", url, false, isDisabled);
        }

        private static TagBuilder BuildPageItem(string text, string url, bool isActive, bool isDisabled)
        {
            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("page-item");

            if (isActive) li.AddCssClass("active");
            if (isDisabled) li.AddCssClass("disabled");

            TagBuilder link = new TagBuilder("a");
            link.AddCssClass("page-link");
            link.Attributes.Add("href", url);
            link.InnerHtml.Append(text);

            li.InnerHtml.AppendHtml(link);
            return li;
        }
    }
}
