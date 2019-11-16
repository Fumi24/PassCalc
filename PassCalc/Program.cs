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
        public static int requirement = 0;
        public static int aramLosePoints = 4;
        public static int aramWinPoints = 8;
        public static int normalLosePoints = 6;
        public static int normalWinPoints = 12;
        public static int tftLosePoints = 4;
        public static int tftWinPoints = 8;

        private Tuple<Process, string, string> processInfo;
        static void Main(string[] args)
        {
            Console.WriteLine("What is your requirment for this pass?");
            requirement = Convert.ToInt32(Console.ReadLine());
            Program p = new Program();
            p.run();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public void run()
        {
            processInfo = LeagueUtils.GetLeagueStatus();

            var summoner = LCU("/lol-summoner/v1/current-summoner");
            var summonermodel = JsonConvert.DeserializeObject<SummonerModel>(summoner);

            var catalog = LCU("/lol-loot/v1/player-loot-map");
            var catalogmodel = JsonConvert.DeserializeObject<PlayerLootModel>(catalog);

            var missions = LCU("/lol-missions/v1/missions");
            var missionsmodel = JsonConvert.DeserializeObject<List<MissionModel>>(missions);

            var matchlist = LCU($"/lol-acs/v2/matchlists?accountId={summonermodel.AccountId}&begIndex=0&endIndex=100");
            var matchlistmodel = JsonConvert.DeserializeObject<MatchHistoryModel>(matchlist);
            var projectTokens = 0;

            try
            {
                projectTokens = 60;
            }
            catch(Exception e)
            {
                projectTokens = 60;
            }
            long pointsFromMissions = 0;
            var missionCount = 0;
            var proejctMissions = missionsmodel.FindAll(m => m.SeriesName == "Worlds2019B_series");
            var firstWinMissionget = proejctMissions.FindAll(m => m.MissionType == "REPEATING");
            var pendingMissions = proejctMissions.FindAll(m => m.Status == "PENDING");
            var firstWinMission = firstWinMissionget.Count() != 0 ? firstWinMissionget[0] : null;

            foreach (var mission in pendingMissions)
            {
                var rewards = mission.Rewards.FindAll(r => r.ItemId == "lol_worlds_nonpremium_token");

                foreach (var reward in rewards)
                {
                    missionCount++;
                    pointsFromMissions += reward.Quantity;
                }
            }

            var curTime = DateTime.Now;
            var nextTime = new DateTime(2019, 11, 19, 0, 0, 0, 0);

            var daysUntilEnd = Math.Ceiling(Convert.ToDecimal((nextTime - curTime).TotalDays) - 1);
            var firstWinGains = daysUntilEnd * 18;
            var requiredAmount = requirement - projectTokens;
            var playingEveryDayAmount = requiredAmount - firstWinGains;
            var missionsRequiredAmount = playingEveryDayAmount - pointsFromMissions;
            var avgAmountPerDay = missionsRequiredAmount / daysUntilEnd;
            var aramWins = avgAmountPerDay / aramWinPoints;
            var aramLosses = avgAmountPerDay / aramLosePoints;
            var normalWins = avgAmountPerDay / normalWinPoints;
            var normalLosses = avgAmountPerDay / normalLosePoints;
            var tftWins = avgAmountPerDay / tftWinPoints;
            var tftLosses = avgAmountPerDay / tftLosePoints;


            int progressPerc = (int)Math.Round((double)(100 * projectTokens) / requirement);

            Console.WriteLine($"You have {daysUntilEnd} days until the end of the event.");
            Console.WriteLine($"You can still get {firstWinGains} tokens off of first win of the days.\n");

            if (missionCount != 0)
            {
                Console.WriteLine($"You can still unlock { missionCount} mission for {pointsFromMissions} tokens.");
            }
            var missionAdd = $"Assuming you'll complete the stuff stated above, you still need {missionsRequiredAmount}";

            Console.WriteLine($"To get { requirement} tokens, you still need { requiredAmount}.\nAssuming you play every day, you still need { playingEveryDayAmount}. \n{ missionAdd}\n");
            Console.WriteLine($"That's {Math.Ceiling(avgAmountPerDay)} tokens per day.");
            Console.WriteLine($"That's {Math.Ceiling(aramWins)} aram wins per day ({aramWinPoints}), {Math.Ceiling(aramLosses)} aram losses ({aramLosePoints}).");
            Console.WriteLine($"That's {Math.Ceiling(aramWins)} Urf wins per day ({aramWinPoints}), {Math.Ceiling(aramLosses)} Urf losses ({aramLosePoints}).");
            Console.WriteLine($"That's {Math.Ceiling(normalWins)} normal wins per day ({normalWinPoints}), {Math.Ceiling(normalLosses)} normal losses ({normalLosePoints}).");
            Console.WriteLine($"That's {Math.Ceiling(tftWins)} tft top 4 per day ({tftWinPoints}), {Math.Ceiling(tftLosses)} tft bottom 4 losses ({tftLosePoints}).\n");
            Console.WriteLine($"You are at {progressPerc}% of your goal of {requirement}.");




            //THIS PART DOESNT WORK YET
            //           var pointsToday = 0;


            //           var needTokensToday = avgAmountPerDay - pointsToday;
            //           var aramWinsNeeded = Math.Ceiling(needTokensToday / aramWinPoints);
            //           var aramLossesNeeded = Math.Ceiling(needTokensToday / aramLosePoints);
            //           var normalLossesNeeded = Math.Ceiling(needTokensToday / normalLosePoints);
            //           var normalWinsNeeded = Math.Ceiling(needTokensToday / normalWinPoints);
            //           var tftLossesNeeded = Math.Ceiling(needTokensToday / tftLosePoints);
            //           var tftWinsNeeded = Math.Ceiling(needTokensToday / tftWinPoints);
            //           var needMessage = needTokensToday < 0 ? "That's enough for today!" : $"You need { Math.Ceiling(needTokensToday)} more! That's {normalWinsNeeded}~{normalLossesNeeded} normals or {aramWinsNeeded}~{aramLossesNeeded} aram games or {tftWinsNeeded}~{tftLossesNeeded} TFT games!";

            //           Console.WriteLine($"You got { pointsToday} tokens today. { needMessage}");

            //var firstWinUnlockMillis = new DateTime(firstWinMission.EarnedDate + firstWinMission.CooldownTimeMillis) - curTime;
            //           Console.WriteLine(firstWinMission.Status == "COMPLETED" ? $"Your first win of the day mission unlocks in { (firstWinUnlockMillis)}" : "You can still get your first win of the day for 18 tokens!");

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
