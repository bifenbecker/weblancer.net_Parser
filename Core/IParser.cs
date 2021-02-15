using AngleSharp.Html.Dom;


namespace Test_Data_extraction.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
