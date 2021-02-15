

namespace Test_Data_extraction.Core.weblancer
{
    class WebLancerSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://www.weblancer.net/freelancers/";
        public string Prefix { get; set; } = "?page={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }

        public WebLancerSettings(int start, int end)
        {
            
            StartPoint = start;
            EndPoint = end;
        }
    }
}
