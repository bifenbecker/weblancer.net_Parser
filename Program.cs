using System;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using Test_Data_extraction.Core;
using Test_Data_extraction.Core.weblancer;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Linq;

namespace Test_Data_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Core.ParserWorker<Freelancer[]> parserWorker = new Core.ParserWorker<Freelancer[]>(
            //        new WebLancerParser()
            //    );
            //parserWorker.OnNewData += Parser_OnNewData;
            //parserWorker.OnCompleted += Parser_OnCompleted;
            //parserWorker.Settings = new WebLancerSettings(1, 9999);
            //parserWorker.Start();
            //parserWorker.Abort();

            var countryFilter = Console.ReadLine();

            using (var db = new FreelancerDb())
            {
                var freelancers = db.Freelancers.Where(item => item.Location == countryFilter);

                foreach(var freelancer in freelancers)
                {
                    freelancer.DisplayInfo();
                }
            }

        }

        private static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("Parse is done");
        }

        private static void Parser_OnNewData(object arg1, Freelancer[] arg2)
        {
            using (var db = new FreelancerDb())
            {
                foreach (Freelancer freelancer in arg2)
                {
                    db.Freelancers.Add(freelancer);
                }
                db.SaveChanges();
            }
        }
    }
}
