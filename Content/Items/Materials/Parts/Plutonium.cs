using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class Plutonium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plutonium");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.maxStack = 999;
        }
    }
}