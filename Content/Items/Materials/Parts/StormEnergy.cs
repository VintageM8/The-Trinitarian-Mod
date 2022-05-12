using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class StormEnergy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Energy");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.maxStack = 100;
        }
    }
}