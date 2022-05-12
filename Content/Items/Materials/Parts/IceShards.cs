using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class IceShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Shards");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.maxStack = 999;
        }
    }
}