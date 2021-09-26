using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
    public class CyroOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyro Orbs");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.maxStack = 999;
        }
    }
}