using Newtonsoft.Json;
using PassCalc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var catalogmodel = JsonConvert.DeserializeObject<List<PlayerLootMapModel>>(catalog);

            var missions = LCU("/lol-missions/v1/missions");
            var missionsmodel = JsonConvert.DeserializeObject<List<MissionModel>>(missions);

            var matchlist = LCU($"/lol-acs/v2/matchlists?accountId={summonermodel.AccountId}&begIndex=0&endIndex=100");
            var matchlistmodel = JsonConvert.DeserializeObject<List<MatchHistoryModel>>(matchlist);

            var projectTokens = catalogmodel.Find(l => l.LootId == "MATERIAL_323");

            long pointsFromMissions = 0;
            var missionCount = 0;
            var proejctMissions = missionsmodel.FindAll(m => m.SeriesName == "PROJECT2019_series");
            var firstWinMissionget = proejctMissions.FindAll(m => m.MissionType == "REPEATING");
            var pendingMissions = proejctMissions.FindAll(m => m.Status == "PENDING");
            var firstWinMission = firstWinMissionget.Count() != 0 ? firstWinMissionget[0] : null;

            foreach (var mission in pendingMissions)
            {
                var rewards = mission.Rewards.FindAll(r => r.ItemId == "lol_project_nonpremium_token");

                foreach (var reward in rewards)
                {
                    missionCount++;
                    pointsFromMissions += reward.Quantity;
                }
            }

            var curTime = new DateTime();
            var nextTime = new DateTime(2019, 8, 1, 1, 0, 0, 0);

            var daysUntilEnd = (new DateTime(2019, 9, 2, 0, 0, 0) - nextTime).TotalDays;
            var firstWinGains = daysUntilEnd * 18;
            var requiredAmount = requirement - projectTokens.Count;
            var playingEveryDayAmount = requiredAmount - firstWinGains;
            var missionsRequiredAmount = playingEveryDayAmount - pointsFromMissions;
            var avgAmountPerDay = missionsRequiredAmount / daysUntilEnd;
            var aramWins = avgAmountPerDay / aramWinPoints;
            var aramLosses = avgAmountPerDay / aramLosePoints;
            var normalWins = avgAmountPerDay / normalWinPoints;
            var normalLosses = avgAmountPerDay / normalLosePoints;
            var tftWins = avgAmountPerDay / tftWinPoints;
            var tftLosses = avgAmountPerDay / tftLosePoints;

            var progressPerc = Math.Round((Convert.ToDouble(projectTokens.Count / requirement)) * 100);

            Console.WriteLine($"You have {daysUntilEnd} days until the end of the event.");
            Console.WriteLine($"You can still get {firstWinGains} tokens off of first win of the days.");
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
                return response;
            }
        }
    }
}
