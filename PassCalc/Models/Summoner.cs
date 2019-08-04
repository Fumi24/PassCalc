using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCalc
{
    public class SummonerModel
    {
        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("percentCompleteForNextLevel")]
        public long PercentCompleteForNextLevel { get; set; }

        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        [JsonProperty("puuid")]
        public Guid Puuid { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        [JsonProperty("xpSinceLastLevel")]
        public long XpSinceLastLevel { get; set; }

        [JsonProperty("xpUntilNextLevel")]
        public long XpUntilNextLevel { get; set; }
    }
}