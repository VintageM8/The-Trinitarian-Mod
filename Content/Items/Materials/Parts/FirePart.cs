using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class FirePart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Essance");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.maxStack = 999;
        }
    }
}