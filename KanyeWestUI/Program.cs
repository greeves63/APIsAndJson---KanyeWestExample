using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;


//Console application that calls both the Ron Swanson API, and the Kanye West API.
//Uses both APIs to make Ron Swanson and Kanye West have a conversation that prints to the console.

namespace KanyeWestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x < 6; x++)
            {
                var client = new HttpClient();

                Console.WriteLine(x);
                var kanyeURL = "https://api.kanye.rest";
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine("Kanye Says: ");
                Console.WriteLine(kanyeQuote);
                Console.WriteLine();

                var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
                var ronResponse = client.GetStringAsync(ronURL).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine("Ron Says: ");
                Console.WriteLine(ronQuote);
                Console.WriteLine();

            } 
            
        }
    }
}
