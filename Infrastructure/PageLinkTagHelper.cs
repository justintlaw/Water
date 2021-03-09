using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Water.Models.ViewModels;

namespace Water.Infrastructure
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set;}
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        // Overriding
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            //TagBuilder result = new TagBuilder("div");

            //for (int i = 1; i <= PageModel.TotalPages; i++)
            //{
            //    TagBuilder tag = new TagBuilder("a");
            //    tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
            //    tag.InnerHtml.Append(i.ToString());

            //    result.InnerHtml.AppendHtml(tag);
            //}

            //output.Content.AppendHtml(result.InnerHtml);

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("ul");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder listItem = new TagBuilder("li");
                TagBuilder link = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;

                link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                
                if (PageClassesEnabled)
                {
                    link.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    link.AddCssClass(PageClass);
                }

                link.InnerHtml.Append(i.ToString());

                listItem.InnerHtml.AppendHtml(link);

                result.InnerHtml.AppendHtml(listItem);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
