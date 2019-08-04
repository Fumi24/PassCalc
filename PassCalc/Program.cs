using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PassCalc
{
    class Program
    {
        public static int requirement = 2000;
        public static int aramLosePoints = 4;
        public static int aramWinPoints = 8;
        public static int normalLosePoints = 6;
        public static int normalWinPoints = 12;
        public static int tftLosePoints = 3;
        public static int tftWinPoints = 6;
        private Tuple<Process, string, string> processInfo;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
           
        }
        
        public void run()
        {
            processInfo = LeagueUtils.GetLeagueStatus();

            var summoner = LCU("/lol-summoner/v1/current-summoner");
            var summonermodel = JsonConvert.DeserializeObject<SummonerModel>(summoner);
            var catalog = LCU("/lol-loot/v1/player-loot-map");
            var missions = LCU("/lol-missions/v1/missions");
            var matchlist = LCU($"/lol-acs/v2/matchlists?accountId={summonermodel.AccountId}&begIndex=0&endIndex=100");
            Console.WriteLine(matchlist);
        }
        public string LCU(string url)
        {
            string page = $"https://127.0.0.1:{processInfo.Item3}" + url;

            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            using (HttpClient client = new HttpClient(handler))
            {
                var user = "riot";
                var pass = processInfo.Item2;

                var base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{pass}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetStringAsync(page).GetAwaiter().GetResult();
                //response = response.Replace('"', ' ').Trim();
                return response;
            }
        }
    }
}
