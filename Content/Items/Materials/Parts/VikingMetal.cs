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
            item.width = 22;
            item.height = 30;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.maxStack = 999;
        }
    }
}