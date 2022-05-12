using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class Algae : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Algae");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.maxStack = 999;
        }
    }
}