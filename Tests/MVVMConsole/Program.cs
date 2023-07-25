using System.Globalization;
using System.Net;

namespace Testing
{
    public class Program
    {
        private const string URL = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        public static void Main(string[] args)
        {
            var russia = GetData().First(c => c.country.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join("\r\n", GetDates().Zip(russia.counts, (date, count) => $"{date} - {count}")));
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
                yield return line.Replace("Korea,", "Korea -");
            }
        }

        private static DateTime[] GetDates () => 
            GetLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s =>  DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string country, string province, int[] counts)> GetData()
        {
            var lines = GetLines()
                .Skip(1)
                .Select(s => s.Split(','));

            foreach (var line in lines)
            {
                var province = line[0].Trim();
                var countryName = line[1].Trim(' ', '"');
                int[] counts = null;

                try
                {
                    counts = line.Skip(4).Select(int.Parse).ToArray();
                }
                catch (Exception)
                {

                }

                yield return (countryName, province, counts);
            }

        } 

    }
}

