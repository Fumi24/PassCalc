using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCalc.Models
{
    public partial class MissionModel
    {
        [JsonProperty("backgroundImageUrl")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("completedDate")]
        public long CompletedDate { get; set; }

        [JsonProperty("cooldownTimeMillis")]
        public long CooldownTimeMillis { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("display")]
        public Display Display { get; set; }

        [JsonProperty("earnedDate")]
        public long EarnedDate { get; set; }

        [JsonProperty("endTime")]
        public long EndTime { get; set; }

        [JsonProperty("expiringWarnings")]
        public List<ExpiringWarning> ExpiringWarnings { get; set; }

        [JsonProperty("iconImageUrl")]
        public string IconImageUrl { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("isNew")]
        public bool IsNew { get; set; }

        [JsonProperty("lastUpdatedTimestamp")]
        public long LastUpdatedTimestamp { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("requirements")]
        public List<string> Requirements { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("viewed")]
        public bool Viewed { get; set; }
    }

    public partial class Display
    {
        [JsonProperty("attributes")]
        public List<object> Attributes { get; set; }
    }

    public partial class ExpiringWarning
    {
        [JsonProperty("alertTime")]
        public long AlertTime { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("npeRewardPack")]
        public NpeRewardPack NpeRewardPack { get; set; }
    }

    public class NpeRewardPack
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("premiumReward")]
        public bool PremiumReward { get; set; }

        [JsonProperty("rewardKey")]
        public string RewardKey { get; set; }
    }
}
