using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCalc.Models
{
    public partial class PlayerLootMapModel
    {
        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("disenchantLootName")]
        public string DisenchantLootName { get; set; }

        [JsonProperty("disenchantValue")]
        public long DisenchantValue { get; set; }

        [JsonProperty("expiryTime")]
        public long ExpiryTime { get; set; }

        [JsonProperty("isNew")]
        public bool IsNew { get; set; }

        [JsonProperty("isRental")]
        public bool IsRental { get; set; }

        [JsonProperty("itemDesc")]
        public string ItemDesc { get; set; }

        [JsonProperty("localizedDescription")]
        public string LocalizedDescription { get; set; }

        [JsonProperty("localizedRecipeSubtitle")]
        public string LocalizedRecipeSubtitle { get; set; }

        [JsonProperty("lootId")]
        public string LootId { get; set; }

        [JsonProperty("lootName")]
        public string LootName { get; set; }

        [JsonProperty("parentStoreItemId")]
        public long ParentStoreItemId { get; set; }

        [JsonProperty("refId")]
        public string RefId { get; set; }

        [JsonProperty("rentalGames")]
        public long RentalGames { get; set; }

        [JsonProperty("rentalSeconds")]
        public long RentalSeconds { get; set; }

        [JsonProperty("shadowPath")]
        public string ShadowPath { get; set; }

        [JsonProperty("splashPath")]
        public string SplashPath { get; set; }

        [JsonProperty("storeItemId")]
        public long StoreItemId { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tilePath")]
        public string TilePath { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("upgradeEssenceValue")]
        public long UpgradeEssenceValue { get; set; }

        [JsonProperty("upgradeLootName")]
        public string UpgradeLootName { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
