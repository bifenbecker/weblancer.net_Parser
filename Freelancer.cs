using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Data_extraction
{
    public class Freelancer
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Login { get; set; }
        public Freelancer()
        {

        }
        public Freelancer(string name,string login, string location, string description, string url)
        {
            Name = name;
            Login = login;
            Location = location;
            Description = description;
            Url = url;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} \n {Location} \n {Description} \n {Url} \n");
        }
      
    }
}
