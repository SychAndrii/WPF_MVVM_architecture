using System.Globalization;
using System.Net;

namespace Testing
{
    public class Program
    {
        private const string URL = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        public static void Main(string[] args)
        {
            var dates = GetDates();
            Console.WriteLine(string.Join("\r\n", dates));
        }

        private static async Task<Stream> GetURLResponseStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetLines()
        {
            var lines = GetURLResponseStream().Result;
            var lines_reader = new StreamReader(lines);

            while(!lines_reader.EndOfStream)
            {
                var line = lines_reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    continue;
                yield return line;
            }
        }

        private static DateTime[] GetDates () => 
            GetLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s =>  DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();
    }
}

