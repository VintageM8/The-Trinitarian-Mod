using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
    public class SummonShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoned Shards");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.maxStack = 99;
        }
    }
}