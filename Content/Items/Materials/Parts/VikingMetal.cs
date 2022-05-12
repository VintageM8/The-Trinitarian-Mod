using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class VikingMetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Metal");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.maxStack = 999;
        }
    }
}