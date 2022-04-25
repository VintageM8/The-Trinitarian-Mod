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
            item.width = 18;
            item.height = 20;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 100;
        }
    }
}