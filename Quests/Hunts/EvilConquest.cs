using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Hunts
{
    public class EvilConquest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Conquest");
            Tooltip.SetDefault("In the world's evil, a slug has manifested\nKill it and bring an end to this horrible mutation.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.maxStack = 1;
        }
    }
}