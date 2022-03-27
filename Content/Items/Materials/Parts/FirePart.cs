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
            item.width = 18;
            item.height = 20;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.maxStack = 999;
        }
    }
}