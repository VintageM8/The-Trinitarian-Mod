using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class SummonShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summon Shards");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.maxStack = 999;
        }
    }
}