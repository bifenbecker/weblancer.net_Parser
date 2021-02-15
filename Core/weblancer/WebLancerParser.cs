using AngleSharp.Html.Dom;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Test_Data_extraction.Core.weblancer
{
    class WebLancerParser : IParser<Freelancer[]>
    {
        public Freelancer[] Parse(IHtmlDocument document)
        {
            var list = new List<Freelancer>();
            var divs = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName == "row");

            for(int i = 4; i < divs.ToArray().Length; i++)
            {
                try
                {
                    var name = divs.ToArray()[i].QuerySelectorAll("span").First(item => item.ClassName == "name").TextContent;
                    var login = divs.ToArray()[i].QuerySelectorAll("span").First(item => item.ClassName == "nickname").TextContent;
                    var description = divs.ToArray()[i].QuerySelectorAll("p").First(item => item.ClassName == "blockquote text_field").TextContent;
                    var location = divs.ToArray()[i].QuerySelectorAll("span").First(item => item.ClassName == "country-name").TextContent;
                    var url = $"https://www.weblancer.net/users/{login}/";
                    Freelancer f = new Freelancer(name, login, location, description, url);
                    list.Add(f);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return list.ToArray();
        }
    }
}
