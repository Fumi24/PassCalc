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

        [JsonProperty("missionType")]
        public string MissionType { get; set; }

        [JsonProperty("objectives")]
        public List<Objective> Objectives { get; set; }

        [JsonProperty("requirements")]
        public List<string> Requirements { get; set; }

        [JsonProperty("rewardStrategy")]
        public RewardStrategy RewardStrategy { get; set; }

        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("seriesName")]
        public string SeriesName { get; set; }

        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

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

        [JsonProperty("tutorial")]
        public Tutorial Tutorial { get; set; }
    }

    public partial class NpeRewardPack
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("majorReward")]
        public MajorReward MajorReward { get; set; }

        [JsonProperty("minorRewards")]
        public List<MinorReward> MinorRewards { get; set; }

        [JsonProperty("premiumReward")]
        public bool PremiumReward { get; set; }

        [JsonProperty("rewardKey")]
        public string RewardKey { get; set; }
    }

    public partial class MajorReward
    {
        [JsonProperty("data")]
        public MajorRewardData Data { get; set; }
    }

    public partial class MajorRewardData
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("champIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> ChampIds { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Ids { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("gameModes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> GameModes { get; set; }

        [JsonProperty("hasCustomDetailImage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasCustomDetailImage { get; set; }
    }

    public partial class MinorReward
    {
        [JsonProperty("data")]
        public MinorRewardData Data { get; set; }

        [JsonProperty("renderer")]
        public string Renderer { get; set; }
    }

    public partial class MinorRewardData
    {
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("gameModes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> GameModes { get; set; }

        [JsonProperty("hideInCalendarDetail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideInCalendarDetail { get; set; }

        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Ids { get; set; }
    }

    public partial class Tutorial
    {
        [JsonProperty("displayRewards")]
        public DisplayRewards DisplayRewards { get; set; }

        [JsonProperty("queueId")]
        public string QueueId { get; set; }

        [JsonProperty("stepNumber")]
        public long StepNumber { get; set; }

        [JsonProperty("useChosenChampion")]
        public bool UseChosenChampion { get; set; }

        [JsonProperty("useQuickSearchMatchmaking")]
        public bool UseQuickSearchMatchmaking { get; set; }
    }

    public partial class DisplayRewards
    {
        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        public string The1 { get; set; }
    }

    public partial class Objective
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hasObjectiveBasedReward")]
        public bool HasObjectiveBasedReward { get; set; }

        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("rewardGroups")]
        public List<object> RewardGroups { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }

    public partial class Progress
    {
        [JsonProperty("currentProgress")]
        public long CurrentProgress { get; set; }

        [JsonProperty("lastViewedProgress")]
        public long LastViewedProgress { get; set; }

        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }

    public partial class RewardStrategy
    {

        [JsonProperty("selectMaxGroupCount")]
        public long SelectMaxGroupCount { get; set; }

        [JsonProperty("selectMinGroupCount")]
        public long SelectMinGroupCount { get; set; }
    }

    public partial class Reward
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("isObjectiveBasedReward")]
        public bool IsObjectiveBasedReward { get; set; }

        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("rewardFulfilled")]
        public bool RewardFulfilled { get; set; }

        [JsonProperty("rewardGroup")]
        public string RewardGroup { get; set; }

        [JsonProperty("rewardGroupSelected")]
        public bool RewardGroupSelected { get; set; }

        [JsonProperty("rewardType")]
        public string RewardType { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }
    }

}
