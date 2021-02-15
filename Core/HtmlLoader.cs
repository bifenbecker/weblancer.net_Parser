using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test_Data_extraction.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}{settings.Prefix}";
        }

        public async Task<string> GetSourceById(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);

            string source = null;

            if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            
            return source;
        }
    }
}
